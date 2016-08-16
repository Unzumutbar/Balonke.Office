using Balonek.Database.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Balonek.Database.Tables
{
    public class BillPositions : BaseTable
    {
        public BillPositions(string tableDirectory, Database database)
        {        
            TABLEFILE = "billpositions.xml";
            ROOTNAME = "BalonekOfficeBillPositions";
            ELEMENTNAME = "BillPosition";
            InitilizeTable(tableDirectory, database);
        }

        public List<BillPosition> Get()
        {
            try
            {
                var xdoc = XDocument.Load(_tableFile);
                return (from _position in xdoc.Root.Elements(ELEMENTNAME)
                        select new BillPosition
                        {
                            Id = Int32.Parse(_position.Element("Id").Value),
                            Type = (PositionType)(Int32.Parse(_position.Element("Type").Value)),
                            Client = _database.Clients.GetById(Int32.Parse(_position.Element("ClientId").Value)),
                            Description = _position.Element("Description").Value,
                            Date = DateTime.ParseExact(_position.Element("Date").Value, DATEFORMAT, System.Globalization.CultureInfo.InvariantCulture),
                            Period = (Period)(Int32.Parse(_position.Element("Period").Value)),
                            Time = Decimal.Parse(_position.Element("Time").Value),
                            Rate = Decimal.Parse(_position.Element("Rate").Value),

                        }).ToList();
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("GetBillPositionList - {0}", e.Message));
                return new List<BillPosition>();
            }
        }

        public void Add(BillPosition billPositionToAdd)
        {
            try
            {
                XDocument doc = XDocument.Load(_tableFile);

                doc.Root.Add(
                     new XElement(ELEMENTNAME,
                            new XElement("Id", billPositionToAdd.Id),
                            new XElement("Type", (int)billPositionToAdd.Type),
                            new XElement("ClientId", billPositionToAdd.Client.Id),
                            new XElement("Description", billPositionToAdd.Description),
                            new XElement("Date", billPositionToAdd.Date.ToString(DATEFORMAT)),
                            new XElement("Period", billPositionToAdd.Type == PositionType.Periodical ? (int)billPositionToAdd.Period : 0),
                            new XElement("Time", billPositionToAdd.Time),
                            new XElement("Rate", billPositionToAdd.Rate),
                            new XElement("Total", billPositionToAdd.Total)
                            )
                     );

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("BillPosition added - {0} {1} {2}", billPositionToAdd.Id, billPositionToAdd.Client.Name, billPositionToAdd.Description));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("AddBillPosition - {0}", e.Message));
            }
        }

        public void Update(BillPosition billPositionToUpdate)
        {
            try
            {
                XDocument doc = XDocument.Load(_tableFile);

                var target = doc.Root.Elements(ELEMENTNAME).Where(e => e.Element("Id").Value.Equals(billPositionToUpdate.Id.ToString())).Single();
                target.Element("Type").Value = ((int)billPositionToUpdate.Type).ToString();
                target.Element("ClientId").Value = billPositionToUpdate.Client.Id.ToString();
                target.Element("Description").Value = billPositionToUpdate.Description;
                target.Element("Date").Value = billPositionToUpdate.Date.ToString(DATEFORMAT);
                target.Element("Period").Value = ((int)(billPositionToUpdate.Type == PositionType.Periodical ? billPositionToUpdate.Period : 0)).ToString();
                target.Element("Time").Value = billPositionToUpdate.Time.ToString();
                target.Element("Rate").Value = billPositionToUpdate.Rate.ToString();
                target.Element("Total").Value = billPositionToUpdate.Total.ToString();

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("BillPosition updated - {0} {1} {2}", billPositionToUpdate.Id, billPositionToUpdate.Client.Name, billPositionToUpdate.Description));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("UpdateBillPosition - {0}", e.Message));
            }
        }
    }
}
