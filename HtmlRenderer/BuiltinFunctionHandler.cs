using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace RainbowMage.HtmlRenderer
{
    class BuiltinFunctionHandler : CefV8Handler 
    {
        public event EventHandler<BroadcastMessageEventArgs> BroadcastMessage;
        public event EventHandler<SendMessageEventArgs> SendMessage;

        public const string BroadcastMessageFunctionName = "broadcastMessage";
        public const string SendMessageFunctionName = "sendMessage";

        protected override bool Execute(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
        {
            exception = "";
            returnValue = CefV8Value.CreateUndefined();

            if (name == BroadcastMessageFunctionName)
            {
                if (arguments.Length > 0)
                {
                    if (BroadcastMessage != null)
                    {
                        BroadcastMessage(obj, new BroadcastMessageEventArgs(arguments[0].GetStringValue()));
                    }
                }
                else
                {
                    exception = "Invalid argument count.";
                }

                return true;
            }
            else if (name == SendMessageFunctionName)
            {
                if (arguments.Length > 1)
                {
                    if (SendMessage != null)
                    {
                        SendMessage(obj, new SendMessageEventArgs(arguments[0].GetStringValue(), arguments[1].GetStringValue()));
                    }
                }
                else
                {
                    exception = "Invalid argument count.";
                }

                return true;
            }

            return false;
        }
    }

    public class BroadcastMessageEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public BroadcastMessageEventArgs(string message)
        {
            this.Message = message;
        }
    }

    public class SendMessageEventArgs : EventArgs
    {
        public string Target { get; private set; }
        public string Message { get; private set; }

        public SendMessageEventArgs(string target, string message)
        {
            this.Target = target;
            this.Message = message;
        }
    }
}
