using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowMage.OverlayPlugin
{
    public class PluginLoader : IActPluginV1
    {
        PluginMain pluginMain;
        Logger logger;
        AssemblyResolver asmResolver;
        string pluginDirectory;

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            pluginDirectory = GetPluginDirectory();

            var directories = new List<string>();
            directories.Add(pluginDirectory);
            directories.Add(Path.Combine(pluginDirectory, "addon"));
            asmResolver = new AssemblyResolver(directories);

            Initialize(pluginScreenSpace, pluginStatusText);
        }

        // AssemblyResolver でカスタムリゾルバを追加する前に PluginMain が解決されることを防ぐために、
        // インライン展開を禁止したメソッドに処理を分離
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Initialize(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            logger = new Logger();
            asmResolver.ExceptionOccured += (o, e) => logger.Log(LogLevel.Error, "AssemblyResolver: Error: {0}", e.Exception);
            asmResolver.AssemblyLoaded += (o, e) => logger.Log(LogLevel.Debug, "AssemblyResolver: Loaded: {0}", e.LoadedAssembly.FullName);
            pluginMain = new PluginMain(pluginDirectory, logger);
            pluginMain.InitPlugin(pluginScreenSpace, pluginStatusText);
        }

        public void DeInitPlugin()
        {
            pluginMain.DeInitPlugin();
            asmResolver.Dispose();
        }

        private string GetPluginDirectory()
        {
            // ACT のプラグインリストからパスを取得する
            // Assembly.CodeBase からはパスを取得できない
            var plugin = ActGlobals.oFormActMain.ActPlugins.Where(x => x.pluginObj == this).FirstOrDefault();
            if (plugin != null)
            {
                return System.IO.Path.GetDirectoryName(plugin.pluginFile.FullName);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
