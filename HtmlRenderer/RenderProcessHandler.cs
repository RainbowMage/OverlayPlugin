using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace RainbowMage.HtmlRenderer
{
    class RenderProcessHandler : CefRenderProcessHandler
    {
        private readonly BuiltinFunctionHandler builtinFunctionHandler;

        public RenderProcessHandler()
        {
            this.builtinFunctionHandler = new BuiltinFunctionHandler();
            this.builtinFunctionHandler.BroadcastMessage += (o, e) =>
            {
                Renderer.OnBroadcastMessage(o, e);
            };
            this.builtinFunctionHandler.SendMessage += (o, e) =>
            {
                Renderer.OnSendMessage(o, e);
            };
        }

        protected override bool OnProcessMessageReceived(CefBrowser browser, CefProcessId sourceProcess, CefProcessMessage message)
        {
            if (message.Name == "SetOverlayAPI")
            {
                // 対象のフレームを取得
                var frameName = message.Arguments.GetString(0);
                var frame = GetFrameByName(browser, frameName);

                // API を設定
                if (frame != null && frame.V8Context.Enter())
                {
                    var apiObject = CefV8Value.CreateObject(null);

                    var broadcastMessageFunction = CefV8Value.CreateFunction(
                        BuiltinFunctionHandler.BroadcastMessageFunctionName,
                        builtinFunctionHandler); 
                    var sendMessageFunction = CefV8Value.CreateFunction(
                         BuiltinFunctionHandler.SendMessageFunctionName,
                         builtinFunctionHandler);

                    apiObject.SetValue(
                        BuiltinFunctionHandler.BroadcastMessageFunctionName,
                        broadcastMessageFunction,
                        CefV8PropertyAttribute.None);
                    apiObject.SetValue(
                        BuiltinFunctionHandler.SendMessageFunctionName,
                        sendMessageFunction,
                        CefV8PropertyAttribute.None);

                    frame.V8Context.GetGlobal().SetValue("OverlayPluginApi", apiObject, CefV8PropertyAttribute.None);

                    frame.V8Context.Exit();
                }
                return true;
            }

            return base.OnProcessMessageReceived(browser, sourceProcess, message);
        }

        private CefFrame GetFrameByName(CefBrowser browser, string frameName)
        {
            CefFrame frame = null;
            if (frameName == null)
            {
                frame = browser.GetMainFrame();
            }
            else
            {
                frame = browser.GetFrame(frameName);
            }

            return frame;
        }
    }
}
