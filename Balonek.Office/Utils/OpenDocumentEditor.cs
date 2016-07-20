using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Balonek.Office.Utils
{
    public class OpenDocumentEditor
    {
        private string _document;

        public void CreateFromTemplate(string templatePath)
        {
            _document = DirectoryExtension.CreateTempDirectory();
            Archive.ExtractZipFile(templatePath, _document);
        }

        public void ReplaceWithDictonary(Dictionary<string, string> dictionary)
        {
            string file = Path.Combine(_document,"content.xml");
            var content = ReadContent(file);

            foreach (var tuple in dictionary)
                content = content.Replace(tuple.Key, tuple.Value);

            SaveContent(content, file);
        }

        public void DeleteTableRow(string rowIdentifier)
        {
            string file = Path.Combine(_document, "content.xml");
            var content = ReadContent(file);
            string pattern = @"<table:table-row [\s\S]*?<\/table:table-row>";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            var matches = regex.Matches(content);
            foreach (var match in matches)
            {
                if (match.ToString().Contains(rowIdentifier))
                    content = content.Replace(match.ToString(), "");
            }
            SaveContent(content, file);
        }

        private void SaveContent(string content, string file)
        {
            File.WriteAllText(file, content);
        }

        private string ReadContent(string file)
        {
            return File.ReadAllText(file);
        }

        public void Save(string filePath)
        {
            Archive.CreateArchive(filePath, _document);
        }
    }
}
