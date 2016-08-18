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
                            Deleted = _client.Element("Deleted").Value == "true" ? true : false,

                        }).ToList();
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("{0}.Get()", this.GetType().FullName), e);
                throw e;
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
                _database.Logger.LogError(string.Format("{0}.GetById({1})", this.GetType().FullName, clientId), e);
                throw e;
            }
        }

        public Client Add(Client clientToAdd)
        {
            try
            {
                clientToAdd.Id = CreateNewId(Get().Cast<BaseEntity>().ToList());
                XDocument doc = XDocument.Load(_tableFile);
                doc.Root.Add(
                     new XElement(ELEMENTNAME,
                            new XElement("Id", clientToAdd.Id),
                            new XElement("Name", clientToAdd.Name),
                            new XElement("Street", clientToAdd.Street),
                            new XElement("Zip", clientToAdd.Zip),
                            new XElement("City", clientToAdd.City),
                            new XElement("Telephone", clientToAdd.Telephone),
                            new XElement("Fax", clientToAdd.Fax),
                            new XElement("Email", clientToAdd.Email),
                            new XElement("Deleted", "false")
                            )
                     );

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("{0}.Add({1})", this.GetType().FullName, clientToAdd));
                return clientToAdd;
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("{0}.Add({1})", this.GetType().FullName, clientToAdd), e);
                throw e;
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
                target.Element("Deleted").Value = clientToUpdate.Deleted ? "true" : "false";

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("{0}.Update({1})", this.GetType().FullName, clientToUpdate));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("{0}.Update({1})", this.GetType().FullName, clientToUpdate), e);
                throw e;
            }
        }

        public override void Delete(BaseEntity entityToDelete)
        {
            var clientToDelete = entityToDelete as Client;
            clientToDelete.Deleted = true;
            Update(clientToDelete); 
        }
    }
}
