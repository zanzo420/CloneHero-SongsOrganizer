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
        private int previousColumnIndex = 2;
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
                    songs.Add(new Song(directoryPath, songs.Count));
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
            int n = 0;
            foreach (Song s in songs)
            {
                if (s.HasChanged)
                {
                    n++;
                }
            }

            if (n > 0)
                MessageBox.Show(n + " songs has been changed, revert changes or save them before reloading");
            else
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

            RefreshSongsGridView(true);

            MessageBox.Show("Found and initialized " + songs.Count + " songs");
        }

        private void RefreshSongsGridView(bool newDirectory = false)
        {
            int ind = -1;
            if (songsGrid.SelectedRows.Count > 0)
                ind = songsGrid.SelectedRows[0].Index;
            songsGrid.DataSource = null;

            var songsList = songs.Select(s => new GridViewSongData
            {
                Index = s.Index,
                Directory = s.DirectoryPath,
                Artist = s.SongAttributes.Artist,
                Name = s.SongAttributes.Name
            }).ToList();
            songsGrid.DataSource = songsList;
            songsGrid.DataSource = SortSongs(previousColumnIndex);

            songsGrid.Columns["Index"].Visible = false;
            songsGrid.Columns["Directory"].Visible = false;

            songsGrid.ClearSelection();
            if (ind != -1 && !newDirectory)
            {
                songsGrid.Rows[ind].Selected = true;
                songsGrid.CurrentCell = songsGrid.Rows[ind].Cells[songsGrid.Columns.Count - 1];
            }
        }

        private void reloadSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = 0;
            foreach (Song s in songs)
            {
                if (s.HasChanged)
                {
                    n++;
                }
            }

            if (n > 0)
                MessageBox.Show(n + " songs has been changed, revert changes or save them before reloading");
            else
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
            RefreshSongsGridView();
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

        private void songsGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Song tSong = songs[(int)songsGrid.Rows[e.RowIndex].Cells["Index"].Value];
            using (var esw = new EditSongWindow(tSong.SongAttributes.Name, tSong.SongAttributes.Artist, tSong.DirectoryPath))
            {
                DialogResult result = esw.ShowDialog();

                if (result == DialogResult.OK)
                {
                    tSong.ChangeValue("name", esw.curName.Trim());
                    tSong.ChangeValue("artist", esw.curArtist.Trim());
                }
            }
            RefreshSongsGridView();
        }
    }
}