using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace FontInstaller
{
	class Program
	{
		/// <summary>
		/// Installs all Fonts from the
		/// </summary>
		/// <param name="args">list of file extension to read</param>
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				args = new string[]
				{
					".fon",
					".fnt",
					".ttf",
					".ttc",
					".otf"
				};
			}

			var allFiles = Directory.GetFiles(Environment.CurrentDirectory).Select(x => new FileInfo(x)).ToList();
			var filteredFiles = allFiles.Where(x => args.Contains(x.Extension));

			var destinationPath = string.Empty;

			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				destinationPath = Path.Combine(Environment.GetEnvironmentVariable("windir"), "fonts");
			}
			if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				destinationPath = "/Library/Fonts";
			}

			foreach (var file in filteredFiles)
			{
				var destinationFileName = Path.Combine(destinationPath, file.Name);
				if (File.Exists(destinationFileName))
				{
					Console.WriteLine($"ERROR: File {file.Name} already exists");
				}
				else
				{
					File.Copy(file.FullName, destinationFileName);
					Console.WriteLine($"SUCCESS: {file.Name} sucessfully installed");
				}
			}
			Console.WriteLine("Press any key to exit");
			Console.ReadKey();

		}
	}
}
