using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCNHelper
{
    [Serializable]
    class ForumThread
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime PostTime { get; set; }

        public DateTime LastModifiedTime { get; set; }

        public ItemLine[] Lines { get; set; }
        public ForumThread(string url)
        {
            string source;
            try
            {
                source = Poster.GetStatic(url, Poster.LoginCookie).Replace("\t","");
            }
            catch(Exception e)
            {
                throw e;
            }
            ID = int.Parse(Common.StrBetween(url, "tid-", ".html"));
            Name = Common.StrBetween(source, "<h3>", "</h3>");
            Author = Common.StrBetween(source, "<p class=\"author\">\n<strong>", "</strong>");
            //string tempTime = Common.StrBetween(source, "</strong>\n发表于 ", " </p>");
            //if (tempTime[0] == '<')
            //{
            //    tempTime = Common.StrBetween(tempTime, "<span title=\"", "\">");
            //}
            //PostTime = DateTime.Parse(tempTime);
            //if (source.IndexOf("<h3>" + Name + "</h3>\n本帖最后由 " + Author + " 于 ") >= 0)
            //{
            //    LastModifiedTime = DateTime.Parse(Common.StrBetween(source, "本帖最后由 " + Author + " 于 ", " 编辑 <br/>"));
            //}
            //else LastModifiedTime = PostTime;
            string wholeThread = Common.StrBetween(source, "<p class=\"author\">\n", "<div class=\"page\">");
            int pos = wholeThread.IndexOf("<p class=\"author\">");
            if (pos >= 0)
            {
                wholeThread = wholeThread.Substring(0, pos);
            }
            string[] strlines = wholeThread.Replace("<br/>", "").Replace("&nbsp;", " ").Split('\n').Where(s => (s.Length < 4 || s.Substring(0, 4) != "<h3>") && s != "").ToArray();
            int n = strlines.Length;
            Lines = new ItemLine[n];
            float context = 0f;
            for (int i = 0; i < n; ++i)
            {
                string str = strlines[i];
                float tmpContext;
                if (Extractor.IsPriceContext(str, out tmpContext))
                {
                    context = tmpContext;
                }
                Lines[i] = new ItemLine(str, Extractor.GetSellingItemPrice(str, context), ID);
            }
        }
    }
}
