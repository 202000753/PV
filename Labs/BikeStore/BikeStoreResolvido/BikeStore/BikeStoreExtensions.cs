using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore
{
    public static class BikeStoreExtensions
    {
        public static bool ContainsAny(this string text, params string[] words )
        {
            foreach (string word in words)
            {
                if (text.Contains(word))
                    return true;
            }

            return false;
        }
    }
}
