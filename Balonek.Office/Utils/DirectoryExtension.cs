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
    }
}
