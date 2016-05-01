using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCNHelper
{
    static class Common
    {
        public static string StrBetween(string source, string from, string to)
        {
            int nf = from.Length;
            int i = source.IndexOf(from);
            if (i < 0)
            {
                throw new Exception("String Not Found");
            }
            int j = source.IndexOf(to, i + nf);
            if (j < 0)
            {
                throw new Exception("String Not Found");
            }
            return source.Substring(i + nf, j - i - nf);
        }
    }
}
