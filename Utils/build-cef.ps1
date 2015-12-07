#
# Build script for Chromium Embedded Framework 3
#
# !! Build requires VERY long time and VERY large amount of disk space (>70GB) !!
#

if ($currentDir.Contains(" "))
{
	throw "Script directory must not contains a space character."
}

# Git revision of CEF
$cefRevision = "807de3c161f5598597e40f5a42e8541d9e3eb905"

# Git revision of Chromium
# See 'CHROMIUM_BUILD_COMPATIBILITY.txt' of the CEF root directory to get this value.
$chromiumRevision = "4c2743615eaa2806ad014c59bf6acbb652cf3aa8"

$env:GYP_GENERATORS = "ninja,msvs-ninja"
$env:GYP_MSVS_VERSION = "2013"
$env:DEPOT_TOOLS_WIN_TOOLCHAIN = "0"

$currentDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$rootDir = Join-Path $currentDir "cef-build"
$downloadDir = Join-Path $rootDir "download"
$depotToolsDir = Join-Path $rootDir "depot_tools"
$chromiumDir = Join-Path $rootDir "chromium"
$env:Path += ";$depotToolsDir"

function Main
{
	CreateDirectory
	DeployDepotTools
	DownloadSourceCode
	ApplyFixForJapaneseEnvironment
	Build32Bit
	Build64Bit
	PackBinary
}

function CreateDirectory
{
	if (!(Test-Path $chromiumDir)) { mkdir $chromiumDir }
}

# Download, extract and update depot tools
function DeployDepotTools
{
	if (!(Test-Path $depotToolsDir))
	{
		function Expand-Zip($file, $destination)
		{
			$shell = new-object -com shell.application
			$zip = $shell.NameSpace($file)
			foreach ($item in $zip.items())
			{
				$shell.Namespace($destination).copyhere($item)
			}
		}
		
		Invoke-WebRequest -Uri "https://src.chromium.org/svn/trunk/tools/depot_tools.zip" -OutFile "$rootDir\depot_tools.zip"
		Expand-Zip -File "$rootDir\depot_tools.zip" -Destination "$rootDir"
		
		cd $depotToolsDir
		./update_depot_tools.bat
	}
}

function DownloadSourceCode
{
	# Download Chromium and CEF
	cd $chromiumDir
	fetch --nohooks chromium --nosvn=True
	gclient sync --revision $chromiumRevision --jobs 8 --with_branch_heads
	
	cd $chromiumDir\src
	git clone https://bitbucket.org/chromiumembedded/cef.git
	cd cef
	git checkout $cefRevision
}

# Apply patch for Japanese environment
function ApplyFixForJapaneseEnvironment
{
	if ((Get-WinSystemLocale).Name -eq "ja-JP") 
	{
		$sitecustomize = Join-Path "$currentDir" "sitecustomize-jp.py";
		copy "$sitecustomize" "$depotToolsDir\python276_bin\Lib\site-packages\sitecustomize.py"
		
		cd $chromiumDir\src
		$patchFile = Join-Path "$currentDir" "suppress-c4819.patch"
		git --git-dir= apply --ignore-whitespace -p1 "$patchFile"
	}
}

# Build 32-bit version
function Build32Bit
{
	$env:GYP_DEFINES="target_arch=ia32"
	
	cd $chromiumDir\src\cef
	./cef_create_projects.bat
	
	cd $chromiumDir\src
	ninja -C out/Debug cefclient cef_unittests
	ninja -C out/Release cefclient cef_unittests
}

# Build 64-bit version
function Build64Bit
{
	$env:GYP_DEFINES="target_arch=x64"
	
	# Patch if Chromium version == 45.0.2454.85
	if ($chromiumRevision -eq "4c2743615eaa2806ad014c59bf6acbb652cf3aa8")
	{
		cd $chromiumDir\src
		git checkout 1d078f6c8a00ed3c571002238de6d1424fa7548f -- media/cdm/stub/stub_cdm.cc
	}
	
	cd $chromiumDir\src\cef
	./cef_create_projects.bat
	
	cd $chromiumDir\src
	ninja -C out/Debug_x64 cefclient cef_unittests
	ninja -C out/Release_x64 cefclient cef_unittests
}

# Packaging
function PackBinary
{
	cd $chromiumDir\src\cef\tools
	./make_distrib.bat --ninja-build
	./make_distrib.bat --ninja-build --x64-build
}

Main
