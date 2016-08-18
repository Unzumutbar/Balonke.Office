using Balonek.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Balonek.Database.Tables
{
    public class Clients : BaseTable
    {
        public Clients(string tableDirectory, Database database)
        {
            TABLEFILE = "clients.xml";
            ROOTNAME = "BalonekOfficeClients";
            ELEMENTNAME = "Client";
            InitilizeTable(tableDirectory, database);
        }

        public List<Client> Get()
        {
            try
            {
                var xdoc = XDocument.Load(_tableFile);
                return (from _client in xdoc.Root.Elements(ELEMENTNAME)
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
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("GetClientList - {0}", e.Message));
                return new List<Client>();
            }
        }

        public Client GetById(int clientId)
        {
            try
            {
                var xdoc = XDocument.Load(_tableFile);
                return (from _client in xdoc.Root.Elements(ELEMENTNAME)
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
                _database.Logger.LogError(string.Format("GetClientById - {0}", e.Message));
                return new Client();
            }
        }

        public void Add(Client clientToAdd)
        {
            try
            {
                int Id = CreateNewId(Get().Cast<BaseEntity>().ToList());
                XDocument doc = XDocument.Load(_tableFile);
                doc.Root.Add(
                     new XElement(ELEMENTNAME,
                            new XElement("Id", Id),
                            new XElement("Name", clientToAdd.Name),
                            new XElement("Street", clientToAdd.Street),
                            new XElement("Zip", clientToAdd.Zip),
                            new XElement("City", clientToAdd.City),
                            new XElement("Telephone", clientToAdd.Telephone),
                            new XElement("Fax", clientToAdd.Fax),
                            new XElement("Email", clientToAdd.Email)
                            )
                     );

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("Client added - {0} {1}", clientToAdd.Id, clientToAdd.Name));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("AddClient - {0}", e.Message));
            }
        }

        public void Update(Client clientToUpdate)
        {
            try
            {
                XDocument doc = XDocument.Load(_tableFile);

                var target = doc.Root.Elements(ELEMENTNAME).Where(e => e.Element("Id").Value.Equals(clientToUpdate.Id.ToString())).Single();
                target.Element("Name").Value = clientToUpdate.Name;
                target.Element("Street").Value = clientToUpdate.Street;
                target.Element("Zip").Value = clientToUpdate.Zip;
                target.Element("City").Value = clientToUpdate.City;
                target.Element("Telephone").Value = clientToUpdate.Telephone;
                target.Element("Fax").Value = clientToUpdate.Fax;
                target.Element("Email").Value = clientToUpdate.Email;

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("Client updated - {0} {1}", clientToUpdate.Id, clientToUpdate.Name));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("UpdateClient - {0}", e.Message));
            }
        }
    }
}
