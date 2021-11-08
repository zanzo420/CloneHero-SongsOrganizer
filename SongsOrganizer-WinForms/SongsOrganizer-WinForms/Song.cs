using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using INIFilesReader;

namespace zCHSongManager
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
        {/*Basic Info*/
            if (SongData.Values[0].ContainsKey("artist"))
                SongAttributes.Artist = SongData.Values[0]["artist"];
            if (SongData.Values[0].ContainsKey("name"))
                SongAttributes.Name = SongData.Values[0]["name"];
            if (SongData.Values[0].ContainsKey("album"))
                SongAttributes.Album = SongData.Values[0]["album"];
            if (SongData.Values[0].ContainsKey("genre"))
                SongAttributes.Genre = SongData.Values[0]["genre"];
            if (SongData.Values[0].ContainsKey("charter"))
                SongAttributes.Charter = SongData.Values[0]["charter"];
            if (SongData.Values[0].ContainsKey("year"))
                SongAttributes.Year = SongData.Values[0]["year"];
            if (SongData.Values[0].ContainsKey("song_length"))
                SongAttributes.Length = SongData.Values[0]["song_length"];
            if (SongData.Values[0].ContainsKey("modchart"))
                SongAttributes.ModChart = SongData.Values[0]["modchart"];
         /*Difficulty Info*/
            if (SongData.Values[0].ContainsKey("diff_band"))
                SongAttributes.Diff_Band = SongData.Values[0]["diff_band"];
            if (SongData.Values[0].ContainsKey("diff_guitar"))
                SongAttributes.Diff_Guitar = SongData.Values[0]["diff_guitar"];
            if (SongData.Values[0].ContainsKey("diff_bass"))
                SongAttributes.Diff_Bass = SongData.Values[0]["diff_bass"];
            if (SongData.Values[0].ContainsKey("diff_drums"))
                SongAttributes.Diff_Drums = SongData.Values[0]["diff_drums"];
            if (SongData.Values[0].ContainsKey("diff_vocals"))
                SongAttributes.Diff_Vocals = SongData.Values[0]["diff_vocals"];
            if (SongData.Values[0].ContainsKey("diff_keys"))
                SongAttributes.Diff_Keys = SongData.Values[0]["diff_keys"];
            if (SongData.Values[0].ContainsKey("diff_guitar_coop"))
                SongAttributes.Diff_GuitarCoop = SongData.Values[0]["diff_guitar_coop"];
            if (SongData.Values[0].ContainsKey("diff_rhythm"))
                SongAttributes.Diff_Rhythm = SongData.Values[0]["diff_rhythm"];
            /*Pro Difficulties*/
            if (SongData.Values[0].ContainsKey("diff_guitar_real"))
                SongAttributes.Diff_ProGuitar = SongData.Values[0]["diff_guitar_real"];
            if (SongData.Values[0].ContainsKey("diff_bass_real"))
                SongAttributes.Diff_ProBass = SongData.Values[0]["diff_bass_real"];
            if (SongData.Values[0].ContainsKey("diff_drums_real"))
                SongAttributes.Diff_ProDrums = SongData.Values[0]["diff_drums_real"];
            if (SongData.Values[0].ContainsKey("diff_keys_real"))
                SongAttributes.Diff_ProKeys = SongData.Values[0]["diff_keys_real"];
            if (SongData.Values[0].ContainsKey("diff_vocals_harm"))
                SongAttributes.Diff_Vocals_Harm = SongData.Values[0]["diff_vocals_harm"];
            /*GuitarHero Live*/
            if (SongData.Values[0].ContainsKey("diff_guitarghl"))
                SongAttributes.Diff_GuitarGHL = SongData.Values[0]["diff_guitarghl"];
            if (SongData.Values[0].ContainsKey("diff_bassghl"))
                SongAttributes.Diff_BassGHL = SongData.Values[0]["diff_bassghl"];
        }

        public void SaveSong()
        {
            if (SongData.Values[0].ContainsKey("artist"))
                SongData.Values[0]["artist"] = SongAttributes.Artist;
            if (SongData.Values[0].ContainsKey("name"))
                SongData.Values[0]["name"] = SongAttributes.Name;
            if (SongData.Values[0].ContainsKey("album"))
                SongData.Values[0]["album"] = SongAttributes.Name;
            if (SongData.Values[0].ContainsKey("genre"))
                SongData.Values[0]["genre"] = SongAttributes.Genre;
            if (SongData.Values[0].ContainsKey("charter"))
                SongData.Values[0]["charter"] = SongAttributes.Charter;
            if (SongData.Values[0].ContainsKey("year"))
                SongData.Values[0]["year"] = SongAttributes.Year;
            if (SongData.Values[0].ContainsKey("length"))
                SongData.Values[0]["length"] = SongAttributes.Length;
            if (SongData.Values[0].ContainsKey("modchart"))
                SongData.Values[0]["modchart"] = SongAttributes.ModChart;
            if (SongData.Values[0].ContainsKey("diff_band"))
                SongData.Values[0]["diff_band"] = SongAttributes.Diff_Band;
            if (SongData.Values[0].ContainsKey("diff_guitar"))
                SongData.Values[0]["diff_guitar"] = SongAttributes.Diff_Guitar;
            if (SongData.Values[0].ContainsKey("diff_bass"))
                SongData.Values[0]["diff_bass"] = SongAttributes.Diff_Bass;
            if (SongData.Values[0].ContainsKey("diff_drums"))
                SongData.Values[0]["diff_drums"] = SongAttributes.Diff_Drums;
            if (SongData.Values[0].ContainsKey("diff_vocals"))
                SongData.Values[0]["diff_vocals"] = SongAttributes.Diff_Vocals;
            if (SongData.Values[0].ContainsKey("diff_keys"))
                SongData.Values[0]["diff_keys"] = SongAttributes.Diff_Keys;
            if (SongData.Values[0].ContainsKey("diff_rhythm"))
                SongData.Values[0]["diff_rhythm"] = SongAttributes.Diff_Rhythm;
            if (SongData.Values[0].ContainsKey("diff_guitarcoop"))
                SongData.Values[0]["diff_guitarcoop"] = SongAttributes.Diff_GuitarCoop;
            if (SongData.Values[0].ContainsKey("diff_guitar_real"))
                SongData.Values[0]["diff_guitar_real"] = SongAttributes.Diff_ProGuitar;
            if (SongData.Values[0].ContainsKey("diff_bass_real"))
                SongData.Values[0]["diff_bass_real"] = SongAttributes.Diff_ProBass;
            if (SongData.Values[0].ContainsKey("diff_drums_real"))
                SongData.Values[0]["diff_drums_real"] = SongAttributes.Diff_ProDrums;
            if (SongData.Values[0].ContainsKey("diff_vocals_harm"))
                SongData.Values[0]["diff_vocals_harm"] = SongAttributes.Diff_Vocals_Harm;
            if (SongData.Values[0].ContainsKey("diff_keys_real"))
                SongData.Values[0]["diff_keys_real"] = SongAttributes.Diff_ProKeys;
            if (SongData.Values[0].ContainsKey("diff_bassghl"))
                SongData.Values[0]["diff_bassghl"] = SongAttributes.Diff_BassGHL;
            if (SongData.Values[0].ContainsKey("diff_guitarghl"))
                SongData.Values[0]["diff_guitarghl"] = SongAttributes.Diff_GuitarGHL;

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
                case "charter":
                    if (SongAttributes.Charter != newValue)
                        HasChanged = true;
                    SongAttributes.Charter = newValue;
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
            MarkedForDeletion = true;
        }

        public void DeleteSong()
        {
            Directory.Delete(DirectoryPath, true);
        }
    }
}