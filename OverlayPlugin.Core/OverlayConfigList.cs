using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RainbowMage.OverlayPlugin
{
    /// <summary>
    /// XmlSerializer でシリアライズ可能な IOverlayConfig のコレクション。
    /// </summary>
    [Serializable]
    public class OverlayConfigList : Collection<IOverlayConfig>, IXmlSerializable
    {
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            if (reader.IsEmptyElement)
            {
                return;
            }

            reader.ReadToDescendant("Overlay");
            do
            {
                string typeName = reader.GetAttribute("Type");

                reader.Read();

                var type = GetType(typeName);

                if (type != null)
                {
                    var serializer = new XmlSerializer(type);
                    var config = (IOverlayConfig)serializer.Deserialize(reader);
                    this.Add(config);
                }

            } while (reader.ReadToNextSibling("Overlay"));

            reader.ReadEndElement();
        }

        private Type GetType(string fullName)
        {
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                var type = asm.GetType(fullName, false);
                if (type != null)
                {
                    return type;
                }
            }
            return null;
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            foreach (var config in this)
            {
                writer.WriteStartElement("Overlay");
                writer.WriteAttributeString("Type", config.GetType().FullName);
                var serializer = new XmlSerializer(config.GetType());
                serializer.Serialize(writer, config);
                writer.WriteEndElement();
            }
        }

    }
}
