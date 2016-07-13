using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balonek.Office.Objects
{
    public class BillPositionText
    {
        public static string NODENAME = "BillPositionTexts";
        public static string ELEMENTNAME = "BillPositionText";

        public int Id { get; set; }
        public string Text { get; set; }
    }
}
