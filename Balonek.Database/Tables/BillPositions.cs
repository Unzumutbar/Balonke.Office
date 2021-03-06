﻿using Balonek.Database.Entities;
using System;
using System.Collections.Generic;
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
                _database.Logger.LogError(string.Format("{0}.Get()", this.GetType().FullName), e);
                throw e;
            }
        }

        public BillPosition Add(BillPosition billPositionToAdd)
        {
            try
            {
                billPositionToAdd.Id = CreateNewId(Get().Cast<BaseEntity>().ToList());

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
                _database.Logger.LogInfo(string.Format("{0}.Add({1})", this.GetType().FullName, billPositionToAdd));
                return billPositionToAdd;
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("{0}.Add({1})", this.GetType().FullName, billPositionToAdd), e);
                throw e;
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
                _database.Logger.LogInfo(string.Format("{0}.Update({1})", this.GetType().FullName, billPositionToUpdate));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("{0}.Update({1})", this.GetType().FullName, billPositionToUpdate), e);
                throw e;
            }
        }
    }
}
