using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCNHelper
{
    static class ItemLinePool
    {
        public static List<ItemLine> Pool { get; set; }

        static ItemLinePool()
        {
            Pool = new List<ItemLine>();
        }

        public static void AddItemLine(ItemLine[] arr)
        {
            foreach (ItemLine i in arr) Pool.Add(i);
        }

        public static ItemLine[] FindByString(string str)
        {
            str = str.ToLower();
            return Pool.Where(i => i.Str.ToLower().IndexOf(str) >= 0).ToArray();
        }

        public static ItemLine[] FindByStringGroup(string[] str)
        {
            str = str.Select(s => s.ToLower()).ToArray();
            return Pool.Where(i => str.Any(s=>i.Str.ToLower().IndexOf(s)>=0)).ToArray();
        }
        public static void Clear()
        {
            Pool.Clear();
        }
    }
}
