using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongsOrganizer_WinForms
{
    public partial class MainWindow : Form
    {
        private readonly string songsDirectory = @"E:\Gry\Clone Hero\Songs";
        private List<Song> songs = new List<Song>();

        public MainWindow()
        {
            GetSongs(songsDirectory);
            Console.WriteLine("Found: " + songs.Count + " songs");
            int i = 0;
            foreach (Song s in songs)
            {
                s.SongInitialize();
                Console.WriteLine("Initialized " + ++i + "/" + songs.Count);
            }

            InitializeComponent();

            var songsList = songs.Select(s => new {
                Directory = s.DirectoryPath,
                INI_Path = s.IniFile.Path
            }).ToList();
            songsGrid.DataSource = songsList;
        }

        private void GetSongs(string directoryPath)
        {
            List<string> files = new List<string>(Directory.EnumerateFiles(directoryPath));
            foreach (string f in files)
            {
                if (f.EndsWith("song.ini"))
                {
                    songs.Add(new Song(directoryPath));
                    return;
                }
            }
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(directoryPath));
            foreach (string d in dirs)
            {
                GetSongs(d);
            }
        }
    }
}
