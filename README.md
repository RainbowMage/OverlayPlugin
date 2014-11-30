# OverlayPlugin

## ビルド方法

手順:

* .NET Framework 4.5.1 をインストールします
* Microsoft Build Tools 2013 (http://www.microsoft.com/ja-jp/download/details.aspx?id=40760) をインストールします（Visual Studio 2013 がインストールされている場合は不要）
* ソースコード一式をチェックアウト、または ZIP ファイルでダウンロードして解凍します
* Thirdparty フォルダの中にある ACT フォルダに、ACT の実行ファイルをコピーします
* build.bat を実行します

うまくいけば、Build フォルダの中にプラグインが生成されます。

## 使用方法

Build フォルダの中の OverlayPlugin.dll をプラグインとして ACT に追加します。
（OverlayPlugin.dll 単体を抜き出しての使用はできません。他のフォルダに移したいときは、ほかのファイルと一緒に移動させてください。）

追加すると、「No data to show」、または DPS が表示されたウィンドウが表示されます。
非透過部分をドラッグすると移動でき、右下のハンドルをドラッグするとサイズの変更ができます。

ACT のプラグインタブにある「OverlayPlugin.dll」タブで、表示の切り替えやマウスクリックの透過、表示するファイルの設定などができます。

## カスタマイズ

プラグインが配置されているフォルダにある resources フォルダの中の、default.html を編集することでカスタマイズができます。 

JavaScript と HTML に関する基礎的な知識があれば編集できると思います。

## ライセンス

MIT ライセンスです。詳細は LICENSE.txt を参照してください。
