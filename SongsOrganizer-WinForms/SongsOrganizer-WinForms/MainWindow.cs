using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
		private List<Song> songs = new List<Song>();
        private int previousColumnIndex = 2;
        private bool sortAscending = true;

        public MainWindow()
        {
            InitializeComponent();

			while (!Directory.Exists(Settings.SongsDirectory))
			{
				using (var fbd = new FolderBrowserDialog())
				{
					fbd.Description = "Choose songs directory";

					DialogResult result = fbd.ShowDialog();

					if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
					{
						Settings.SongsDirectory = fbd.SelectedPath;
					}
				}
			}

			ReloadSongsGridView();
            CheckChanges();
        }

        private void GetSongs(string directoryPath = null)
        {
            if (directoryPath == null)
                directoryPath = Settings.SongsDirectory;

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
                    fbd.SelectedPath = Settings.SongsDirectory;

                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        Settings.SongsDirectory = fbd.SelectedPath;
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

            CheckChanges();
        }

        private void RefreshSongsGridView(bool newDirectory = false)
        {
            List<int> indexes = new List<int>();
            foreach (DataGridViewRow r in songsGrid.SelectedRows)
            {
                indexes.Add((int)r.Cells["Index"].Value);
            }
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
            if (indexes.Count > 0 && !newDirectory)
            {
                foreach (DataGridViewRow r in songsGrid.Rows)
                {
                    if (indexes.Contains((int)r.Cells["Index"].Value))
                    {
                        r.Selected = true;
                        songsGrid.CurrentCell = r.Cells[songsGrid.Columns.Count - 1];
                    }
                }
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

            CheckChanges();
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

            CheckChanges();
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

            int ind = (int)songsGrid.Rows[e.RowIndex].Cells["Index"].Value;
            EditSong(ind);
        }

        private void EditSong(int ind)
        {
            Song tSong = songs[ind];
            using (var esw = new EditSongWindow(tSong.SongAttributes.Name, tSong.SongAttributes.Artist, tSong.DirectoryPath))
            {
                DialogResult result = esw.ShowDialog();

                if (result == DialogResult.OK)
                {
                    tSong.ChangeValue("name", esw.curName.Trim());
                    tSong.ChangeValue("artist", esw.curArtist.Trim());
                }
            }
            CheckChanges();
            RefreshSongsGridView();
        }

        private void CheckChanges()
        {
            bool changed = false;
            bool marked = false;
            foreach (Song s in songs)
            {
                if (s.HasChanged)
                    changed = true;
                if (s.MarkedForDeletion)
                    marked = true;
                if (changed && marked)
                    break;
            }

            saveChangesToolStripMenuItem.Enabled = false;
            revertChangesToolStripMenuItem.Enabled = false;
            deleteMarkedToolStripMenuItem.Enabled = false;
            if (changed)
            {
                saveChangesToolStripMenuItem.Enabled = true;
                revertChangesToolStripMenuItem.Enabled = true;
            }
            if (marked)
            {
                deleteMarkedToolStripMenuItem.Enabled = true;
            }
        }

        private void songsGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (songs[(int)songsGrid.Rows[e.RowIndex].Cells["Index"].Value].HasChanged)
            {
                songsGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                songsGrid.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Green;
            }
            if (songs[(int)songsGrid.Rows[e.RowIndex].Cells["Index"].Value].MarkedForDeletion)
            {
                songsGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                songsGrid.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.DarkRed;
            }
        }

        private void deleteMarkedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = 0;
            for (int i = 0; i < songs.Count; i++)
            {
                if (songs[i].MarkedForDeletion)
                {
                    DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete: {songs[i].SongAttributes.Artist} - {songs[i].SongAttributes.Name}?", "Delete?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        songs[i].DeleteSong();
                        songs.RemoveAt(i);
                        i--;
                        n++;
                    }
                }
            }
            if (n > 0)
            {
                MessageBox.Show("Deleted " + n + " songs");
                Console.WriteLine("Deleted " + n + " songs");
                ReloadSongsGridView();
            }
        }

        private void songsGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                if (!c.Selected)
                {
                    c.DataGridView.ClearSelection();
                    c.DataGridView.CurrentCell = c;
                    c.Selected = true;
                }
            }
        }

        private void editSongContextMenuItem_Click(object sender, EventArgs e)
        {
            if (songsGrid.SelectedRows.Count == 0)
                return;

            int ind = (int)songsGrid.Rows[songsGrid.CurrentCell.RowIndex].Cells["Index"].Value;
            EditSong(ind);
        }

        private void markForDeletionContextMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in songsGrid.SelectedRows)
            {
                songs[(int)r.Cells["Index"].Value].MarkForDeletion();
            }
            CheckChanges();
            RefreshSongsGridView();
        }

        private void revertChangesContextMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in songsGrid.SelectedRows)
            {
                songs[(int)r.Cells["Index"].Value].RevertChanges();
            }
            CheckChanges();
            RefreshSongsGridView();
        }

        private void songsGrid_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            if (songsGrid.SelectedRows.Count == 1)
            {
                editSongContextMenuItem.Visible = true;
                openSongDirectoryContextMenuItem.Visible = true;
                openSonginiFileContextMenuItem.Visible = true;
                contextMenuSeparator.Visible = true;
                markForDeletionContextMenuItem.Visible = true;
                revertChangesContextMenuItem.Visible = true;
            }
            else
            {
                editSongContextMenuItem.Visible = false;
                openSongDirectoryContextMenuItem.Visible = false;
                openSonginiFileContextMenuItem.Visible = false;
                contextMenuSeparator.Visible = false;
                markForDeletionContextMenuItem.Visible = true;
                revertChangesContextMenuItem.Visible = true;
            }
        }

        private void openSongDirectoryContextMenuItem_Click(object sender, EventArgs e)
        {
            if (songsGrid.SelectedRows.Count == 0)
                return;

            Process.Start(songs[(int)songsGrid.Rows[songsGrid.CurrentCell.RowIndex].Cells["Index"].Value].DirectoryPath);
        }

        private void openSonginiFileContextMenuItem_Click(object sender, EventArgs e)
        {
            if (songsGrid.SelectedRows.Count == 0)
                return;

            Process.Start(songs[(int)songsGrid.Rows[songsGrid.CurrentCell.RowIndex].Cells["Index"].Value].DirectoryPath + @"\song.ini");
        }
    }
}