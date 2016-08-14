using System;
using System.Collections.Generic;
using Balonek.Office.Utils;
using static Balonek.Office.Utils.Enums;

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
        public PositionType Type { get; set; }
        public Client Client { get; set; }
        public string Description { get; set; }
        public DateTime Date  { get; set; }
        public Period Period { get; set; }
        public decimal Time { get; set; }
        public decimal Rate { get; set; }
        public decimal Total
        {
            get { return Time * Rate; }
        }

        public override string ToString()
        {
            if(Type == PositionType.Single)
                return string.Format("{0} {1}", Date.ToString("yyyy-MM-dd"), Client.Name);

            var culture = new System.Globalization.CultureInfo("de-DE");
            return string.Format("{0} - {1}, {2}", culture.DateTimeFormat.GetDayName(Date.DayOfWeek).ToString(), Client.Name, Period.GetDescription());
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
