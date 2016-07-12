using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balonek.Office.Utils
{
    public static class ListExtensions
    {
        private static Random rnd = new Random();
        public static T Random<T>(this List<T> list)
        {
            int r = rnd.Next(list.Count);
            return list[r];
        }
    }
}
