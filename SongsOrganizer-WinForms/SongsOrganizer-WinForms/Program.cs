using INIFilesReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongsOrganizer_WinForms
{
    static class Program
    {
        static string iniPath = @"E:\Gry\Clone Hero\Songs\GH-F. Guitar Hero - World Tour\GH-G. Guitar Hero - World Tour\02 - About a Girl (Unplugged)\song.ini";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            INIFile newini = new INIFile(iniPath);
            SerializableData serializableData = newini.Deserialize();
            newini.Serialize(serializableData);
            Console.WriteLine("Halo");
        }
    }
}