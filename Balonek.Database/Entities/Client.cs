using System.Collections.Generic;

namespace Balonek.Database.Entities
{
    public class Client : BaseEntity
    {
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
            dictionary.Add("%clientid%", Id.ToString());
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
