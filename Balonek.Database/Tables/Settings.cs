using Balonek.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Balonek.Database.Tables
{
    public class Settings : BaseTable
    {
        public Settings(string tableDirectory, Database database)
        {
            TABLEFILE = "settings.xml";
            ROOTNAME = "BalonekOfficeSettings";
            ELEMENTNAME = "setting";
            InitilizeTable(tableDirectory, database);
        }

        public Setting Get()
        {
            try
            {
                var xdoc = XDocument.Load(_tableFile);
                return (from _setting in xdoc.Root.Elements(ELEMENTNAME)
                        select new Setting
                        {
                            //Id = Int32.Parse(_setting.Element("Id").Value),

                            DataBaseVersion = Int32.Parse(_setting.Element("DatabaseVersion").Value),
                            TemplateBillPath = _setting.Element("BillTemplateFile").Value,

                        }).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("GetClientList - {0}", e.Message));
                return null;
            }
        }

        internal void CreateDefaultValue()
        {
            var setting = new Setting();
            setting.DataBaseVersion = 2;
            setting.TemplateBillPath = @"ExportTemplates\TemplateRechnung.odt";
            this.Add(setting);

        }

        public void Add(Setting settingToAdd)
        {
            try
            {
                XDocument doc = XDocument.Load(_tableFile);
                doc.Root.Add(
                     new XElement(ELEMENTNAME,
                            new XElement("DatabaseVersion", settingToAdd.DataBaseVersion),
                            new XElement("BillTemplateFile", settingToAdd.TemplateBillPath)
                            )
                     );

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("Settings added"));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("Settings - {0}", e.Message));
            }
        }

        public void Update(Setting settingToUpdate)
        {
            try
            {
                XDocument doc = XDocument.Load(_tableFile);

                var target = doc.Root.Elements(ELEMENTNAME).Single();
                target.Element("BillTemplateFile").Value = settingToUpdate.TemplateBillPath;

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("Settings updated"));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("UpdateSettings - {0}", e));
            }
        }
    }
}
