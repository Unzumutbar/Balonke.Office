using System;
using System.Collections.Generic;
using System.ComponentModel;
using Unzumutbar.Extensions;

namespace Balonek.Database.Entities
{
    public class Bill : BaseEntity
    {
        public Bill()
        {
            Client = new Client();
        }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal Total { get; set; }
        public Client Client { get; set; }
        public BillStatus Status { get; set; }
        public List<BillPosition> Positions { get; set; }
        public override string ToString()
        {
            return string.Format("{0} - {1}", Client.Name, DateFrom.ToMonthAndYearGerman());
        }

        public Dictionary<string, string> StringReplacementDictionary(Company company = null)
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("%billid%", Id.ToString());
            dictionary.Add("%billdate%", DateTime.Now.ToBillDate());
            dictionary.Add("%monthfrom%", DateFrom.ToMonthGerman());
            dictionary.Add("%monthto%", DateTo.ToMonthGerman());
            dictionary.Add("%month%", DateTo.ToMonthGerman());
            dictionary.Add("%year%", DateTo.Year.ToString());
            dictionary.Add("%totalsum%", Total.ToString("N2"));

            if (company == null)
                company = new Company();

            foreach (var tuple in company.StringReplacementDictionary())
                dictionary.Add(tuple.Key, tuple.Value);

            foreach (var tuple in Client.StringReplacementDictionary())
                dictionary.Add(tuple.Key, tuple.Value);

            int posnr = 1;
            foreach (var position in Positions)
            {
                foreach (var tuple in position.StringReplacementDictionary())
                {
                    dictionary.Add(tuple.Key.Replace("pos", "pos" + posnr), tuple.Value);
                }
                posnr++;
            }
            return dictionary;
        }
    }

    public enum BillStatus
    {
        [Description("ungedruckt")]
        NotPrinted = 1,

        [Description("gedruckt")]
        Printed = 2,

        [Description("bezahlt")]
        Payed = 4,
    };
}
