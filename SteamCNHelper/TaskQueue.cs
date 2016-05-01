using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCNHelper
{
    static class TaskQueue
    {
        static Queue<string> queue = new Queue<string>();
        public static void Enqueue(string str)
        {
            queue.Enqueue(str);
        }
        public static string Dequeue()
        {
            return queue.Dequeue();
        }
        public static bool Empty()
        {
            return queue.Count == 0;
        }
        public static int Count()
        {
            return queue.Count;
        }
    }
}
