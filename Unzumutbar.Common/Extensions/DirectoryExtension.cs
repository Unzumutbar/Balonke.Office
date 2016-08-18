using System.IO;

namespace Unzumutbar.Extensions
{
    public static class DirectoryExtension
    {
        public static string CreateTempDirectory(string prefix)
        {
            var tempDir = Path.Combine(Path.GetTempPath(), string.Format("{0}{1}", prefix, Path.GetRandomFileName()));
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
