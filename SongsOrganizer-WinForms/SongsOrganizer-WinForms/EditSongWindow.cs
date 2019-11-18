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
        }

        private void revertBtn_Click(object sender, EventArgs e)
        {
            SetBaseValues();
        }
    }
}
