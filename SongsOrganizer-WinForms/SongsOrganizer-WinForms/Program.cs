using INIFilesReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongsOrganizer_WinForms
{
    class Program
    {
        static readonly string songsDirectory = @"E:\Gry\Clone Hero\Songs";
        static List<Song> songs = new List<Song>();

        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            GetSongs(songsDirectory);
            //INIFile newini = new INIFile(iniPath);
            //SerializableData serializableData = newini.Deserialize();
            //newini.Serialize(serializableData);
            foreach (Song s in songs)
            {
                s.SongInitialize();
            }
            Console.WriteLine("Found: " + songs.Count + " songs");
        }

        static void GetSongs(string directoryPath)
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