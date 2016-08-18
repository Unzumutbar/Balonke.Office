using Balonek.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Balonek.Database.Tables
{
    public class Bills : BaseTable
    {
        public Bills(string tableDirectory, Database database)
        {
            TABLEFILE = "bills.xml";
            ROOTNAME = "BalonekOfficeBills";
            ELEMENTNAME = "Bill";
            InitilizeTable(tableDirectory, database);
        }

        public List<Bill> Get()
        {
            try
            {
                var xdoc = XDocument.Load(_tableFile);
                return (from _bill in xdoc.Root.Elements(ELEMENTNAME)
                        select new Bill
                        {
                            Id = Int32.Parse(_bill.Element("Id").Value),
                            Client = _database.Clients.GetById(Int32.Parse(_bill.Element("ClientId").Value)),
                            DateFrom = DateTime.ParseExact(_bill.Element("DateFrom").Value, DATEFORMAT, System.Globalization.CultureInfo.InvariantCulture),
                            DateTo = DateTime.ParseExact(_bill.Element("DateTo").Value, DATEFORMAT, System.Globalization.CultureInfo.InvariantCulture),
                            Total = Decimal.Parse(_bill.Element("Total").Value),

                        }).ToList();
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("GetBillList - {0}", e.Message));
                return new List<Bill>();
            }
        }

        public void Add(Bill billToAdd)
        {
            try
            {
                int Id = CreateNewId(Get().Cast<BaseEntity>().ToList());

                XDocument doc = XDocument.Load(_tableFile);
                doc.Root.Add(
                     new XElement(ELEMENTNAME,
                            new XElement("Id", Id),
                            new XElement("ClientId", billToAdd.Client.Id),
                            new XElement("DateFrom", billToAdd.DateFrom.ToString(DATEFORMAT)),
                            new XElement("DateTo", billToAdd.DateTo.ToString(DATEFORMAT)),
                            new XElement("Total", billToAdd.Total)
                            )
                     );

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("Bill added - {0} {1}", billToAdd.Id, billToAdd.Client.Id));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("AddBill - {0}", e.Message));
            }
        }

        public void Update(Bill billToUpdate)
        {
            try
            {
                XDocument doc = XDocument.Load(_tableFile);

                var target = doc.Root.Elements(ELEMENTNAME).Where(e => e.Element("Id").Value.Equals(billToUpdate.Id.ToString())).Single();
                target.Element("ClientId").Value = billToUpdate.Client.Id.ToString();
                target.Element("DateFrom").Value = billToUpdate.DateFrom.ToString(DATEFORMAT);
                target.Element("DateTo").Value = billToUpdate.DateTo.ToString(DATEFORMAT);
                target.Element("Total").Value = billToUpdate.Total.ToString();

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("Bill updated - {0} {1}", billToUpdate.Id, billToUpdate.Client.Id));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("UpdateBill - {0}", e.Message));
            }
        }
    }
}
