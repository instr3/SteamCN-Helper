using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace SteamCNHelper
{
    class Poster
    {
        public static CookieContainer LoginCookie = new CookieContainer();
        public static string GlobalEncoding = "gb2312"; //gb2312 or utf-8
        public static void AddCookieInString(string siteName, string cookieStr, ref CookieContainer cookies)
        {
            string[] cookstr = cookieStr.Split(';');
            foreach (string str in cookstr)
            {
                int pos = str.IndexOf('=');
                Cookie ck = new Cookie(str.Substring(0, pos).Trim(), str.Substring(pos + 1).Trim());
                ck.Expires = DateTime.Now.AddMonths(1);
                //ck.Expired = false;
                //cookies.Add(new Uri("http://"+siteName), ck);
                ck.Domain = siteName;
                cookies.Add(ck);
            }
        }
        public static string PostLogin(string url, string param, ref CookieContainer cookies)
        {
            try
            {
                byte[] bs = Encoding.UTF8.GetBytes(param);
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Timeout = 60000;
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = bs.Length;
                req.CookieContainer = new CookieContainer();
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                }
                HttpWebResponse httpWebResponse = (HttpWebResponse)req.GetResponse();
                cookies.Add(req.CookieContainer.GetCookies(req.RequestUri));
                Stream stream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding(GlobalEncoding));
                string result = streamReader.ReadToEnd();
                stream.Close();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public static string PostStatic(string url, string param, CookieContainer cookies)
        {
            try
            {
                byte[] bs = Encoding.UTF8.GetBytes(param);
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Timeout = 10000;
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = bs.Length;
                req.CookieContainer = cookies;
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                }
                HttpWebResponse httpWebResponse = (HttpWebResponse)req.GetResponse();
                Stream stream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding(GlobalEncoding));
                string result = streamReader.ReadToEnd();
                stream.Close();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public static string GetStatic(string url, CookieContainer cookies)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Timeout = 10000;
                req.Method = "GET";
                req.ContentType = "application/x-www-form-urlencoded";
                req.CookieContainer = cookies;
                HttpWebResponse httpWebResponse = (HttpWebResponse)req.GetResponse();
                Stream stream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding(GlobalEncoding));
                string result = streamReader.ReadToEnd();
                stream.Close();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
