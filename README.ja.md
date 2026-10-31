# Twitch World FF14

[English](README.md) · [Português](README.pt-BR.md) · **日本語** · [Deutsch](README.de.md) · [Français](README.fr.md)

<p align="center"><img src="assets/icon.png" width="128" alt="Twitch World FF14"></p>

> ファイナルファンタジーXIV の中で Twitch チャットを読んで返信できる Dalamud プラグイン。プログラマーでなくても使える 1 ファイルのインストーラー付き。

**Twitch World** は、任意の Twitch チャンネルのチャットをゲーム *内* に表示します(専用ウィンドウ、または FFXIV のチャットタブに、ユーザーごとの色と MOD / VIP / SUB バッジ付きで表示)。ゲームを離れずに返信もできます。初期状態は**空**で、チャンネルもアカウントも設定されていません。FFXIV を遊ぶ配信者・モデレーター・視聴者向けです。

## ダウンロード

**[⬇ インストーラーをダウンロード(最新リリース)](../../releases/latest)**

## 機能

- Twitch チャットをウィンドウ **および/または** ゲームのチャットタブに表示(リンクシェル [8] の方法はガイドで説明)
- Twitch の名前の色(ゲームの色に近似)と [STREAMER] [MOD] [VIP] [SUB] [BOT] バッジ
- 自分宛てのメッセージは金色、ボットの通知はティール色で強調
- 閲覧のみなら**アカウントもトークンも不要**。送信は `/tw-chat メッセージ`
- ボットコマンド(`/` と `!`)、絵文字、エモート、リンクはブロック。同時接続は 1 チャットのみ。**メッセージを隠すことはありません**
- **5 言語**(English・日本語・Deutsch・Français・Português)のインストーラーと手順ガイド

## クイックインストール(Windows 10/11)

1. [最新リリース](../../releases/latest)の *Assets* から **TwitchWorldFF14-Setup.exe** をダウンロードします。
2. FFXIV を終了し、ファイルをダブルクリック。青い「Windows によって PC が保護されました」画面が出たら **詳細情報 → 実行** を押します。
3. 言語を選んで確認し、`[6/6]` になるまで待ちます(初回は .NET を約 250 MB ダウンロードします)。
4. ゲーム内で `/xlsettings` → **Experimental** → **Dev Plugin Locations** に貼り付け(Ctrl+V・パスは自動コピー済み)→ **+** → **Save and Close**。
5. `/xlplugins` → **Dev Tools** → **Installed Dev Plugins** → **Twitch World** をオン → `/tw-chat` と入力。

## 詳しい手順ガイド

📖 **[日本語 – full step-by-step guide](docs/GUIDE.JA.md)** · [English](docs/GUIDE.EN.md) · [Português (Brasil)](docs/GUIDE.PT.md) · [Deutsch](docs/GUIDE.DE.md) · [Français](docs/GUIDE.FR.md)

## 重要

- Dalamud プラグインはスクウェア・エニックスの利用規約で**許可されていません**。このプラグインは文字の読み書きのみで、ゲーム内の操作を自動化しませんが、プラグイン使用のリスクはあります。自己責任でご利用ください。
- 非公式プロジェクトです。スクウェア・エニックス、Twitch、Dalamud とは無関係です。「Twitch」「Final Fantasy」は各権利者の商標です。
- インストーラーには**デジタル署名がない**ため、Windows やウイルス対策ソフトが警告する場合があります。ソースコードはすべてこのリポジトリにあり、各リリースに SHA-256 チェックサムを記載しています。ダウンロードはこのページからのみ行ってください。
- Twitch トークン(メッセージ*送信*時のみ必要)はパスワードと同じです。絶対に他人に見せないでください。

## ヘルプ / 不具合

[Issue](../../issues/new/choose) を作成してください(`install-log.txt` を添付。トークンは絶対に載せないでください)。

---

**キーワード:** ファイナルファンタジーXIV, FF14, FFXIV, Dalamud プラグイン, XIVLauncher, Twitch チャット, ゲーム内チャット, 配信者ツール, リンクシェル。

MIT License · © 2026 Lirou
