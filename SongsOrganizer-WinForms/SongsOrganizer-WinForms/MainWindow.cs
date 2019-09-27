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
        private int previousColumnIndex = -1;
        private bool sortAscending = true;

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
                }
            }
        }

        private void ReloadSongsGridView()
        {
            songs.Clear();
            GetSongs();

            Console.WriteLine("Found: " + songs.Count + " songs");
            int i = 0;
            foreach (Song s in songs)
            {
                s.SongInitialize();
                Console.WriteLine("Initialized " + ++i + "/" + songs.Count);
            }

            var songsList = songs.Select(s => new GridViewSongData{
                Directory = s.DirectoryPath,
                Artist = s.SongAttributes.Artist,
                Name = s.SongAttributes.Name
            }).ToList();
            songsGrid.DataSource = songsList;

            foreach (DataGridViewColumn column in songsGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            MessageBox.Show("Found and initialized " + songs.Count + " songs");
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
            MessageBox.Show("Reverted changes for " + n + " songs");
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
            MessageBox.Show("Saved changes for " + n + " songs");
            Console.WriteLine("Saved changes for " + n + " songs");
        }

        private void songsGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == previousColumnIndex)
                sortAscending = !sortAscending;
            else
                sortAscending = true;

            previousColumnIndex = e.ColumnIndex;

            songsGrid.DataSource = SortSongs(e.ColumnIndex);
        }

        private List<GridViewSongData> SortSongs(int columnIndex)
        {
            List<GridViewSongData> list = (List<GridViewSongData>)songsGrid.DataSource;
            if (sortAscending)
                return (list.OrderBy(s => s.GetType().GetProperty("Name").GetValue(s))).OrderBy(s => s.GetType().GetProperty(songsGrid.Columns[columnIndex].Name).GetValue(s)).ToList();
            else
                return (list.OrderBy(s => s.GetType().GetProperty("Name").GetValue(s))).OrderByDescending(s => s.GetType().GetProperty(songsGrid.Columns[columnIndex].Name).GetValue(s)).ToList();
        }
    }
}
