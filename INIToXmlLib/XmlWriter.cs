using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace INIToXmlLib
{
    class XmlWriter : IDisposable
    {
        private XmlDocument xmlDocument;
        private bool isDisposed = false;

        public XmlWriter()
        {
            xmlDocument = new XmlDocument();
        }

        public void WriteToXml(string output, List<Section> SectionList)
        {

            XmlElement PrinterList = xmlDocument.CreateElement("PrinterList");
            xmlDocument.AppendChild(PrinterList);

            foreach (Section section in SectionList)
            {
                XmlElement PrinterInfo = xmlDocument.CreateElement("PrinterInfo");
                PrinterInfo.SetAttribute("Name", section.GetName());
                PrinterList.AppendChild(PrinterInfo);
                
                foreach (SectionKey sectionKey in section.GetSectionKeyList())
                {
                    if (sectionKey.GetKey().Equals("Device"))
                    {
                        string[] Key = sectionKey.GetValue().Split(',');

                        AddElement("PrinterName", Key[0], PrinterInfo);
                        AddElement("DriverName", Key[1], PrinterInfo);
                        AddElement("DeviceName", Key[0], PrinterInfo);
                        AddElement("PortName", Key[2], PrinterInfo);
                    }
                    else
                        AddElement(sectionKey.GetKey().Replace(" ", ""), sectionKey.GetValue(), PrinterInfo);
                }
            }
            xmlDocument.Save(output);
        }

        private  void AddElement(string key,string value, XmlElement XE)
        {
            XmlElement xmlElement = xmlDocument.CreateElement(key);
            xmlElement.InnerText = value;
            XE.AppendChild(xmlElement);
        }

        protected virtual void Dispose(bool Diposing)
        {
            if (isDisposed)
                return;

            if (Diposing)
            {
            }

            isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
