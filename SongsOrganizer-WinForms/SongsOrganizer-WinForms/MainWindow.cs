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
        private string songsDirectory = @"E:\Gry\Clone Hero\Songs";
        private List<Song> songs = new List<Song>();

        public MainWindow()
        {
            InitializeComponent();

            ReloadSongsGridView();
        }

        private void GetSongs(string directoryPath = null)
        {
            if (directoryPath == null)
                directoryPath = songsDirectory;

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

        private void InitializeSongsGrid()
        {
            Console.WriteLine("Found: " + songs.Count + " songs");
            int i = 0;
            foreach (Song s in songs)
            {
                s.SongInitialize();
                Console.WriteLine("Initialized " + ++i + "/" + songs.Count);
            }

            var songsList = songs.Select(s => new {
                Directory = s.DirectoryPath,
                Artist = s.SongAttributes.Artist,
                Name = s.SongAttributes.Name
            }).ToList();
            songsGrid.DataSource = songsList;
        }

        private void chooseDirectoryMenuItem_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Choose songs directory";
                fbd.SelectedPath = songsDirectory;

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    songsDirectory = fbd.SelectedPath;
                    ReloadSongsGridView();

                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }

        private void ReloadSongsGridView()
        {
            songs.Clear();
            GetSongs();
            InitializeSongsGrid();
        }

        private void reloadSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadSongsGridView();
        }

        private void revertChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = 0;
            foreach (Song s in songs)
            {
                if (s.HasChanged)
                {
                    s.RevertChanges();
                    n++;
                }
            }
            Console.WriteLine("Reverted changes for " + n + " songs");
        }

        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = 0;
            foreach (Song s in songs)
            {
                if (s.HasChanged)
                {
                    s.SaveSong();
                    n++;
                }
            }
            Console.WriteLine("Saved changes for " + n + " songs");
        }
    }
}
