using System;
using System.Collections.Generic;

namespace Balonek.Office.Objects
{
    public class BillPosition
    {
        public static string NODENAME = "BillPositions";
        public static string ELEMENTNAME = "BillPosition";

        public BillPosition()
        {
            Client = new Client();
        }
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public string Description { get; set; }
        public DateTime Date  { get; set; }
        public decimal Time { get; set; }
        public decimal Rate { get; set; }
        public decimal Total
        {
            get { return Time * Rate; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Date.ToString("yyyy-MM-dd"), Client.Name);
        }

        public Dictionary<string, string> StringReplacementDictionary()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("%posdescription%", Description);
            dictionary.Add("%posdate%", Total.ToString());
            dictionary.Add("%postime%", Time.ToString());
            dictionary.Add("%posrate%", Rate.ToString());
            dictionary.Add("%postotal%", Total.ToString());
            return dictionary;
        }
    }
}
