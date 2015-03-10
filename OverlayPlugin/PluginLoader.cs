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
        AssemblyResolver asmResolver;
        string pluginDirectory;

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            pluginDirectory = GetPluginDirectory();
            asmResolver = new AssemblyResolver(pluginDirectory);
            Initialize(pluginScreenSpace, pluginStatusText);
        }

        // AssemblyResolver でカスタムリゾルバを追加する前に PluginMain が解決されることを防ぐために、
        // インライン展開を禁止したメソッドに処理を分離
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Initialize(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            pluginMain = new PluginMain(pluginDirectory);
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
