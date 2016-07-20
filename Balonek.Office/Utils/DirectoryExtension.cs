using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Balonek.Office.Utils
{
    public static class DirectoryExtension
    {
        public static string CreateTempDirectory()
        {
            var tempDir = Path.Combine(Path.GetTempPath(), string.Format("SosiasOffice{0}", Path.GetRandomFileName()));
            Directory.CreateDirectory(tempDir);
            return tempDir;
        }

        public static void DeleteDirectoryAndContent(string directory)
        {
            var directoryInfo = new DirectoryInfo(directory);
            directoryInfo.DeleteDirectoryAndContent();
        }

        public static void DeleteDirectoryAndContent(this DirectoryInfo directoryInfo)
        {
            foreach (var file in directoryInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (var dir in directoryInfo.GetDirectories())
            {
                dir.Delete(true);
            }
            directoryInfo.Delete();
        }
    }
}
