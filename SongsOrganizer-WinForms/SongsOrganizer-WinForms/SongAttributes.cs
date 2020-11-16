using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsOrganizer_WinForms
{
    public class SongAttributes
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }

        public SongAttributes()
        {
            Name = "NO_SONG_NAME";
            Artist = "NO_ARTIST";
            Album = "NO_ALBUM";
        }
    }
}
