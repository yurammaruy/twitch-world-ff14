package main

// Lang reune todos os textos do instalador em um idioma.
// Ordem do menu: English, 日本語, Deutsch, Français, Português.
type Lang struct {
	Code      string // sufixo do guia: README_<Code>.txt
	Menu      string
	GuideLink string // nome do atalho do guia na Area de Trabalho

	WelcomeTitle string
	Welcome      string // %s = pasta
	Cancelled    string

	S1, S2, S3, S3Found, S3Download, S4, S5, S6 string

	NoHooksTitle string
	NoHooks      string // %s = pasta do Dalamud

	DoneTitle string
	Done      string // %s = caminho do TwitchWorld.dll

	FailTitle string
	Fail      string // %s = motivo, %s = arquivo de registro

	PressEnter     string
	FolderFallback string // %s = nova pasta
}

var langs = []Lang{
	{
		Code:      "EN",
		Menu:      "English",
		GuideLink: "Twitch World FF14 - Guide",

		WelcomeTitle: "Twitch World FF14 - Setup",
		Welcome: "This installer will:\n\n" +
			"1. Create the folder %s\n" +
			"2. Copy the Twitch World plugin files\n" +
			"3. Download .NET if your PC does not have it yet (about 250 MB)\n" +
			"4. Prepare (build) the plugin\n" +
			"5. Create shortcuts on your Desktop\n\n" +
			"It takes 5 to 15 minutes and needs internet. Please close Final Fantasy XIV first.\n\n" +
			"Do you want to continue?",
		Cancelled: "Installation cancelled.",

		S1:         "Creating the folder and copying the files...",
		S2:         "Checking XIVLauncher / Dalamud...",
		S3:         "Looking for .NET on your PC...",
		S3Found:    ".NET found. Using the one already installed.",
		S3Download: ".NET not found. Downloading it (this can take a while)...",
		S4:         "Preparing (building) the plugin... this can take a few minutes.",
		S5:         "Creating shortcuts and icons...",
		S6:         "Finishing...",

		NoHooksTitle: "Dalamud not found",
		NoHooks: "I could not find the Dalamud folder on this PC:\n%s\n\n" +
			"This usually means the game has never been opened through XIVLauncher with Dalamud turned on.\n\n" +
			"Open the game once through XIVLauncher, close it, and run this installer again.\n\n" +
			"Continue anyway? (preparing the plugin will probably fail)",

		DoneTitle: "All done!",
		Done: "Installation complete!\n\n" +
			"The plugin path has already been COPIED. Just paste it (Ctrl+V) in the game, as explained in the guide that opened in Notepad (PART B).\n\n" +
			"Path:\n%s",

		FailTitle: "Something went wrong",
		Fail: "Something went wrong and the installation did not finish.\n\n" +
			"Reason: %s\n\n" +
			"What to do:\n" +
			"1. Check that your PC is connected to the internet.\n" +
			"2. Run the installer again.\n" +
			"3. If it keeps failing, take a screenshot of this window and send it together with this file:\n%s",

		PressEnter:     "Press Enter to close...",
		FolderFallback: "Could not create the folder on C:\\. Using this folder instead: %s",
	},
	{
		Code:      "JA",
		Menu:      "日本語 (Japanese)",
		GuideLink: "Twitch World FF14 - ガイド",

		WelcomeTitle: "Twitch World FF14 - インストーラー",
		Welcome: "このインストーラーは次の処理を行います:\n\n" +
			"1. フォルダー %s を作成\n" +
			"2. Twitch World プラグインのファイルをコピー\n" +
			"3. お使いのPCに .NET が無い場合はダウンロード(約250MB)\n" +
			"4. プラグインの準備(ビルド)\n" +
			"5. デスクトップにショートカットを作成\n\n" +
			"所要時間は5〜15分で、インターネット接続が必要です。先に Final Fantasy XIV を終了してください。\n\n" +
			"続行しますか?",
		Cancelled: "インストールをキャンセルしました。",

		S1:         "フォルダーを作成してファイルをコピーしています...",
		S2:         "XIVLauncher / Dalamud を確認しています...",
		S3:         ".NET を確認しています...",
		S3Found:    ".NET が見つかりました。インストール済みのものを使用します。",
		S3Download: ".NET が見つかりません。ダウンロード中です(時間がかかります)...",
		S4:         "プラグインを準備(ビルド)しています...数分かかることがあります。",
		S5:         "ショートカットとアイコンを作成しています...",
		S6:         "仕上げ中...",

		NoHooksTitle: "Dalamud が見つかりません",
		NoHooks: "このPCでDalamudのフォルダーが見つかりませんでした:\n%s\n\n" +
			"ゲームがXIVLauncher経由(Dalamud有効)で一度も起動されていない可能性があります。\n\n" +
			"一度XIVLauncherでゲームを起動して終了してから、このインストーラーをもう一度実行してください。\n\n" +
			"このまま続行しますか?(プラグインの準備は失敗する可能性が高いです)",

		DoneTitle: "完了しました!",
		Done: "インストールが完了しました!\n\n" +
			"プラグインのパスはコピー済みです。メモ帳で開いたガイドの「パートB」に従って、ゲーム内で貼り付け(Ctrl+V)てください。\n\n" +
			"パス:\n%s",

		FailTitle: "うまくいきませんでした",
		Fail: "問題が発生し、インストールを完了できませんでした。\n\n" +
			"原因: %s\n\n" +
			"対処方法:\n" +
			"1. インターネットに接続されているか確認してください。\n" +
			"2. インストーラーをもう一度実行してください。\n" +
			"3. 解決しない場合は、この画面と次のファイルのスクリーンショットを送ってください:\n%s",

		PressEnter:     "Enterキーを押すと閉じます...",
		FolderFallback: "C:\\ にフォルダーを作成できませんでした。次のフォルダーを使用します: %s",
	},
	{
		Code:      "DE",
		Menu:      "Deutsch",
		GuideLink: "Twitch World FF14 - Anleitung",

		WelcomeTitle: "Twitch World FF14 - Installation",
		Welcome: "Dieses Installationsprogramm wird:\n\n" +
			"1. Den Ordner %s erstellen\n" +
			"2. Die Dateien des Twitch-World-Plugins kopieren\n" +
			"3. .NET herunterladen, falls es auf deinem PC noch fehlt (ca. 250 MB)\n" +
			"4. Das Plugin vorbereiten (kompilieren)\n" +
			"5. Verknüpfungen auf dem Desktop erstellen\n\n" +
			"Das dauert 5 bis 15 Minuten und benötigt eine Internetverbindung. Bitte schließe zuerst Final Fantasy XIV.\n\n" +
			"Möchtest du fortfahren?",
		Cancelled: "Installation abgebrochen.",

		S1:         "Ordner wird erstellt und Dateien werden kopiert ...",
		S2:         "XIVLauncher/Dalamud wird geprüft ...",
		S3:         ".NET wird auf deinem PC gesucht ...",
		S3Found:    ".NET gefunden. Die vorhandene Installation wird verwendet.",
		S3Download: ".NET nicht gefunden. Wird heruntergeladen (das kann dauern) ...",
		S4:         "Plugin wird vorbereitet (kompiliert) ... das kann einige Minuten dauern.",
		S5:         "Verknüpfungen und Symbole werden erstellt ...",
		S6:         "Abschluss ...",

		NoHooksTitle: "Dalamud nicht gefunden",
		NoHooks: "Der Dalamud-Ordner wurde auf diesem PC nicht gefunden:\n%s\n\n" +
			"Das bedeutet meist, dass das Spiel noch nie über den XIVLauncher mit aktiviertem Dalamud gestartet wurde.\n\n" +
			"Starte das Spiel einmal über den XIVLauncher, beende es und starte dieses Installationsprogramm erneut.\n\n" +
			"Trotzdem fortfahren? (Die Vorbereitung des Plugins schlägt wahrscheinlich fehl)",

		DoneTitle: "Alles fertig!",
		Done: "Installation abgeschlossen!\n\n" +
			"Der Pfad zum Plugin wurde bereits KOPIERT. Füge ihn im Spiel mit Strg+V ein, wie in der Anleitung beschrieben, die sich im Editor geöffnet hat (TEIL B).\n\n" +
			"Pfad:\n%s",

		FailTitle: "Leider fehlgeschlagen",
		Fail: "Etwas ist schiefgelaufen und die Installation wurde nicht abgeschlossen.\n\n" +
			"Grund: %s\n\n" +
			"Was du tun kannst:\n" +
			"1. Prüfe, ob dein PC mit dem Internet verbunden ist.\n" +
			"2. Starte das Installationsprogramm erneut.\n" +
			"3. Wenn es weiter nicht klappt, mache einen Screenshot dieses Fensters und sende ihn zusammen mit dieser Datei:\n%s",

		PressEnter:     "Drücke die Eingabetaste zum Schließen ...",
		FolderFallback: "Der Ordner konnte nicht unter C:\\ erstellt werden. Es wird dieser Ordner verwendet: %s",
	},
	{
		Code:      "FR",
		Menu:      "Français",
		GuideLink: "Twitch World FF14 - Guide",

		WelcomeTitle: "Twitch World FF14 - Installation",
		Welcome: "Ce programme d'installation va :\n\n" +
			"1. Créer le dossier %s\n" +
			"2. Copier les fichiers du plugin Twitch World\n" +
			"3. Télécharger .NET si votre PC ne l'a pas encore (environ 250 Mo)\n" +
			"4. Préparer (compiler) le plugin\n" +
			"5. Créer des raccourcis sur le Bureau\n\n" +
			"Cela prend de 5 à 15 minutes et nécessite Internet. Veuillez d'abord fermer Final Fantasy XIV.\n\n" +
			"Voulez-vous continuer ?",
		Cancelled: "Installation annulée.",

		S1:         "Création du dossier et copie des fichiers...",
		S2:         "Vérification de XIVLauncher / Dalamud...",
		S3:         "Recherche de .NET sur votre PC...",
		S3Found:    ".NET trouvé : l'installation existante sera utilisée.",
		S3Download: ".NET introuvable. Téléchargement en cours (cela peut prendre du temps)...",
		S4:         "Préparation (compilation) du plugin... cela peut prendre quelques minutes.",
		S5:         "Création des raccourcis et des icônes...",
		S6:         "Finalisation...",

		NoHooksTitle: "Dalamud introuvable",
		NoHooks: "Le dossier de Dalamud est introuvable sur ce PC :\n%s\n\n" +
			"Cela signifie généralement que le jeu n'a jamais été lancé via XIVLauncher avec Dalamud activé.\n\n" +
			"Lancez le jeu une fois via XIVLauncher, fermez-le, puis relancez ce programme d'installation.\n\n" +
			"Voulez-vous continuer quand même ? (la préparation du plugin échouera probablement)",

		DoneTitle: "Tout est prêt !",
		Done: "Installation terminée !\n\n" +
			"Le chemin du plugin a déjà été COPIÉ. Il suffit de le coller (Ctrl+V) dans le jeu, comme l'explique le guide ouvert dans le Bloc-notes (PARTIE B).\n\n" +
			"Chemin :\n%s",

		FailTitle: "Échec de l'installation",
		Fail: "Un problème est survenu et l'installation n'est pas terminée.\n\n" +
			"Cause : %s\n\n" +
			"Que faire :\n" +
			"1. Vérifiez que votre PC est connecté à Internet.\n" +
			"2. Relancez le programme d'installation.\n" +
			"3. Si le problème persiste, faites une capture d'écran de cette fenêtre et envoyez-la avec ce fichier :\n%s",

		PressEnter:     "Appuyez sur Entrée pour fermer...",
		FolderFallback: "Impossible de créer le dossier sur C:\\. Ce dossier sera utilisé : %s",
	},
	{
		Code:      "PT",
		Menu:      "Português",
		GuideLink: "Twitch World FF14 - Guia",

		WelcomeTitle: "Twitch World FF14 - Instalador",
		Welcome: "Este instalador vai:\n\n" +
			"1. Criar a pasta %s\n" +
			"2. Copiar os arquivos do plugin Twitch World\n" +
			"3. Baixar o .NET, se o seu PC ainda não tiver (cerca de 250 MB)\n" +
			"4. Preparar (compilar) o plugin\n" +
			"5. Criar atalhos na Área de Trabalho\n\n" +
			"Demora de 5 a 15 minutos e precisa de internet. Feche o Final Fantasy XIV antes de continuar.\n\n" +
			"Deseja continuar?",
		Cancelled: "Instalação cancelada.",

		S1:         "Criando a pasta e copiando os arquivos...",
		S2:         "Verificando o XIVLauncher / Dalamud...",
		S3:         "Procurando o .NET no seu PC...",
		S3Found:    ".NET encontrado. Vou usar o que já está instalado.",
		S3Download: ".NET não encontrado. Baixando (pode demorar)...",
		S4:         "Preparando (compilando) o plugin... isso pode levar alguns minutos.",
		S5:         "Criando os atalhos e os ícones...",
		S6:         "Finalizando...",

		NoHooksTitle: "Dalamud não encontrado",
		NoHooks: "Não encontrei a pasta do Dalamud neste PC:\n%s\n\n" +
			"Isso normalmente significa que o jogo ainda não foi aberto pelo XIVLauncher com o Dalamud ligado.\n\n" +
			"Abra o jogo uma vez pelo XIVLauncher, feche, e rode este instalador de novo.\n\n" +
			"Quer continuar mesmo assim? (a preparação do plugin provavelmente vai falhar)",

		DoneTitle: "Tudo pronto!",
		Done: "Instalação concluída!\n\n" +
			"O caminho do plugin já foi COPIADO. Agora é só colar (Ctrl+V) no jogo, como explica o guia que abriu no Bloco de Notas (PARTE B).\n\n" +
			"Caminho:\n%s",

		FailTitle: "Ops! Não deu certo",
		Fail: "Algo deu errado e a instalação não terminou.\n\n" +
			"Motivo: %s\n\n" +
			"O que fazer:\n" +
			"1. Confira se o PC está com internet.\n" +
			"2. Rode o instalador de novo.\n" +
			"3. Se continuar, tire um print desta janela e envie junto com este arquivo:\n%s",

		PressEnter:     "Pressione Enter para fechar...",
		FolderFallback: "Não foi possível criar a pasta no C:\\. Usando esta pasta: %s",
	},
}
