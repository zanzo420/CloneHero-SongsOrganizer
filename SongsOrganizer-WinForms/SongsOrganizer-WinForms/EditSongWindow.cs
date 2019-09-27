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
    public partial class EditSongWindow : Form
    {
        private string name;
        private string artist;
        private string directory;
        public string curName { get { return nameTextBox.Text; } }
        public string curArtist { get { return artistTextBox.Text; } }


        public EditSongWindow(string n, string a, string d)
        {
            name = n;
            artist = a;
            directory = d;

            InitializeComponent();

            var files = Directory.EnumerateFiles(directory);
            foreach (string f in files)
            {
                if (f.EndsWith("album.png"))
                {
                    albumPictureBox.Image = Image.FromFile(directory + @"\album.png");
                    break;
                }
                if (f.EndsWith("album.Png"))
                {
                    albumPictureBox.Image = Image.FromFile(directory + @"\album.Png");
                    break;
                }
                if (f.EndsWith("album.pNg"))
                {
                    albumPictureBox.Image = Image.FromFile(directory + @"\album.pNg");
                    break;
                }
                if (f.EndsWith("album.pnG"))
                {
                    albumPictureBox.Image = Image.FromFile(directory + @"\album.pnG");
                    break;
                }
                if (f.EndsWith("album.PNg"))
                {
                    albumPictureBox.Image = Image.FromFile(directory + @"\album.PNg");
                    break;
                }
                if (f.EndsWith("album.pNG"))
                {
                    albumPictureBox.Image = Image.FromFile(directory + @"\album.pNG");
                    break;
                }
                if (f.EndsWith("album.PnG"))
                {
                    albumPictureBox.Image = Image.FromFile(directory + @"\album.PnG");
                    break;
                }
                if (f.EndsWith("album.PNG"))
                {
                    albumPictureBox.Image = Image.FromFile(directory + @"\album.PNG");
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
        }

        private void revertBtn_Click(object sender, EventArgs e)
        {
            SetBaseValues();
        }
    }
}
