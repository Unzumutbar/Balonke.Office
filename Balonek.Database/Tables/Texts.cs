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
                _database.Logger.LogError(string.Format("{0}.Add()", this.GetType().FullName), e);
                throw e;
            }
        }

        public Text Add(Text textToAdd)
        {
            try
            {
                textToAdd.Id = CreateNewId(Get().Cast<BaseEntity>().ToList());
                XDocument doc = XDocument.Load(_tableFile);

                doc.Root.Add(
                     new XElement(ELEMENTNAME,
                            new XElement("Id", textToAdd.Id),
                            new XElement("Text", textToAdd.Value)
                            )
                     );

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("{0}.Add({1})", this.GetType().FullName, textToAdd));
                return textToAdd;
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("{0}.Add({1})", this.GetType().FullName, textToAdd), e);
                throw e;
            }
        }

        public void Update(Text textToUpdate)
        {
            try
            {
                XDocument doc = XDocument.Load(_tableFile);

                var target = doc.Root.Elements(ELEMENTNAME).Where(e => e.Element("Id").Value.Equals(textToUpdate.Id.ToString())).Single();
                target.Element("Text").Value = textToUpdate.Value;

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("{0}.Update({1})", this.GetType().FullName, textToUpdate));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("{0}.Update({1})", this.GetType().FullName, textToUpdate), e);
                throw e;
            }
        }
    }
}
