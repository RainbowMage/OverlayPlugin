@echo off

if not exist "%~dp0\Thirdparty\ACT\Advanced Combat Tracker.exe" (
	echo エラー: "Thirdparty" ディレクトリに "Advanced Combat Tracker.exe" をコピーしてください。
	goto END
)


set DOTNET_PATH=%windir%\Microsoft.NET\Framework\v4.0.30319
if not exist %DOTNET_PATH% (
	echo エラー: .NET Framework のディレクトリが見つかりません。ビルドを実行するためには .NET Framework 4.5.1 がインストールされている必要があります。
	goto END
)


%DOTNET_PATH%\msbuild /t:Rebuild /p:Configuration=Release /p:Platform=x86 /p:OutputPath="%~dp0\BuildX86" "%~dp0\OverlayPlugin.sln"
%DOTNET_PATH%\msbuild /t:Rebuild /p:Configuration=Release /p:Platform=x64 /p:OutputPath="%~dp0\BuildX64" "%~dp0\OverlayPlugin.sln"


:END
