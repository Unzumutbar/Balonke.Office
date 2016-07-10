using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balonek.Office.Objects
{
    public class Client
    {
        public static string NODENAME = "Clients";
        public static string ELEMENTNAME = "Client";
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Id, Name);
        }

        public Dictionary<string, string> StringReplacementDictionary()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("%name%", Name);
            dictionary.Add("%street%", Street);
            dictionary.Add("%zip%", Zip);
            dictionary.Add("%city%", City);
            dictionary.Add("%telephone%", Telephone);
            dictionary.Add("%fax%", Fax);
            dictionary.Add("%email%", Email);
            return dictionary;
        }
    }
}
