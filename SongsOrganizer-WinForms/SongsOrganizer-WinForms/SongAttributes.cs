using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCHSongManager
{
    public class SongAttributes
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public string Charter { get; set; }
        public string Year { get; set; }
        public string Playlist { get; set; }
        public string Lyrics { get; set; }
        public string ModChart { get; set; }
        public string Length { get; set; }
        public string ChartsAvailable { get; set; }
        public string Diff_BassGHL { get; set; }
        public string Diff_GuitarGHL { get; internal set; }
        public string Diff_Band { get; internal set; }
        public string Diff_Guitar { get; internal set; }
        public string Diff_Bass { get; internal set; }
        public string Diff_Drums { get; internal set; }
        public string Diff_Vocals { get; internal set; }
        public string Diff_Keys { get; internal set; }
        public string Diff_GuitarCoop { get; internal set; }
        public string Diff_Rhythm { get; internal set; }
        public string Diff_ProGuitar { get; internal set; }
        public string Diff_ProBass { get; internal set; }
        public string Diff_ProDrums { get; internal set; }
        public string Diff_ProKeys { get; internal set; }
        public string Diff_Vocals_Harm { get; internal set; }

        public SongAttributes()
        {
            Name = "NO_SONG_NAME";
            Artist = "NO_ARTIST";
            Album = "NO_ALBUM";
            Genre = "NO_GENRE";
            Charter = "NO_CHARTER";
            Year = "NO_YEAR";
            Playlist = "NO_PLAYLIST";
            Lyrics = "NO_LYRICS";
            ModChart = "NO_MODCHART";
            Length = "NO_LENGTH";
            ChartsAvailable = "NO_CHARTSAVAILABLE";
        }
    }
}
