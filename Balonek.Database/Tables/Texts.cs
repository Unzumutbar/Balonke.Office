using Balonek.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Balonek.Database.Tables
{
    public class Texts : BaseTable
    {
        public Texts(string tableDirectory, Database database)
        {
            TABLEFILE = "texts.xml";
            ROOTNAME = "BalonekOfficeTexts";
            ELEMENTNAME = "Text";
            InitilizeTable(tableDirectory, database);
        }

        public List<Text> Get()
        {
            try
            {
                var xdoc = XDocument.Load(_tableFile);
                return (from _text in xdoc.Root.Elements(ELEMENTNAME)
                        select new Text
                        {
                            Id = Int32.Parse(_text.Element("Id").Value),
                            Value = _text.Element("Text").Value,

                        }).ToList();
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("GetBillPositionTextList - {0}", e.Message));
                return new List<Text>();
            }
        }

        public void AddBillPositionText(Text textToAdd)
        {
            try
            {
                int Id = CreateNewId(Get().Cast<BaseEntity>().ToList());
                XDocument doc = XDocument.Load(_tableFile);

                doc.Root.Add(
                     new XElement(ELEMENTNAME,
                            new XElement("Id", Id),
                            new XElement("Text", textToAdd.Value)
                            )
                     );

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("BillPositionText added - {0} {1}", textToAdd.Id, textToAdd.Value));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("AddBillPositionText - {0}", e.Message));
            }
        }

        public void UpdateBillPositionText(Text textToUpdate)
        {
            try
            {
                XDocument doc = XDocument.Load(_tableFile);

                var target = doc.Root.Elements(ELEMENTNAME).Where(e => e.Element("Id").Value.Equals(textToUpdate.Id.ToString())).Single();
                target.Element("Text").Value = textToUpdate.Value;

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("BillPositionText updated - {0} {1}", textToUpdate.Id, textToUpdate.Value));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("UpdateBillPositionText - {0}", e.Message));
            }
        }
    }
}
