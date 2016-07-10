using System;
using System.Collections.Generic;

namespace Balonek.Office.Objects
{
    public class Bill
    {
        public static string NODENAME = "Bills";
        public static string ELEMENTNAME = "Bill";

        public Bill()
        {
            Client = new Client();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal Total { get; set; }
        public Client Client { get; set; }
        public List<BillPosition> Positions { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1}", Client.Name, DateFrom.ToString("MMMM, yyyy"));
        }

        public Dictionary<string, string> StringReplacementDictionary()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("%monthfrom%", DateFrom.ToString("MMMM"));
            dictionary.Add("%monthto%", DateTo.ToString("MMMM"));
            dictionary.Add("%totalsum%", Total.ToString());
            foreach (var tuple in Client.StringReplacementDictionary())
                dictionary.Add(tuple.Key, tuple.Value);

            int posnr = 1;
            foreach(var position in Positions)
            {
                foreach (var tuple in position.StringReplacementDictionary())
                {
                    dictionary.Add(tuple.Key.Replace("pos", "pos" + posnr), tuple.Value);
                }
                posnr++;
            }
            for(int i = posnr; posnr <= 10; posnr++)
            {
                var position = new BillPosition();
                foreach (var tuple in position.StringReplacementDictionary())
                {
                    var tupleValue = 0m;
                    if(Decimal.TryParse(tuple.Value, out tupleValue))
                        dictionary.Add(tuple.Key.Replace("pos", "pos" + posnr), string.Empty);
                    else
                    dictionary.Add(tuple.Key.Replace("pos", "pos" + posnr), tuple.Value);
                }
            }
            return dictionary;
        }
        
    }
}
