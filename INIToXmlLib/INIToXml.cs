using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace INIToXmlLib
{
    public class INIToXml : IDisposable
    {
        private bool isDisposed = false;
        private string input = "";
        private string output = "";
        private List<Section> SectionList;

        public INIToXml(string input, string output)
        {
            this.input = input;
            this.output = output;
            SectionList = new List<Section>();
        }

        public void INIStreamReader()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(input))
                {
                    int streamReaderResult = -1;
                    Section section = null;
                    
                    do
                    {
                        string str = streamReader.ReadLine();
                        if (Regex.Match(str, @"^\[.*\]").Success)
                        {
                            if (section != null)
                                SectionList.Add(section);
                            section = new Section(str.Substring(1, str.Length-2));
                        }
                        else if (section != null)
                        {
                            string[] Key_Value = str.Split('=');
                            section.AddSectionKey(Key_Value[0], Key_Value[1]);
                        }
                        streamReaderResult = streamReader.Peek();
                    } while (streamReaderResult != -1);
                    SectionList.Add(section);
                }
                //PrintSection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void INISwap()
        {
            XmlWriter xmlWriter = new XmlWriter();
            xmlWriter.WriteToXml(output, SectionList);
            xmlWriter.Dispose();
        }

        public void PrintSection()
        {
            foreach (Section section in SectionList)
            {
                Console.WriteLine("Section Name : " + section.GetName());
                foreach (SectionKey sectionKey in section.GetSectionKeyList())
                {
                    Console.WriteLine("Key : " + sectionKey.GetKey() + ", Value : " + sectionKey.GetValue());
                }
            }
        }

        public List<Section> GetSectionList()
        {
            return SectionList;
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
