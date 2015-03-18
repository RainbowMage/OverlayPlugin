# OverlayPlugin

Plugin to show customizable mini parse and timeline overlay for Advanced Combat Tracker.

## Download

You can download release and pre-release archives from [release page](https://github.com/RainbowMage/OverlayPlugin/releases).

## System requirements

* .NET Framework 4.5

## How to build

* Install .NET Framework 4.5.1 or later.
* Install [Microsoft Build Tools 2013](http://www.microsoft.com/ja-jp/download/details.aspx?id=40760). (This is not required if you installed Visual Studio 2013 already.)
* Checkout source codes with git, or download source code as ZIP and extract.
* Copy the Advanced Combat Tracker executable file (`Advanced Combat Tracker.exe`) into `Thirdparty\ACT` folder.
* Execute `build.bat`.

Once finished, the plugin file `OverlayPlugin.dll` will appear in the `Build` folder.

## How to use

To use this plugin, add the `OverlayPlugin.dll` in ACT's plugin tab. It can not be moved around alone, as the files around it are important.

When you first install, a window will appear saying "No data to show" or your DPS numbers. It can be moved by dragging a non-transparent part, and resized by dragging the bottom right corner (it's a little hard to see).

In the Plugins tab of ACT in the `OveralyPlugin.dll` tab, you can change the settings like the formatting file (URL), or if clickthrough is enabled.

Example HTML files are in `Build\resources`

## Troubleshooting

If the window does not appear, please check the message log at the bottom of the window of the `OverlayPlugin.dll` tab of the `Plugins` tab.

### `Error: AssemblyResolve: => System.NotSupportedException`

If you use standard Windows ZIP-ing, after downloading the archive from the Internet, it may be flagged as an untrusted file.

If this happens, it's not possible to read the executable or DLLs that have this flag, and the above error will occur. To check whether the file has blocked or not and unblock it, please refer to:  http://blogs.msdn.com/b/delay/p/unblockingdownloadedfile.aspx.

In Windows Explorer, for each of the DLL files, right-click and select `Properties` then click the `Unblock` button at the bottom.

This can also happen if you are using this on a networked drive. Please copy to a local drive instead.

### `Error: AssemblyResolve: => System.IO.FileNotFoundException`

A required DLL is missing in the folder that `OverlayPlugin.dll` is in.

Please copy all of the files when moving location.

### The parser won't sit in front of the game window anymore.

It's probably Windows's fault. Toggle the visibility off and on again and it will fix itself.

## License

MIT license. See LICENSE.txt for details.
