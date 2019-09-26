using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using INIFilesReader;

namespace SongsOrganizer_WinForms
{
    public class Song
    {
        public INIFile IniFile { get; set; }
        public SerializableData SongData { get; set; }

        public Song(string path)
        {
            IniFile = new INIFile(path);
        }

        public void SongInitialize()
        {
            SongData = IniFile.Deserialize();
        }

        public void SaveSong()
        {
            IniFile.Serialize(SongData);
        }
    }
}