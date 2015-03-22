using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace RainbowMage.HtmlRenderer
{
    class MenuHandler : CefContextMenuHandler
    {
        protected override void OnBeforeContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams state, CefMenuModel model)
        {
            // デフォルトのコンテキストメニューを無効化
            model.Clear();
        }
    }
}
