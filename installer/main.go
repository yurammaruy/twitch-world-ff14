package main

import (
	"bufio"
	"embed"
	"errors"
	"flag"
	"fmt"
	"io"
	"io/fs"
	"os"
	"os/exec"
	"path/filepath"
	"runtime"
	"strconv"
	"strings"
)

// Tudo que o instalador instala fica embutido neste unico .exe.
//
//go:embed all:payload
var payload embed.FS

const (
	appName = "Twitch World FF14"
	dllName = "TwitchWorld.dll"

	mbYesNo         = 0x00000004
	mbIconWarning   = 0x00000030
	mbIconError     = 0x00000010
	mbIconInfo      = 0x00000040
	mbDefButton2    = 0x00000100
	mbSetForeground = 0x00010000
	idYes           = 6
)

// Opcoes escondidas, usadas so para testar o instalador.
var (
	flagDir  = flag.String("dir", "", "pasta de instalacao (teste)")
	flagDry  = flag.Bool("dry-run", false, "nao baixa nem compila nada (teste)")
	flagLang = flag.Int("lang", 0, "idioma 1-5 (teste)")
	flagYes  = flag.Bool("yes", false, "pula a confirmacao inicial (teste)")
)

var errCancelled = errors.New("cancelled")

type installer struct {
	t       *Lang
	dir     string
	log     *os.File
	dotnet  string
	private bool
	dllPath string
}

func main() {
	flag.Parse()
	setupConsole()

	dir := *flagDir
	if dir == "" {
		dir = `C:\` + appName
	}

	in := &installer{t: pickLanguage(), dir: dir}
	err := in.run()

	switch {
	case err == nil:
	case errors.Is(err, errCancelled):
		in.say("%s", in.t.Cancelled)
	default:
		in.say("ERROR: %v", err)
		logPath := filepath.Join(in.dir, "install-log.txt")
		messageBox(in.t.FailTitle, fmt.Sprintf(in.t.Fail, err.Error(), logPath), mbIconError)
	}

	if in.log != nil {
		in.log.Close()
	}
	if !*flagYes {
		fmt.Println()
		fmt.Println(in.t.PressEnter)
		bufio.NewReader(os.Stdin).ReadString('\n')
	}
	if err != nil && !errors.Is(err, errCancelled) {
		os.Exit(1)
	}
}

// ---------- idioma ----------

func pickLanguage() *Lang {
	if *flagLang >= 1 && *flagLang <= len(langs) {
		return &langs[*flagLang-1]
	}

	def := systemLangIndex()
	fmt.Println("============================================================")
	fmt.Println("  " + appName + " - Setup")
	fmt.Println("============================================================")
	fmt.Println()
	for i, l := range langs {
		fmt.Printf("  %d) %s\n", i+1, l.Menu)
	}
	fmt.Println()
	fmt.Printf("  Language / 言語 / Sprache / Langue / Idioma  [%d]: ", def+1)

	line, _ := bufio.NewReader(os.Stdin).ReadString('\n')
	n, err := strconv.Atoi(strings.TrimSpace(line))
	if err != nil || n < 1 || n > len(langs) {
		n = def + 1
	}
	fmt.Println()
	return &langs[n-1]
}

// ---------- mensagens ----------

func (in *installer) say(format string, args ...any) {
	line := fmt.Sprintf(format, args...)
	fmt.Println(line)
	if in.log != nil {
		fmt.Fprintln(in.log, line)
	}
}

func (in *installer) step(n int, text string) {
	in.say("")
	in.say("[%d/6] %s", n, text)
}

// ---------- fluxo principal ----------

func (in *installer) run() error {
	t := in.t

	if !*flagYes {
		if messageBox(t.WelcomeTitle, fmt.Sprintf(t.Welcome, in.dir), mbYesNo|mbIconInfo) != idYes {
			return errCancelled
		}
	}

	// 1) pasta e arquivos
	if err := os.MkdirAll(in.dir, 0o755); err != nil {
		home, herr := os.UserHomeDir()
		if herr != nil || *flagDir != "" {
			return fmt.Errorf("could not create %s: %w", in.dir, err)
		}
		in.dir = filepath.Join(home, appName)
		if err2 := os.MkdirAll(in.dir, 0o755); err2 != nil {
			return fmt.Errorf("could not create %s: %w", in.dir, err2)
		}
		fmt.Printf(t.FolderFallback+"\n", in.dir)
	}

	logFile, err := os.OpenFile(filepath.Join(in.dir, "install-log.txt"), os.O_CREATE|os.O_WRONLY|os.O_TRUNC, 0o644)
	if err == nil {
		in.log = logFile
	}

	in.say("%s", appName)
	in.step(1, t.S1)
	if err := in.extract(); err != nil {
		return fmt.Errorf("copying files: %w", err)
	}
	in.say("  -> %s", in.dir)

	// 2) XIVLauncher / Dalamud
	in.step(2, t.S2)
	if err := in.checkDalamud(); err != nil {
		return err
	}

	// 3) .NET
	in.step(3, t.S3)
	if err := in.prepareDotnet(); err != nil {
		return err
	}

	// 4) compilar
	in.step(4, t.S4)
	if err := in.build(); err != nil {
		return err
	}
	in.say("  -> %s", in.dllPath)

	// 5) atalhos, icones, area de transferencia
	in.step(5, t.S5)
	in.finishWindows()

	// 6) abrir o guia e terminar
	in.step(6, t.S6)
	guide := filepath.Join(in.dir, "Docs", "README_"+t.Code+".txt")
	if runtime.GOOS == "windows" && !*flagDry {
		exec.Command("cmd", "/c", "start", "", guide).Start()
	}

	messageBox(t.DoneTitle, fmt.Sprintf(t.Done, in.dllPath), mbIconInfo)
	return nil
}

// ---------- 1) copiar os arquivos embutidos ----------

func (in *installer) extract() error {
	// recomeca a pasta Source do zero (nunca sobram arquivos de versoes antigas)
	if err := os.RemoveAll(filepath.Join(in.dir, "Source")); err != nil {
		return err
	}

	err := fs.WalkDir(payload, "payload", func(p string, d fs.DirEntry, err error) error {
		if err != nil {
			return err
		}
		rel := strings.TrimPrefix(strings.TrimPrefix(p, "payload"), "/")
		if rel == "" {
			return nil
		}
		target := filepath.Join(in.dir, filepath.FromSlash(rel))
		if d.IsDir() {
			return os.MkdirAll(target, 0o755)
		}
		data, err := payload.ReadFile(p)
		if err != nil {
			return err
		}
		return os.WriteFile(target, data, 0o644)
	})
	if err != nil {
		return err
	}

	in.setFolderIcon()
	return nil
}

// setFolderIcon coloca o icone do Twitch World na pasta principal.
func (in *installer) setFolderIcon() {
	if runtime.GOOS != "windows" || *flagDry {
		return
	}
	ini := filepath.Join(in.dir, "desktop.ini")
	os.Remove(ini)
	content := "[.ShellClassInfo]\r\nIconResource=" + filepath.Join(in.dir, "Icons", "TwitchWorld.ico") + ",0\r\n"
	if err := os.WriteFile(ini, []byte(content), 0o644); err != nil {
		return
	}
	exec.Command("attrib", "+s", "+h", ini).Run()
	exec.Command("attrib", "+r", in.dir).Run()
}

// ---------- 2) Dalamud ----------

func (in *installer) checkDalamud() error {
	if *flagDry || runtime.GOOS != "windows" {
		in.say("  (skipped)")
		return nil
	}
	hooks := filepath.Join(os.Getenv("APPDATA"), "XIVLauncher", "addon", "Hooks")
	if st, err := os.Stat(hooks); err == nil && st.IsDir() {
		in.say("  OK: %s", hooks)
		return nil
	}
	in.say("  NOT FOUND: %s", hooks)
	if *flagYes {
		return nil
	}
	if messageBox(in.t.NoHooksTitle, fmt.Sprintf(in.t.NoHooks, hooks), mbYesNo|mbIconWarning|mbDefButton2) != idYes {
		return errCancelled
	}
	return nil
}

// ---------- 3) .NET ----------

func sdkOK(dotnet string) bool {
	out, err := exec.Command(dotnet, "--list-sdks").Output()
	if err != nil {
		return false
	}
	for _, line := range strings.Split(string(out), "\n") {
		f := strings.Fields(line)
		if len(f) == 0 {
			continue
		}
		major, err := strconv.Atoi(strings.SplitN(f[0], ".", 2)[0])
		if err == nil && major >= 10 {
			return true
		}
	}
	return false
}

func (in *installer) prepareDotnet() error {
	if *flagDry {
		in.say("  (skipped)")
		in.dotnet = "dotnet"
		return nil
	}

	candidates := []string{filepath.Join(in.dir, "dotnet", "dotnet.exe"), filepath.Join(in.dir, "dotnet", "dotnet")}
	if p, err := exec.LookPath("dotnet"); err == nil {
		candidates = append(candidates, p)
	}
	if pf := os.Getenv("ProgramFiles"); pf != "" {
		candidates = append(candidates, filepath.Join(pf, "dotnet", "dotnet.exe"))
	}

	for _, c := range candidates {
		if _, err := os.Stat(c); err != nil {
			continue
		}
		if sdkOK(c) {
			in.dotnet = c
			in.private = strings.HasPrefix(strings.ToLower(c), strings.ToLower(filepath.Join(in.dir, "dotnet")))
			in.say(".NET: %s", c)
			in.say("  %s", in.t.S3Found)
			return nil
		}
	}

	// instala uma copia privada do .NET dentro da pasta do programa (nao precisa de administrador)
	if runtime.GOOS != "windows" {
		return errors.New(".NET SDK 10 or newer not found")
	}
	in.say("  %s", in.t.S3Download)

	script := filepath.Join(in.dir, "dotnet-install.ps1")
	download := "$ProgressPreference='SilentlyContinue'; " +
		"[Net.ServicePointManager]::SecurityProtocol=[Net.SecurityProtocolType]::Tls12; " +
		"Invoke-WebRequest -UseBasicParsing -Uri 'https://dot.net/v1/dotnet-install.ps1' -OutFile '" + script + "'"
	if err := in.run1(in.dir, nil, "powershell.exe", "-NoProfile", "-ExecutionPolicy", "Bypass", "-Command", download); err != nil {
		return fmt.Errorf("could not download the .NET installer (check your internet): %w", err)
	}

	installDir := filepath.Join(in.dir, "dotnet")
	if err := in.run1(in.dir, nil, "powershell.exe", "-NoProfile", "-ExecutionPolicy", "Bypass",
		"-File", script, "-Channel", "10.0", "-InstallDir", installDir, "-NoPath"); err != nil {
		return fmt.Errorf(".NET installation failed: %w", err)
	}

	in.dotnet = filepath.Join(installDir, "dotnet.exe")
	in.private = true
	if !sdkOK(in.dotnet) {
		return errors.New(".NET was installed but could not be used")
	}
	return nil
}

// ---------- 4) compilar ----------

func (in *installer) build() error {
	src := filepath.Join(in.dir, "Source")

	if *flagDry {
		in.say("  (skipped)")
		in.dllPath = filepath.Join(src, "bin", "Release", dllName)
		return nil
	}

	env := []string{
		"DOTNET_CLI_TELEMETRY_OPTOUT=1",
		"DOTNET_NOLOGO=1",
		"DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1",
		"MSBUILDDISABLENODEREUSE=1",
	}
	if in.private {
		root := filepath.Join(in.dir, "dotnet")
		env = append(env, "DOTNET_ROOT="+root, "PATH="+root+string(os.PathListSeparator)+os.Getenv("PATH"))
	}

	err := in.run1(src, env, in.dotnet, "build", "-c", "Release", "--nologo", "-v", "minimal")
	in.run1(src, env, in.dotnet, "build-server", "shutdown") // libera processos que segurariam arquivos
	if err != nil {
		return fmt.Errorf("the plugin could not be built: %w", err)
	}

	var found string
	filepath.WalkDir(filepath.Join(src, "bin"), func(p string, d fs.DirEntry, err error) error {
		if err == nil && !d.IsDir() && strings.EqualFold(d.Name(), dllName) && found == "" {
			found = p
		}
		return nil
	})
	if found == "" {
		return errors.New("build finished but " + dllName + " was not created")
	}
	in.dllPath = found
	return nil
}

// run1 executa um programa mostrando a saida na tela e gravando no registro.
func (in *installer) run1(dir string, env []string, name string, args ...string) error {
	cmd := exec.Command(name, args...)
	cmd.Dir = dir
	cmd.Env = append(os.Environ(), env...)
	var w io.Writer = os.Stdout
	if in.log != nil {
		w = io.MultiWriter(os.Stdout, in.log)
	}
	cmd.Stdout = w
	cmd.Stderr = w
	return cmd.Run()
}

// ---------- 5) atalhos, icones e caminho na area de transferencia ----------

func psQuote(s string) string { return "'" + strings.ReplaceAll(s, "'", "''") + "'" }

func (in *installer) finishWindows() {
	if runtime.GOOS != "windows" || *flagDry {
		in.say("  (skipped)")
		return
	}
	t := in.t
	ico := filepath.Join(in.dir, "Icons", "TwitchWorld.ico") + ",0"
	guide := filepath.Join(in.dir, "Docs", "README_"+t.Code+".txt")

	script := "$ErrorActionPreference = 'Continue'\r\n" +
		"$ws = New-Object -ComObject WScript.Shell\r\n" +
		"$desk = [Environment]::GetFolderPath('Desktop')\r\n" +
		"$a = $ws.CreateShortcut((Join-Path $desk " + psQuote(appName+".lnk") + "))\r\n" +
		"$a.TargetPath = " + psQuote(in.dir) + "\r\n" +
		"$a.IconLocation = " + psQuote(ico) + "\r\n" +
		"$a.Description = " + psQuote(appName) + "\r\n" +
		"$a.Save()\r\n" +
		"$b = $ws.CreateShortcut((Join-Path $desk " + psQuote(t.GuideLink+".lnk") + "))\r\n" +
		"$b.TargetPath = " + psQuote(guide) + "\r\n" +
		"$b.IconLocation = " + psQuote(ico) + "\r\n" +
		"$b.Save()\r\n" +
		"Set-Clipboard -Value " + psQuote(in.dllPath) + "\r\n"

	ps1 := filepath.Join(in.dir, "finish.ps1")
	// BOM UTF-8: o PowerShell do Windows le os nomes com acento/japones corretamente
	if err := os.WriteFile(ps1, append([]byte("\xef\xbb\xbf"), []byte(script)...), 0o644); err != nil {
		in.say("  (could not write the shortcut script: %v)", err)
		return
	}
	if err := in.run1(in.dir, nil, "powershell.exe", "-NoProfile", "-ExecutionPolicy", "Bypass", "-File", ps1); err != nil {
		in.say("  (shortcuts/clipboard: %v)", err)
	}
	os.Remove(ps1)
}
