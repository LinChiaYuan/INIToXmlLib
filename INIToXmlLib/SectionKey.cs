using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INIToXmlLib
{
    public class SectionKey
    {
        private string Key = "";
        private string Value = "";

        public SectionKey(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string GetKey()
        {
            return Key;
        }

        public string GetValue()
        {
            return Value;
        }

        public void SetKey(string key)
        {
            Key = key;
        }

        public void SetValue(string value)
        {
            Value = value;
        }
    }
}
