using Balonek.Database.Entities;
using Balonek.Database.Tables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Balonek.Database
{
    public static class DatabaseUpdate
    {
        public static void Update(Companies company, string databaseDirectory, int currentVersion)
        {
            var databaseVersion = company.GetDatabaseVersion();
            if (databaseVersion >= currentVersion)
                return;

            switch(databaseVersion)
            {
                case 2: UpdateV2(databaseDirectory);
                        break;
                default: return;
            }

            company.UpdateDataBaseVersion(currentVersion);
        }

        public static void UpdateV2(string databaseDirectory)
        {
            var billsXmlFile = Path.Combine(databaseDirectory, "bills.xml");
            XDocument doc = XDocument.Load(billsXmlFile);
            foreach (var element in doc.Root.Elements("Bill").Where(u => u.Element("BillPurpose") == null))
            {
                element.Add(new XElement("BillPurpose", string.Empty));
                element.Add(new XElement("MergePositions", true.ToString()));
            }
            doc.Save(billsXmlFile);
        }
    }
}
