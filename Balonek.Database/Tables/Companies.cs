using Balonek.Database.Entities;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Balonek.Database.Tables
{
    public class Companies : BaseTable
    {
        public Companies(string tableDirectory, Database database)
        {
            TABLEFILE = "company.xml";
            ROOTNAME = "BalonekOfficeCompany";
            ELEMENTNAME = "Company";
            InitilizeTable(tableDirectory, database);
        }

        public Company Get()
        {
            try
            {
                var xdoc = XDocument.Load(_tableFile);
                return (from _company in xdoc.Root.Elements(ELEMENTNAME)
                            select new Company
                            {
                                Id = Int32.Parse(_company.Element("Id").Value),

                                CompanyName = _company.Element("CompanyName").Value,
                                Name = _company.Element("Name").Value,
                                Street = _company.Element("Street").Value,
                                Zip = _company.Element("Zip").Value,
                                City = _company.Element("City").Value,
                                Telephone = _company.Element("Telephone").Value,
                                Fax = _company.Element("Fax").Value,
                                Email = _company.Element("Email").Value,

                                DataBaseVersion = Int32.Parse(_company.Element("DatabaseVersion").Value),
                                TemplateBillPath = _company.Element("BillTemplateFile").Value,

                            }).FirstOrDefault();
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("{0}.Add()", this.GetType().FullName), e);
                return null;
            }
        }

        public int GetDatabaseVersion()
        {
            try
            {
                var xdoc = XDocument.Load(_tableFile);
                return (from _company in xdoc.Root.Elements(ELEMENTNAME)
                        select new Company
                        {
                            DataBaseVersion = Int32.Parse(_company.Element("DatabaseVersion").Value),
                        }).FirstOrDefault().DataBaseVersion;
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("{0}.GetDatabaseVersion()", this.GetType().FullName), e);
                return -1;
            }
        }

        public void CreateDefaultValue()
        {
            var company = new Company();
            company.Id = 0;
            company.DataBaseVersion = 2;
            company.TemplateBillPath = Path.Combine("ExportTemplates", "TemplateRechnung.odt");
            this.Add(company);
        }

        public void Add(Company companyToAdd)
        {
            try
            {
                XDocument doc = XDocument.Load(_tableFile);

                doc.Root.Add(
                     new XElement(ELEMENTNAME,
                            new XElement("Id", companyToAdd.Id),
                            new XElement("CompanyName", companyToAdd.CompanyName),
                            new XElement("Name", companyToAdd.Name),
                            new XElement("Street", companyToAdd.Street),
                            new XElement("Zip", companyToAdd.Zip),
                            new XElement("City", companyToAdd.City),
                            new XElement("Telephone", companyToAdd.Telephone),
                            new XElement("Fax", companyToAdd.Fax),
                            new XElement("Email", companyToAdd.Email),

                            new XElement("DatabaseVersion", companyToAdd.DataBaseVersion),
                            new XElement("BillTemplateFile", companyToAdd.TemplateBillPath)
                            )
                     );

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("{0}.Add({1})", this.GetType().FullName, companyToAdd));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("{0}.Add({1})", this.GetType().FullName, companyToAdd), e);
                throw e;
            }
        }

        public void Update(Company companyToUpdate)
        {
            try
            {
                XDocument doc = XDocument.Load(_tableFile);

                var target = doc.Root.Elements(ELEMENTNAME).Where(e => e.Element("Id").Value.Equals(companyToUpdate.Id.ToString())).Single();
                target.Element("CompanyName").Value = companyToUpdate.CompanyName;
                target.Element("Name").Value = companyToUpdate.Name;
                target.Element("Street").Value = companyToUpdate.Street;
                target.Element("Zip").Value = companyToUpdate.Zip;
                target.Element("City").Value = companyToUpdate.City;
                target.Element("Telephone").Value = companyToUpdate.Telephone;
                target.Element("Fax").Value = companyToUpdate.Fax;
                target.Element("Email").Value = companyToUpdate.Email;

                target.Element("BillTemplateFile").Value = companyToUpdate.TemplateBillPath;

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("{0}.Update({1})", this.GetType().FullName, companyToUpdate));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("{0}.Update({1})", this.GetType().FullName, companyToUpdate), e);
                throw e;
            }
        }

        public void UpdateDataBaseVersion(int newVersion)
        {
            try
            {
                XDocument doc = XDocument.Load(_tableFile);

                var target = doc.Root.Elements(ELEMENTNAME).FirstOrDefault();
                target.Element("DatabaseVersion").Value = newVersion.ToString();

                doc.Save(_tableFile);
                _database.Logger.LogInfo(string.Format("{0}.UpdateDataBaseVersion({1})", this.GetType().FullName, newVersion));
            }
            catch (Exception e)
            {
                _database.Logger.LogError(string.Format("{0}.UpdateDataBaseVersion({1})", this.GetType().FullName, newVersion), e);
                throw e;
            }
        }
    }
}
