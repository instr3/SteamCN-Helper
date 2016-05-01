using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCNHelper
{
    [Serializable]
    class ItemLine
    {
        public string Str { get; set; }

        public float Price { get; set; }

        public float ModifiedPrice { get; set; }

        public int ThreadID { get; set; }

        public ItemLine(string str, float calc_price, int tid)
        {
            Str = str;
            Price = calc_price;
            ThreadID = tid;
        }
    }
}
