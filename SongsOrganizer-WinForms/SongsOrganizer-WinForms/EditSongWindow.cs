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

namespace zCHSongManager
{
    public partial class EditSongWindow : Form
    {
        private string name;
        private string artist;
        private string album;
        private string genre;
        private string charter;
        private string year;
        private string length;
        private string directory;
        public string curName { get { return nameTextBox.Text; } }
        public string curArtist { get { return artistTextBox.Text; } }
        public string curAlbum { get { return albumTextBox.Text; } }
        public string curGenre { get { return genreTextBox.Text; } }
        public string curCharter { get { return charterTextBox.Text; } }
        public string curYear { get { return yearTextBox.Text; } }
        public string curLength { get { return lengthTextBox.Text; } }


        public EditSongWindow(string n, string a, string d, string al, string g, string c, string y, string l)
        {
            name = n;
            artist = a;
            album = al;
            genre = g;
            charter = c;
            year = y;
            length = l;
            directory = d;

            InitializeComponent();

            var files = Directory.EnumerateFiles(directory);
            foreach (string f in files)
            {
				if (f.Substring(0, f.Length - 4).EndsWith("album"))
				{
					albumPictureBox.Image = Image.FromFile(f);
					break;
				}
            }

            directoryLabel.Text = directory;
            SetBaseValues();
        }

        private void SetBaseValues()
        {            
            nameTextBox.Text = name;
            artistTextBox.Text = artist;
            albumTextBox.Text = album;
            genreTextBox.Text = genre;
            charterTextBox.Text = charter;
            yearTextBox.Text = year;
            lengthTextBox.Text = length;
        }

        private void revertBtn_Click(object sender, EventArgs e)
        {
            SetBaseValues();
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
