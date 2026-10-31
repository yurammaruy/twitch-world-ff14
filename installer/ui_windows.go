//go:build windows

package main

import (
	"strings"
	"syscall"
	"unsafe"
)

var (
	user32           = syscall.NewLazyDLL("user32.dll")
	kernel32         = syscall.NewLazyDLL("kernel32.dll")
	procMessageBoxW  = user32.NewProc("MessageBoxW")
	procSetOutputCP  = kernel32.NewProc("SetConsoleOutputCP")
	procSetInputCP   = kernel32.NewProc("SetConsoleCP")
	procUILanguageID = kernel32.NewProc("GetUserDefaultUILanguage")
)

// setupConsole deixa o console em UTF-8 para mostrar acentos e japones.
func setupConsole() {
	procSetOutputCP.Call(65001)
	procSetInputCP.Call(65001)
}

// messageBox mostra uma janela do Windows (aceita Unicode em qualquer idioma).
func messageBox(title, text string, flags uintptr) int {
	text = strings.ReplaceAll(strings.ReplaceAll(text, "\r\n", "\n"), "\n", "\r\n")
	t, _ := syscall.UTF16PtrFromString(title)
	m, _ := syscall.UTF16PtrFromString(text)
	r, _, _ := procMessageBoxW.Call(0, uintptr(unsafe.Pointer(m)), uintptr(unsafe.Pointer(t)), flags|mbSetForeground)
	return int(r)
}

// systemLangIndex devolve o idioma do Windows como indice de `langs` (0 = ingles).
func systemLangIndex() int {
	r, _, _ := procUILanguageID.Call()
	switch r & 0x3FF {
	case 0x11: // japones
		return 1
	case 0x07: // alemao
		return 2
	case 0x0C: // frances
		return 3
	case 0x16: // portugues
		return 4
	}
	return 0
}
