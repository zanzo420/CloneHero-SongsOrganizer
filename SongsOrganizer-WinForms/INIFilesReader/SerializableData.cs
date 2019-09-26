using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INIFilesReader
{
    public class SerializableData
    {
        public List<string> Headings { get; set; }
        public List<Dictionary<string, string>> Values { get; set; }

        public SerializableData()
        {
            Headings = new List<string>();
            Values = new List<Dictionary<string, string>>();
        }
    }
}