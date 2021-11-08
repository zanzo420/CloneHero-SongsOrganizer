using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCHSongManager
{
    public class GridViewSongData
    {
        public int Index { get; set; }
        public string Directory { get; set; }
        public string Artist { get; set; }
        public string Name { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public string Charter { get; set; }
        public string Year { get; set; }
        public string ModChart { get; set; }
        public string Length { get; set; }
        /*Difficulties*/
        public string Diff_Band { get; set; }
        public string Diff_Guitar { get; set; }
        public string Diff_Bass { get; set; }
        public string Diff_Drums { get; set; }
        public string Diff_Vocals { get; set; }
        public string Diff_Keys { get; set; }
        public string Diff_GuitarCoop { get; set; }
        public string Diff_Rhythm { get; set; }
        /*Pro Difficulties*/
        public string Diff_ProGuitar { get; set; }
        public string Diff_ProBass { get; set; }
        public string Diff_ProDrums { get; set; }
        public string Diff_Vocals_Harm { get; set; }
        public string Diff_ProKeys { get; set; }
        /*Guitar Hero Live*/
        public string Diff_GuitarGHL { get; set; }
        public string Diff_BassGHL { get; set; }

    }
}
