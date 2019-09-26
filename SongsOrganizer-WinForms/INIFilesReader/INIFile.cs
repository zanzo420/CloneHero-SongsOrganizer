using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INIFilesReader
{
    public class INIFile
    {
        private string Path;

        public INIFile(string nPath)
        {
            Path = nPath;
        }

        public SerializableData Deserialize()
        {
            return INISerializer.Deserialize(Path);
        }

        public void Serialize(SerializableData serializableData)
        {
            INISerializer.Serialize(Path, serializableData);
        }
    }
}
