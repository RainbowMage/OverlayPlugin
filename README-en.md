# OverlayPlugin

Plugin to show customizable mini parse and timeline overlay for Advanced Combat Tracker.

## How to build

* Install .NET Framework 4.5.1 or later.
* Install Microsoft Build Tools 2013. (This is not required if you installed Visual Studio 2013 already.)
* Checkout source codes with git, or download source code as ZIP and extract.
* Copy Advanced Combat Tracker executable file (`Advanced Combat Tracker.exe`) into `Thirdparty\ACT` folder.
* Execute `build.bat`.

Then you can find plugin file named `OverlayPlugin.dll` in the `Build` folder.

## How to use

* To use this plugin, add `OverlayPlugin.dll` file as ACT plugin.
* To resize overlay, drag the bottom-right corner of the overlay.
* To configure overlay, you can edit property using control panel under the "OverlayPlugin.dll" plugin tab.
* You can customize overlay display and behaviour by modifing HTML file in the `resources` folder.

## Troubleshooting

Befor using this plugin, please make sure DLL files are not blocked.

If DLL file has blocked, plugin can not load a required modules.

To check whether the file has blocked or not and unblock it, please refer http://blogs.msdn.com/b/delay/p/unblockingdownloadedfile.aspx.

## License

MIT license. See LICENSE.txt for details.
