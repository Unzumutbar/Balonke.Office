using System;
using System.Collections.Generic;
using System.ComponentModel;
using Unzumutbar.Extensions;

namespace Balonek.Database.Entities
{
    public enum PositionType
    {
        [Description("Einzel")]
        Single = 1,

        [Description("Regelmäßig")]
        Periodical = 2,
    };

    public enum Period
    {
        [Description("")]
        None = 0,

        [Description("Wöchentlich")]
        Weekly = 1,

        [Description("Alle zwei Wochen")]
        BiWeekly = 2,

        [Description("Alle drei Wochen")]
        TriWeekly = 3,

        [Description("Alle vier Wochen")]
        QuarterWeekly = 4,

        [Description("Monatlich")]
        Monthly = 5,
    };

    public class BillPosition : BaseEntity
    {
        public BillPosition()
        {
            Client = new Client();
        }
        public PositionType Type { get; set; }
        public Client Client { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Period Period { get; set; }
        public decimal Time { get; set; }
        public decimal Rate { get; set; }
        public decimal Total
        {
            get { return Time * Rate; }
        }

        public override string ToString()
        {
            if (Type == PositionType.Single)
                return string.Format("{0} {1}", Date.ToString("yyyy-MM-dd"), Client.Name);

            var culture = new System.Globalization.CultureInfo("de-DE");
            return string.Format("{0} - {1}, {2}", culture.DateTimeFormat.GetDayName(Date.DayOfWeek).ToString(), Client.Name, Period.GetDescription());
        }

        public Dictionary<string, string> StringReplacementDictionary()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("%POSITIONpos%", string.Empty);
            dictionary.Add("%posdescription%", Description);
            dictionary.Add("%posdate%", Date.ToString("dd.MM.yyyy"));
            dictionary.Add("%postime%", Time.ToString());
            dictionary.Add("%posrate%", Rate.ToString("N2"));
            dictionary.Add("%postotal%", Total.ToString("N2"));
            return dictionary;
        }
    }
}
