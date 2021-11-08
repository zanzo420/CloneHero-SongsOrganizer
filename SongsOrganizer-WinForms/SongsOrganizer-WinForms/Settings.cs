using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zCHSongManager
{
	public static class Settings
	{
		public static string SongsDirectory
		{
			get
			{
				return (string)Properties.Settings.Default["SongsDirectoryPath"];
			}
			set
			{
				Properties.Settings.Default["SongsDirectoryPath"] = value;
				Properties.Settings.Default.Save();
			}
		}
	}
}
