using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INIToXmlLib
{
    public class Section
    {
        private string Name = "";
        private List<SectionKey> SectionKeyList;

        public Section(string name)
        {
            this.Name = name;
            SectionKeyList = new List<SectionKey>();
        }

        public void AddSectionKey(string key, string value)
        {
            SectionKeyList.Add(new SectionKey(key, value));
        }

        public List<SectionKey> GetSectionKeyList()
        {
            return SectionKeyList;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

    }
}
