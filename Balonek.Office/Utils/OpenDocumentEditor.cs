using AODL.Document.Content.Text;
using AODL.Document.TextDocuments;
using System.Collections.Generic;

namespace Balonek.Office.Utils
{
    public class OpenDocumentEditor
    {
        private TextDocument _document;

        public void CreateFromTemplate(string templatePath)
        {
            var document = new TextDocument();
            document.Load(templatePath);
            _document = document;
        }

        public void ReplaceStringWithDictonary(Dictionary<string, string> dictionary)
        {
            foreach (var tuple in dictionary)
                ReplaceString(tuple.Key, tuple.Value);
        }

        private void ReplaceString(string searchText, string replaceText)
        {
            var content = _document.Content;

            foreach (var item in content)
            {
                if (item is Paragraph)
                {
                    foreach (IText textContent in ((Paragraph)item).TextContent)
                    {
                        if (textContent.Text != null && textContent.Text.Contains(searchText))
                        {
                            textContent.Text = textContent.Text.Replace(searchText, replaceText);
                        }
                    }
                }
            }
        }

        private void DeleteParagraph(string paragraphContent)
        {
            var content = _document.Content;
            foreach (var item in content)
            {
                if (item is Paragraph)
                {
                    var removeParagraph = false;
                    foreach (IText textContent in ((Paragraph)item).TextContent)
                    {
                        removeParagraph = textContent.Text != null && textContent.Text.Contains(paragraphContent);
                    }
                    if (removeParagraph)
                    {
                        var para = item as Paragraph;
                        para.Content.Clear();
                    }
                }
            }
        }

        public void SaveDocument(string filePath)
        {
            _document.SaveTo(filePath);
        }

        public void Close()
        {
            _document.Dispose();
        }
    }
}
