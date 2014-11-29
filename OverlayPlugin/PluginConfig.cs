using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RainbowMage.OverlayPlugin
{
    [Serializable]
    public class PluginConfig
    {
        public bool IsHidden { get; set; }
        public Point OverlayPosition { get; set; }
        public Size OverlaySize { get; set; }
        public string Url { get; set; }

        public PluginConfig()
        {
            this.IsHidden = false;
            this.OverlayPosition = new Point(20, 20);
            this.OverlaySize = new Size(300, 300);
            this.Url = "";
        }

        public void SaveXml(string path)
        {
            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PluginConfig));
                serializer.Serialize(stream, this);
            }
        }

        public static PluginConfig LoadXml(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Specified file is not exists.", path);
            }

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PluginConfig));
                var result = (PluginConfig)serializer.Deserialize(stream);
                return result;
            }
        }
    }
}
