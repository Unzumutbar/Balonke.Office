using Balonek.Database.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Balonek.Database.Tables
{
    public class BaseTable
    {
        protected const string DATEFORMAT = "yyyy-MM-dd";

        protected string _tableFile;
        protected Database _database;

        public string ROOTNAME;
        public string ELEMENTNAME;
        public string TABLEFILE;

        protected virtual void InitilizeTable(string tableDirectory, Database database)
        {
            _database = database;
            _tableFile = Path.Combine(tableDirectory, TABLEFILE);

            WriteEmptyDatabase();
        }

        public virtual void Delete(BaseEntity entityToDelete)
        {
            DeleteElementById(ELEMENTNAME, entityToDelete.Id);
        }

        protected virtual void WriteEmptyDatabase()
        {
            if (File.Exists(_tableFile))
                return;

            using (XmlWriter writer = XmlWriter.Create(_tableFile))
            {
                writer.WriteStartElement(ROOTNAME);

                writer.WriteEndElement();
                writer.Flush();
            }
        }

        private void DeleteElementById(string ElementName, int Id)
        {
            try
            {
                XDocument doc = XDocument.Load(_tableFile);
                doc.Root.Elements(ElementName).Where(e => e.Element("Id").Value.Equals(Id.ToString())).Select(e => e).Single().Remove();
                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("{0} deleted - {1}", ElementName, Id));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("Delete{0} - {1}", ElementName, e.Message));
            }
        }

        protected virtual int CreateNewId(List<BaseEntity> entities)
        {
            if (entities.Any())
                return entities.Max(ent => ent.Id) + 1;
            return 1;
        }
    }
}
