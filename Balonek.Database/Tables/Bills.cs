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
                            Status = (BillStatus)(Int32.Parse(_bill.Element("Status").Value)),
                            Total = Decimal.Parse(_bill.Element("Total").Value),
                            BillPurpose = _bill.Element("BillPurpose").Value,
                            MergePositions = "True".Equals(_bill.Element("MergePositions").Value),

                        }).ToList();
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("{0}.Get()|", this.GetType().FullName), e);
                throw e;
            }
        }

        public int GetNextId()
        {
            return this.CreateNewId(Get().Cast<BaseEntity>().ToList());
        }

        public Bill Add(Bill billToAdd)
        {
            try
            {
                if (billToAdd.Id == 0)
                    billToAdd.Id = GetNextId();

                XDocument doc = XDocument.Load(_tableFile);
                doc.Root.Add(
                     new XElement(ELEMENTNAME,
                            new XElement("Id", billToAdd.Id),
                            new XElement("ClientId", billToAdd.Client.Id),
                            new XElement("DateFrom", billToAdd.DateFrom.ToString(DATEFORMAT)),
                            new XElement("DateTo", billToAdd.DateTo.ToString(DATEFORMAT)),
                            new XElement("Status", (int)billToAdd.Status),
                            new XElement("Total", billToAdd.Total),
                            new XElement("BillPurpose", billToAdd.BillPurpose),
                            new XElement("MergePositions", billToAdd.MergePositions.ToString())
                            )
                     );

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("{0}.Add({1})", this.GetType().FullName, billToAdd));
                return billToAdd;
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("{0}.Add({1})", this.GetType().FullName, billToAdd), e);
                throw e;
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
                target.Element("Status").Value = ((int)billToUpdate.Status).ToString();
                target.Element("Total").Value = billToUpdate.Total.ToString();
                target.Element("BillPurpose").Value = billToUpdate.BillPurpose;
                target.Element("MergePositions").Value = billToUpdate.MergePositions.ToString();

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("{0}.Update({1})", this.GetType().FullName, billToUpdate));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("{0}.Update({1})", this.GetType().FullName, billToUpdate), e);
                throw e;
            }
        }
    }
}
