﻿using System.Collections.Generic;

namespace Balonek.Database.Entities
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        public string BankName { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }
        public string TaxNr { get; set; }

        public int DataBaseVersion { get; set; }
        public string TemplateBillPath { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Id, Name);
        }

        public Dictionary<string, string> StringReplacementDictionary()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("%UNTERNEHMEN%", string.Empty);
            dictionary.Add("%comcompanyname%", CompanyName);
            dictionary.Add("%comname%", Name);
            dictionary.Add("%comstreet%", Street);
            dictionary.Add("%comzip%", Zip);
            dictionary.Add("%comcity%", City);
            dictionary.Add("%comtelephone%", Telephone);
            dictionary.Add("%comfax%", Fax);
            dictionary.Add("%comemail%", Email);
            dictionary.Add("%combank%", BankName);
            dictionary.Add("%comiban%", Iban);
            dictionary.Add("%combic%", Bic);
            dictionary.Add("%comtaxnr%", TaxNr);
            return dictionary;
        }
    }
}
