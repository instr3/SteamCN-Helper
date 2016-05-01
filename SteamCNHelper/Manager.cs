using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SteamCNHelper
{
    static class Manager
    {
        public static void SaveThread(ForumThread forumThread)
        {
            using (Stream stream = File.Open("Thread\\" + forumThread.ID.ToString() + ".scn", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, forumThread);
            }
        }
        public static ForumThread ReadThread(int ID)
        {
            ForumThread forumThread;
            try
            {
                using (Stream stream = File.Open("Thread\\" + ID.ToString() + ".scn", FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    forumThread = bf.Deserialize(stream) as ForumThread;
                }
                return forumThread;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static void SaveWishList()
        {
            using (Stream stream = File.Open("Wishlist.scn", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, Wishlist.list);
            }
        }
        public static void ReadWishList()
        {
            try
            {
                using (Stream stream = File.Open("Wishlist.scn", FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Wishlist.list = bf.Deserialize(stream) as List<string>;
                }
            }
            catch (Exception e)
            {
                Wishlist.list = new List<string>();
            }
        }
    }
}
