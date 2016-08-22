using System.IO;

namespace Unzumutbar.Utilities
{
    public static class ResourceUtilities
    {
        public static void ExtractEmbeddedResource(string outputFile, byte[] content)
        {
            using (FileStream file = new FileStream(outputFile, FileMode.Create, System.IO.FileAccess.Write))
            {
                byte[] bytes = new byte[content.Length];
                file.Write(content, 0, bytes.Length);
            }
        }
    }
}
