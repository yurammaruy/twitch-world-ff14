//go:build !windows

package main

import "fmt"

// Versao de teste (fora do Windows): mostra a "janela" no terminal e responde Sim.

func setupConsole() {}

func messageBox(title, text string, flags uintptr) int {
	fmt.Printf("\n[JANELA] %s\n%s\n\n", title, text)
	return idYes
}

func systemLangIndex() int { return 0 }
