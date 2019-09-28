using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using INIFilesReader;

namespace SongsOrganizer_WinForms
{
    public class Song
    {
        public int Index { get; set; }
        public string DirectoryPath { get; set; }
        public INIFile IniFile { get; set; }
        public SerializableData SongData { get; set; }
        public bool HasChanged { get; set; }
        public bool MarkedForDeletion { get; set; }
        public SongAttributes SongAttributes { get; }

        public Song(string path, int ind)
        {
            DirectoryPath = path;
            HasChanged = false;
            MarkedForDeletion = false;
            SongAttributes = new SongAttributes();
            Index = ind;
        }

        public void SongInitialize()
        {
            IniFile = new INIFile(DirectoryPath + @"\song.ini");
            SongData = IniFile.Deserialize();

            InitializeSongAttributes();
        }

        private void InitializeSongAttributes()
        {
            if (SongData.Values[0].ContainsKey("artist"))
                SongAttributes.Artist = SongData.Values[0]["artist"];
            if (SongData.Values[0].ContainsKey("name"))
                SongAttributes.Name = SongData.Values[0]["name"];
        }

        public void SaveSong()
        {
            if (SongData.Values[0].ContainsKey("artist"))
                SongData.Values[0]["artist"] = SongAttributes.Artist;
            if (SongData.Values[0].ContainsKey("name"))
                SongData.Values[0]["name"] = SongAttributes.Name;

            IniFile.Serialize(SongData);
        }

        public void ChangeValue(string key, string newValue)
        {
            switch (key)
            {
                case "name":
                    if (SongAttributes.Name != newValue)
                        HasChanged = true;
                    SongAttributes.Name = newValue;
                    break;
                case "artist":
                    if (SongAttributes.Artist != newValue)
                        HasChanged = true;
                    SongAttributes.Artist = newValue;
                    break;
            }
        }

        public void RevertChanges()
        {
            InitializeSongAttributes();
            HasChanged = false;
            MarkedForDeletion = false;
        }

        public void MarkForDeletion()
        {
            MarkedForDeletion = !MarkedForDeletion;
        }

        public void DeleteSong()
        {
            Directory.Delete(DirectoryPath, true);
        }
    }
}