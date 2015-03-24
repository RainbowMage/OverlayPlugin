using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RainbowMage.OverlayPlugin.Overlays
{
    [Serializable]
    public class LabelOverlayConfig : OverlayConfigBase
    {
        private string text;
        [XmlElement("Text")]
        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                if (this.text != value)
                {
                    this.text = value;
                    if (TextChanged != null)
                    {
                        TextChanged(this, new TextChangedEventArgs(this.text));
                    }
                }
            }
        }

        private bool htmlModeEnabled;
        [XmlElement("HTMLModeEnabled")]
        public bool HtmlModeEnabled
        {
            get
            {
                return this.htmlModeEnabled;
            }
            set
            {
                if (this.htmlModeEnabled != value)
                {
                    this.htmlModeEnabled = value;
                    if (HTMLModeChanged != null)
                    {
                        HTMLModeChanged(this, new StateChangedEventArgs<bool>(this.htmlModeEnabled));
                    }
                }
            }
        }

        public event EventHandler<TextChangedEventArgs> TextChanged;
        public event EventHandler<StateChangedEventArgs<bool>> HTMLModeChanged;

        public LabelOverlayConfig(string name)
            : base(name)
        {
            this.Text = "";
            this.HtmlModeEnabled = false;
        }

        // XmlSerializer用
        private LabelOverlayConfig()
            : base(null)
        {

        }

        public override Type OverlayType
        {
            get { return typeof(LabelOverlay); }
        }
    }

    public class TextChangedEventArgs : EventArgs
    {
        public string Text { get; private set; }
        public TextChangedEventArgs(string text)
        {
            this.Text = text;
        }
    }
}
