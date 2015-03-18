# OverlayPlugin

ACT に柔軟にカスタマイズ可能なミニパースやスペルタイマーのオーバーレイを追加します。

## 動作環境

* .NET Framework 4.5 以上がインストールされているシステム

## ダウンロード

[リリースページ](https://github.com/RainbowMage/OverlayPlugin/releases)でビルド済みのバイナリを配布しています。

ダウンロード後、ファイルを展開する前にダウンロードした ZIP ファイルを右クリックしてプロパティを開き、「ブロックを解除」ボタンを押してブロックを解除することを強く推奨します。

## ビルド方法

手順:

* .NET Framework 4.5.1 をインストールします
* Microsoft Build Tools 2013 (http://www.microsoft.com/ja-jp/download/details.aspx?id=40760) をインストールします（Visual Studio 2013 がインストールされている場合は不要）
* ソースコード一式をチェックアウト、または ZIP ファイルでダウンロードして解凍します
* Thirdparty フォルダの中にある ACT フォルダに、ACT の実行ファイル（Advanced Combat Tracker.exe）をコピーします
* build.bat を実行します

うまくいけば、BuildX86 および BuildX64 フォルダの中にプラグインが生成されます。

## 使用方法

OverlayPlugin.dll をプラグインとして ACT に追加します。

追加すると、`No data to show` と表示されたオーバーレイか、 もしくはプレイヤーの DPS が表示されたオーバーレイが表示されます。
オーバーレイの非透過部分をドラッグすると移動させることができ、右下のハンドルをドラッグするとオーバーレイのサイズの変更ができます。

ACT のプラグインタブにある「OverlayPlugin.dll」タブで、オーバーレイの追加や削除、表示の切り替え、マウスクリックの透過、表示するファイルの設定などが行えます。

## トラブルシューティング

オーバーレイウィンドウなどが表示されない場合は、`Plugins` タブにある `OverlayPlugin.dll` タブ内の下部にあるログのメッセージをよく確認した上で [トラブルシューティング](https://github.com/RainbowMage/OverlayPlugin/wiki/%E3%83%88%E3%83%A9%E3%83%96%E3%83%AB%E3%82%B7%E3%83%A5%E3%83%BC%E3%83%86%E3%82%A3%E3%83%B3%E3%82%B0)をお読みください。

## カスタマイズ

プラグインが配置されているフォルダにある resources フォルダの中の、`miniparse.html` および `spelltimer.html` を編集することでカスタマイズができます。 

詳しい編集方法に関しては [Wiki](https://github.com/RainbowMage/OverlayPlugin/wiki/) をご覧ください。JavaScript と HTML に関する基礎的な知識があれば編集できると思います。

## アドオン

本プラグインはアドオンをサポートしております。対応するアドオンをプラグインディレクトリ直下の `addon` ディレクトリに配置すると自動的に読み込まれます。

仕様に関しては `AddonExample` プロジェクトをご確認ください。

## ライセンス

MIT ライセンスです。詳細は LICENSE.txt を参照してください。

## Other Languages:

* [English (EN)](../master/README-en.md)
