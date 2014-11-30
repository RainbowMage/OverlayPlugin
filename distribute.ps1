Import-Module $PSScriptRoot\PS-Zip.psm1

# ビルド
./build.bat

# バージョン取得
$version = [System.Diagnostics.FileVersionInfo]::GetVersionInfo("Build\OverlayPlugin.dll").FileVersion

# フォルダ名
$buildFolder = ".\Build"
$fullFolder = ".\Distribute\OverlayPlugin-" + $version + "-full"
$updateFolder = ".\Distribute\OverlayPlugin-" + $version + "-update"

# フォルダが既に存在するなら消去
if ( Test-Path $fullFolder -PathType Container ) {
	Remove-Item -Recurse -Force $fullFolder
}
if ( Test-Path $updateFolder -PathType Container ) {
	Remove-Item -Recurse -Force $updateFolder
}

# フォルダ作成
New-Item -ItemType directory -Path $fullFolder
New-Item -ItemType directory -Path $updateFolder

# コピー
# full
xcopy /Y /R /S /EXCLUDE:full.exclude "$buildFolder\*" "$fullFolder"

# update
xcopy /Y /R "$buildFolder\HtmlRenderer.dll" "$updateFolder"
xcopy /Y /R "$buildFolder\OverlayPlugin.dll" "$updateFolder"
xcopy /Y /R "$buildFolder\README.md" "$updateFolder"
xcopy /Y /R "$buildFolder\LICENSE.txt" "$updateFolder"

# アーカイブ
New-ZipCompress -source $fullFolder -destination "$fullFolder.zip"
New-ZipCompress -source $updateFolder -destination "$updateFolder.zip"

pause
