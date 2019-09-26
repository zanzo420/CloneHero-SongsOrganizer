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
        public string DirectoryPath { get; set; }
        private INIFile IniFile { get; set; }
        private SerializableData SongData { get; set; }

        public Song(string path)
        {
            DirectoryPath = path;
        }

        public void SongInitialize()
        {
            IniFile = new INIFile(DirectoryPath + @"\song.ini");
            SongData = IniFile.Deserialize();
        }

        public void SaveSong()
        {
            IniFile.Serialize(SongData);
        }
    }
}