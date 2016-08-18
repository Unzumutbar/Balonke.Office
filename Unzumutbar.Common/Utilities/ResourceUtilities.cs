using System.IO;

namespace Unzumutbar.Utilities
{
    public static class ResourceUtilities
    {
        public static void ExtractEmbeddedResource(string outputFile, UnmanagedMemoryStream unmanagedStream)
        {
            using (FileStream file = new FileStream(outputFile, FileMode.Create, System.IO.FileAccess.Write))
            {
                byte[] bytes = new byte[unmanagedStream.Length];
                unmanagedStream.Read(bytes, 0, (int)unmanagedStream.Length);
                file.Write(bytes, 0, bytes.Length);
                unmanagedStream.Close();
            }
        }
    }
}
