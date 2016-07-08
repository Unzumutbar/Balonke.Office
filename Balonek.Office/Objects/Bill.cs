using System;

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
        public override string ToString()
        {
            return string.Format("{0} {1}", Client.Name, DateFrom.ToString("MMMM, yyyy"));
        }
    }
}
