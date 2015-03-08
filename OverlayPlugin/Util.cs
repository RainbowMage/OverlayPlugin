using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RainbowMage.OverlayPlugin
{
    internal static class Util
    {
        public static string CleanUpString(string str)
        {
            return str
                .Replace("\"", "\\\"")
                .Replace("'", "\\'")
                .Replace("\r", "\\r")
                .Replace("\n", "\\n")
                .Replace("\t", "\\t")
                .Replace(double.NaN.ToString(), "---");
        }

        public static bool IsOnScreen(Form form)
        {
            var screens = Screen.AllScreens;
            foreach (Screen screen in screens)
            {
                var formRectangle = new Rectangle(form.Left, form.Top, form.Width, form.Height);

                // 少しでもスクリーンと被っていればセーフ
                if (screen.WorkingArea.IntersectsWith(formRectangle))
                {
                    return true;
                }
            }

            return false;
        }

        public static void HidePreview(System.Windows.Forms.Form form)
        {
            int ex = NativeMethods.GetWindowLong(form.Handle, NativeMethods.GWL_EXSTYLE);
            ex |= NativeMethods.WS_EX_TOOLWINDOW;
            NativeMethods.SetWindowLongA(form.Handle, NativeMethods.GWL_EXSTYLE, (IntPtr)ex);
        }

        //Generates human readable keypress string
        //人間が読めるキー押下文字列を生成します
        public static string GetHotkeyString(Keys Modifier, Keys key, String defaultText = "")
        {
            StringBuilder sbKeys = new StringBuilder();
            if ((Modifier & Keys.Shift) == Keys.Shift)
            {
                sbKeys.Append("Shift + ");
            }
            if ((Modifier & Keys.Control) == Keys.Control)
            {
                sbKeys.Append("Ctrl + ");
            }
            if ((Modifier & Keys.Alt) == Keys.Alt)
            {
                sbKeys.Append("Alt + ");
            }
            if ((Modifier & Keys.LWin) == Keys.LWin || (Modifier & Keys.RWin) == Keys.RWin)
            {
                sbKeys.Append("Win + ");
            }
            sbKeys.Append(Enum.ToObject(typeof(Keys), key).ToString());
            return sbKeys.ToString();
        }



        //Removes stray references to Left/Right shifts, etc and modifications of the actual key value caused by bitwise operations
        //ビット単位の操作に起因する左/右シフト、などと実際のキー値の変更に浮遊の参照を削除します。
        public static Keys RemoveModifiers(Keys KeyCode, Keys Modifiers)
        {
            var key = KeyCode;
            var modifiers = new List<Keys>() { Keys.ControlKey, Keys.LControlKey, Keys.Alt, Keys.ShiftKey, Keys.Shift, Keys.LShiftKey, Keys.RShiftKey, Keys.Control, Keys.LWin, Keys.RWin };
            foreach (var mod in modifiers)
            {
                if (key.HasFlag(mod))
                {
                    if (key == mod)
                        key &= ~mod;
                }
            }
            return key;
        }
    }
}
