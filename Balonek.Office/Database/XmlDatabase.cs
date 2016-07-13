using Balonek.Logging;
using Balonek.Office.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Balonek.Office.Database
{
    public class XmlDatabase
    {
        private const int DATABASEVERSION = 1;
        private const string ROOTNAME = "BalonekOfficeDatabase";
        private const string DATEFORMAT = "yyyy-MM-dd";
        private const string DEFAULTBILLTEMPLATE = @"templates\_billTemplate.odt";


        private string _databaseFile;
        private ILogger _logger;

        public XmlDatabase(string databaseFile, ILogger logger)
        {
            _databaseFile = databaseFile;
            _logger = logger;
        }

        public void WriteEmptyDatabase()
        {
            if (File.Exists(_databaseFile))
                File.Delete(_databaseFile);

            using (XmlWriter writer = XmlWriter.Create(_databaseFile))
            {
                writer.WriteStartElement(ROOTNAME);

                writer.WriteStartElement(Settings.NODENAME);
                writer.WriteEndElement();

                writer.WriteStartElement(Client.NODENAME);
                writer.WriteEndElement();

                writer.WriteStartElement(BillPosition.NODENAME);
                writer.WriteEndElement();

                writer.WriteStartElement(Bill.NODENAME);
                writer.WriteEndElement();

                writer.WriteStartElement(BillPositionText.NODENAME);
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.Flush();
            }

            AddDefaultBillPositionText();
        }

        private void AddDefaultBillPositionText()
        {
            var newText = new BillPositionText();
            newText.Id = 1;
            newText.Text = "Haushaltshilfe";
            AddBillPositionText(newText);
        }

        #region Updatespezifische Funktionen

        public void UpdateDatabase()
        {
            var currentDataBaseVersion = this.GetDatabaseVersion();
            if (currentDataBaseVersion >= DATABASEVERSION)
                return;
        }

        #endregion

        #region Settings

        public int GetDatabaseVersion()
        {
            var doc = XDocument.Load(_databaseFile);
            try
            {
                string VersionAsString = (from _settings in doc.Root.Elements(Settings.NODENAME)
                                          select _settings.Element("DatabaseVersion").Value).FirstOrDefault();
                return Int32.Parse(VersionAsString);

            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("GetDatabaseVersion - {0}", e.Message));
                doc.Root.Element(Settings.NODENAME).Add(
                    new XElement("DatabaseVersion", DATABASEVERSION)
                );
                doc.Save(_databaseFile);
                return DATABASEVERSION;
            }
        }

        public string GetBillTemplate()
        {
            var doc = XDocument.Load(_databaseFile);
            try
            {
                return (from _settings in doc.Root.Elements(Settings.NODENAME)
                        select _settings.Element("BillTemplateFile").Value).FirstOrDefault();

            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("GetBillTemplateFile - {0}", e.Message));
                doc.Root.Element(Settings.NODENAME).Add(
                    new XElement("BillTemplateFile", DEFAULTBILLTEMPLATE)
                );
                doc.Save(_databaseFile);
                return DEFAULTBILLTEMPLATE;
            }
        }

        public void UpdateSettings(Settings settingToUpdate)
        {
            try
            {
                XDocument doc = XDocument.Load(_databaseFile);

                var target = doc.Root.Elements(Settings.NODENAME).Single();
                target.Element("BillTemplateFile").Value = settingToUpdate.TemplateBillPath;

                doc.Save(_databaseFile);
                _logger.LogInfo(string.Format("Settings updated"));
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("UpdateClient - {0}", e));
            }
        }

        #endregion 

        #region Clients

        public List<Client> GetClientList()
        {
            try
            {
                var xdoc = XDocument.Load(_databaseFile);
                return (from _client in xdoc.Root.Element(Client.NODENAME).Elements(Client.ELEMENTNAME)
                        select new Client
                        {
                            Id = Int32.Parse(_client.Element("Id").Value),

                            Name = _client.Element("Name").Value,
                            Street = _client.Element("Street").Value,
                            Zip = _client.Element("Zip").Value,
                            City = _client.Element("City").Value,
                            Telephone = _client.Element("Telephone").Value,
                            Fax = _client.Element("Fax").Value,
                            Email = _client.Element("Email").Value,                           

                        }).ToList();
            }
            catch(Exception e)
            {
                _logger.LogError(string.Format("GetClientList - {0}", e.Message));
                return new List<Client>();
            }
        }

        private Client GetClientById(int clientId)
        {
            try
            {
                var xdoc = XDocument.Load(_databaseFile);
                return (from _client in xdoc.Root.Element(Client.NODENAME).Elements(Client.ELEMENTNAME)
                        select new Client
                        {
                            Id = Int32.Parse(_client.Element("Id").Value),

                            Name = _client.Element("Name").Value,
                            Street = _client.Element("Street").Value,
                            Zip = _client.Element("Zip").Value,
                            City = _client.Element("City").Value,
                            Telephone = _client.Element("Telephone").Value,
                            Fax = _client.Element("Fax").Value,
                            Email = _client.Element("Email").Value,

                        }
                        ).Where(c => c.Id == clientId).First();
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("GetClientById - {0}", e.Message));
                return new Client();
            }
        }

        public void AddClient(Client clientToAdd)
        {
            try
            {
                XDocument doc = XDocument.Load(_databaseFile);

                doc.Root.Element(Client.NODENAME).Add(
                     new XElement(Client.ELEMENTNAME,
                            new XElement("Id", clientToAdd.Id),

                            new XElement("Name", clientToAdd.Name),
                            new XElement("Street", clientToAdd.Street),
                            new XElement("Zip", clientToAdd.Zip),
                            new XElement("City", clientToAdd.City),
                            new XElement("Telephone", clientToAdd.Telephone),
                            new XElement("Fax", clientToAdd.Fax),
                            new XElement("Email", clientToAdd.Email)
                            )
                     );

                doc.Save(_databaseFile);
                _logger.LogInfo(string.Format("Client added - {0} {1}", clientToAdd.Id, clientToAdd.Name));
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("AddClient - {0}", e.Message));
            }
        }

        public void UpdateClient(Client clientToUpdate)
        {
            try
            {
                XDocument doc = XDocument.Load(_databaseFile);

                var target = doc.Root.Element(Client.NODENAME).Elements(Client.ELEMENTNAME).Where(e => e.Element("Id").Value.Equals(clientToUpdate.Id.ToString())).Single();
                target.Element("Name").Value = clientToUpdate.Name;
                target.Element("Street").Value = clientToUpdate.Street;
                target.Element("Zip").Value = clientToUpdate.Zip;
                target.Element("City").Value = clientToUpdate.City;
                target.Element("Telephone").Value = clientToUpdate.Telephone;
                target.Element("Fax").Value = clientToUpdate.Fax;
                target.Element("Email").Value = clientToUpdate.Email;

                doc.Save(_databaseFile);
                _logger.LogInfo(string.Format("Client updated - {0} {1}", clientToUpdate.Id, clientToUpdate.Name));
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("UpdateClient - {0}", e.Message));
            }
        }

        public void DeleteClient(Client clientToDelete)
        {
            this.DeleteElementById(Client.NODENAME, Client.ELEMENTNAME, clientToDelete.Id);
        }

        #endregion

        #region BillPositions
        public List<BillPosition> GetBillPositionList()
        {
            try
            {
                var xdoc = XDocument.Load(_databaseFile);
                return (from _position in xdoc.Root.Element(BillPosition.NODENAME).Elements(BillPosition.ELEMENTNAME)
                        select new BillPosition
                        {
                            Id = Int32.Parse(_position.Element("Id").Value),
                            ClientId = Int32.Parse(_position.Element("ClientId").Value),
                            Client = GetClientById(Int32.Parse(_position.Element("ClientId").Value)),
                            Description = _position.Element("Description").Value,
                            Date = DateTime.ParseExact(_position.Element("Date").Value, DATEFORMAT, System.Globalization.CultureInfo.InvariantCulture),
                            Time = Decimal.Parse(_position.Element("Time").Value),
                            Rate = Decimal.Parse(_position.Element("Rate").Value),

                        }).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("GetBillPositionList - {0}", e.Message));
                return new List<BillPosition>();
            }
        }

        public void AddBillPosition(BillPosition billPositionToAdd)
        {
            try
            {
                XDocument doc = XDocument.Load(_databaseFile);

                doc.Root.Element(BillPosition.NODENAME).Add(
                     new XElement(BillPosition.ELEMENTNAME,
                            new XElement("Id", billPositionToAdd.Id),
                            new XElement("ClientId", billPositionToAdd.ClientId),
                            new XElement("Description", billPositionToAdd.Description),
                            new XElement("Date", billPositionToAdd.Date.ToString(DATEFORMAT)),
                            new XElement("Time", billPositionToAdd.Time),
                            new XElement("Rate", billPositionToAdd.Rate),
                            new XElement("Total", billPositionToAdd.Total)
                            )
                     );

                doc.Save(_databaseFile);
                _logger.LogInfo(string.Format("BillPosition added - {0} {1} {2}", billPositionToAdd.Id, billPositionToAdd.Client.Name, billPositionToAdd.Description));
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("AddBillPosition - {0}", e.Message));
            }
        }

        public void UpdateBillPosition(BillPosition billPositionToUpdate)
        {
            try
            {
                XDocument doc = XDocument.Load(_databaseFile);

                var target = doc.Root.Element(BillPosition.NODENAME).Elements(BillPosition.ELEMENTNAME).Where(e => e.Element("Id").Value.Equals(billPositionToUpdate.Id.ToString())).Single();
                target.Element("ClientId").Value = billPositionToUpdate.ClientId.ToString();
                target.Element("Description").Value = billPositionToUpdate.Description;
                target.Element("Date").Value = billPositionToUpdate.Date.ToString(DATEFORMAT);
                target.Element("Time").Value = billPositionToUpdate.Time.ToString();
                target.Element("Rate").Value = billPositionToUpdate.Rate.ToString();
                target.Element("Total").Value = billPositionToUpdate.Total.ToString();

                doc.Save(_databaseFile);
                _logger.LogInfo(string.Format("BillPosition updated - {0} {1} {2}", billPositionToUpdate.Id, billPositionToUpdate.Client.Name, billPositionToUpdate.Description));
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("UpdateBillPosition - {0}", e.Message));
            }
        }

        public void DeleteBillPosition(BillPosition billPositionToDelete)
        {
            this.DeleteElementById(BillPosition.NODENAME, BillPosition.ELEMENTNAME, billPositionToDelete.Id);
        }

        #endregion

        #region Bills
        public List<Bill> GetBillList()
        {
            try
            {
                var xdoc = XDocument.Load(_databaseFile);
                return (from _bill in xdoc.Root.Element(Bill.NODENAME).Elements(Bill.ELEMENTNAME)
                        select new Bill
                        {
                            Id = Int32.Parse(_bill.Element("Id").Value),
                            ClientId = Int32.Parse(_bill.Element("ClientId").Value),
                            Client = GetClientById(Int32.Parse(_bill.Element("ClientId").Value)),
                            DateFrom = DateTime.ParseExact(_bill.Element("DateFrom").Value, DATEFORMAT, System.Globalization.CultureInfo.InvariantCulture),
                            DateTo = DateTime.ParseExact(_bill.Element("DateTo").Value, DATEFORMAT, System.Globalization.CultureInfo.InvariantCulture),
                            Total = Decimal.Parse(_bill.Element("Total").Value),

                        }).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("GetBillList - {0}", e.Message));
                return new List<Bill>();
            }
        }

        public void AddBill(Bill billToAdd)
        {
            try
            {
                XDocument doc = XDocument.Load(_databaseFile);

                doc.Root.Element(Bill.NODENAME).Add(
                     new XElement(Bill.ELEMENTNAME,
                            new XElement("Id", billToAdd.Id),
                            new XElement("ClientId", billToAdd.ClientId),
                            new XElement("DateFrom", billToAdd.DateFrom.ToString(DATEFORMAT)),
                            new XElement("DateTo", billToAdd.DateTo.ToString(DATEFORMAT)),
                            new XElement("Total", billToAdd.Total)
                            )
                     );

                doc.Save(_databaseFile);
                _logger.LogInfo(string.Format("Bill added - {0} {1}", billToAdd.Id, billToAdd.ClientId));
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("AddBill - {0}", e.Message));
            }
        }

        public void UpdateBill(Bill billToUpdate)
        {
            try
            {
                XDocument doc = XDocument.Load(_databaseFile);

                var target = doc.Root.Element(Bill.NODENAME).Elements(Bill.ELEMENTNAME).Where(e => e.Element("Id").Value.Equals(billToUpdate.Id.ToString())).Single();
                target.Element("ClientId").Value = billToUpdate.ClientId.ToString();
                target.Element("DateFrom").Value = billToUpdate.DateFrom.ToString(DATEFORMAT);
                target.Element("DateTo").Value = billToUpdate.DateTo.ToString(DATEFORMAT);
                target.Element("Total").Value = billToUpdate.Total.ToString();

                doc.Save(_databaseFile);
                _logger.LogInfo(string.Format("Bill updated - {0} {1}", billToUpdate.Id, billToUpdate.ClientId));
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("UpdateBill - {0}", e.Message));
            }
        }

        public void DeleteBill(Bill billToDelete)
        {
            this.DeleteElementById(Bill.NODENAME, Bill.ELEMENTNAME, billToDelete.Id);
        }

        #endregion

        #region BillPositionTexts
        public List<BillPositionText> GetBillPositionTextList()
        {
            try
            {
                var xdoc = XDocument.Load(_databaseFile);
                return (from _text in xdoc.Root.Element(BillPositionText.NODENAME).Elements(BillPositionText.ELEMENTNAME)
                        select new BillPositionText
                        {
                            Id = Int32.Parse(_text.Element("Id").Value),
                            Text = _text.Element("Text").Value,

                        }).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("GetBillPositionTextList - {0}", e.Message));
                return new List<BillPositionText>();
            }
        }

        public void AddBillPositionText(BillPositionText textToAdd)
        {
            try
            {
                XDocument doc = XDocument.Load(_databaseFile);

                doc.Root.Element(BillPositionText.NODENAME).Add(
                     new XElement(BillPositionText.ELEMENTNAME,
                            new XElement("Id", textToAdd.Id),
                            new XElement("Text", textToAdd.Text)
                            )
                     );

                doc.Save(_databaseFile);
                _logger.LogInfo(string.Format("BillPositionText added - {0} {1}", textToAdd.Id, textToAdd.Text));
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("AddBillPositionText - {0}", e.Message));
            }
        }

        public void UpdateBillPositionText(BillPositionText textToUpdate)
        {
            try
            {
                XDocument doc = XDocument.Load(_databaseFile);

                var target = doc.Root.Element(BillPositionText.NODENAME).Elements(BillPositionText.ELEMENTNAME).Where(e => e.Element("Id").Value.Equals(textToUpdate.Id.ToString())).Single();
                target.Element("Text").Value = textToUpdate.Text;

                doc.Save(_databaseFile);
                _logger.LogInfo(string.Format("BillPositionText updated - {0} {1}", textToUpdate.Id, textToUpdate.Text));
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("UpdateBillPositionText - {0}", e.Message));
            }
        }

        public void DeleteBillPositionText(BillPositionText textToDelete)
        {
            this.DeleteElementById(BillPositionText.NODENAME, BillPositionText.ELEMENTNAME, textToDelete.Id);
        }

        #endregion

        private void DeleteElementById(string Node, string ElementName, int Id)
        {
            try
            {
                XDocument doc = XDocument.Load(_databaseFile);
                doc.Root.Element(Node).Elements(ElementName).Where(e => e.Element("Id").Value.Equals(Id.ToString())).Select(e => e).Single().Remove();
                doc.Save(_databaseFile);
                _logger.LogInfo(string.Format("{0} deleted - {1}", ElementName, Id));
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("Delete{0} - {1}",ElementName, e.Message));
            }
}
    }
}
