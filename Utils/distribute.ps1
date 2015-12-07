Import-Module $PSScriptRoot\PS-Zip.psm1

# ビルド
../build.bat

# フォルダ名
$buildFolderX86 = Join-Path $PSScriptRoot "..\BuildX86"
$buildFolderX64 = Join-Path $PSScriptRoot "..\BuildX64"
$dllPath = Join-Path $buildFolderX86 "\OverlayPlugin.dll"
$version = [System.Diagnostics.FileVersionInfo]::GetVersionInfo("$dllPath").FileVersion
$fullFolderX86 = Join-Path $PSScriptRoot ("Distribute\OverlayPlugin-" + $version + "-x86-full")
$updateFolderX86 = Join-Path $PSScriptRoot ("Distribute\OverlayPlugin-" + $version + "-x86-update")
$fullFolderX64 = Join-Path $PSScriptRoot ("Distribute\OverlayPlugin-" + $version + "-x64-full")
$updateFolderX64 = Join-Path $PSScriptRoot ("Distribute\OverlayPlugin-" + $version + "-x64-update")

# フォルダが既に存在するなら消去
if ( Test-Path $fullFolderX86 -PathType Container ) {
	Remove-Item -Recurse -Force $fullFolderX86
}
if ( Test-Path $updateFolderX86 -PathType Container ) {
	Remove-Item -Recurse -Force $updateFolderX86
}
if ( Test-Path $fullFolderX64 -PathType Container ) {
	Remove-Item -Recurse -Force $fullFolderX64
}
if ( Test-Path $updateFolderX64 -PathType Container ) {
	Remove-Item -Recurse -Force $updateFolderX64
}

# フォルダ作成
New-Item -ItemType directory -Path $fullFolderX86
New-Item -ItemType directory -Path $updateFolderX86
New-Item -ItemType directory -Path $fullFolderX64
New-Item -ItemType directory -Path $updateFolderX64

# X86版コピー
# full
xcopy /Y /R /S /EXCLUDE:full.exclude "$buildFolderX86\*" "$fullFolderX86"

# update
xcopy /Y /R "$buildFolderX86\HtmlRenderer.dll" "$updateFolderX86"
xcopy /Y /R "$buildFolderX86\OverlayPlugin.dll" "$updateFolderX86"
xcopy /Y /R "$buildFolderX86\OverlayPlugin.Core.dll" "$updateFolderX86"
xcopy /Y /R "$buildFolderX86\OverlayPlugin.Common.dll" "$updateFolderX86"
xcopy /Y /R "$buildFolderX86\README.md" "$updateFolderX86"
xcopy /Y /R "$buildFolderX86\LICENSE.txt" "$updateFolderX86"
xcopy /Y /R /S "$buildFolderX86\resources\*" "$updateFolderX86\resources\"
xcopy /Y /R /S "$buildFolderX86\ja-JP\*" "$updateFolderX86\ja-JP\"

# X64版コピー
# full
xcopy /Y /R /S /EXCLUDE:full.exclude "$buildFolderX64\*" "$fullFolderX64"

# update
xcopy /Y /R "$buildFolderX64\HtmlRenderer.dll" "$updateFolderX64"
xcopy /Y /R "$buildFolderX64\OverlayPlugin.dll" "$updateFolderX64"
xcopy /Y /R "$buildFolderX64\OverlayPlugin.Core.dll" "$updateFolderX64"
xcopy /Y /R "$buildFolderX64\OverlayPlugin.Common.dll" "$updateFolderX64"
xcopy /Y /R "$buildFolderX64\README.md" "$updateFolderX64"
xcopy /Y /R "$buildFolderX64\LICENSE.txt" "$updateFolderX64"
xcopy /Y /R /S "$buildFolderX64\resources\*" "$updateFolderX64\resources\"
xcopy /Y /R /S "$buildFolderX64\ja-JP\*" "$updateFolderX64\ja-JP\"

# アーカイブ
New-ZipCompress -source $fullFolderX86 -destination "$fullFolderX86.zip"
New-ZipCompress -source $updateFolderX86 -destination "$updateFolderX86.zip"
New-ZipCompress -source $fullFolderX64 -destination "$fullFolderX64.zip"
New-ZipCompress -source $updateFolderX64 -destination "$updateFolderX64.zip"