using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SteamCNHelper
{
    public partial class Form1 : Form
    {
        public bool wishListMode = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Manager.ReadWishList();
            UpdateWishlist();
            listView1.Items.Clear();
            Poster.AddCookieInString("steamcn.com", FullWebBrowserCookie.GetCookieInternal(new Uri("http://steamcn.com"), false), ref Poster.LoginCookie);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ItemLinePool.Clear();
            int limit = int.Parse(textBoxMaxPage.Text);
            for (int page = 1; page <= limit; ++page)
            {
                TaskQueue.Enqueue("http://steamcn.com/archiver/fid-201.html?page=" + page);
            }
            //ForumThread th = new ForumThread("http://steamcn.com/archiver/tid-128535.html");
            //string src = Poster.GetStatic("http://steamcn.com/archiver/tid-128535.html", Poster.LoginCookie);

            //MessageBox.Show("begin");
            //Match a = Regex.Match(src, @"(?<=<p class=""author"">)[^\a]*(?=<h3>)");
            //MessageBox.Show("done");
            //var lines = a.Value.Split('\n');
            //foreach(string i in lines)
            //{
            //    listView1.Items.Add(new ListViewItem(i));
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float res = 0f;
            Extractor.IsPriceContext(textBox2.Text, out res);
            textBox1.Text = "是否是价格上下文：" + res.ToString() + Environment.NewLine +
                "是否是商品价目：" + Extractor.GetSellingItemPrice(textBox2.Text, 0f);
        }
        private void taskTimer_Tick(object sender, EventArgs e)
        {
            if (!TaskQueue.Empty())
            {
                string url = TaskQueue.Dequeue();
                if (url.IndexOf("fid") >= 0)
                {
                    string content = Common.StrBetween(Poster.GetStatic(url, Poster.LoginCookie), "<ul type=\"1\" start=\"1\">", "</ul>");
                    Match match = Regex.Match(content, @"tid-(?<id>\d+)\.html""\>(?<t>[^\<]*)\<");
                    while (match.Success)
                    {
                        //Console.WriteLine();
                        int id = int.Parse(match.Groups["id"].Value);
                        ForumThread ft = Manager.ReadThread(id);
                        if (ft == null || ft.Name != match.Groups["t"].Value)
                        {
                            TaskQueue.Enqueue("http://steamcn.com/archiver/tid-" + id.ToString() + ".html");
                        }
                        else
                        {
                            ItemLinePool.AddItemLine(ft.Lines);
                        }
                        match = match.NextMatch();
                    }

                }
                else if (url.IndexOf("tid") >= 0)
                {
                    ForumThread ft;
                    try
                    {
                        ft = new ForumThread(url);
                    }
                    catch (Exception)
                    {
                        TaskQueue.Enqueue(url);
                        return;
                    }
                    Manager.SaveThread(ft);
                    ItemLinePool.AddItemLine(ft.Lines);
                }
            }
            else return;
            textBox1.Text = ItemLinePool.Pool.Count.ToString() + "行（总计）" + Environment.NewLine + "任务队列：" + TaskQueue.Count().ToString();

            if (wishListMode)
            {
                button8_Click(sender, e);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            wishListMode = false;
            listView1.Items.Clear();
            ItemLine[] res = ItemLinePool.FindByString(textBox2.Text);
            foreach (ItemLine i in res)
            {
                listView1.Items.Add(new ListViewItem(new string[] { i.Price == 0f ? "不详" : i.Price.ToString(), i.ThreadID.ToString(), i.Str }));
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string tid = listView1.SelectedItems[0].SubItems[1].Text;
            System.Diagnostics.Process.Start("http://steamcn.com/t" + tid + "-1-1");
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex!=-1)
                textBox2.Text=Wishlist.list[listBox.SelectedIndex];
        }


        private void UpdateWishlist()
        {
            listBox.Items.Clear();
            foreach(string str in Wishlist.list)
            {
                listBox.Items.Add(str);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Wishlist.list.Add(textBox2.Text);
            UpdateWishlist();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Wishlist.list.RemoveAt(listBox.SelectedIndex);
            UpdateWishlist();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                Wishlist.list[listBox.SelectedIndex] = textBox2.Text;
                UpdateWishlist();
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Manager.SaveWishList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (string str in Wishlist.list)
            {
                ItemLine[] res = ItemLinePool.FindByStringGroup(str.Split(';'));
                foreach (ItemLine i in res)
                {
                    listView1.Items.Add(new ListViewItem(new string[] { i.Price == 0f ? "不详" : i.Price.ToString(), i.ThreadID.ToString(), i.Str }));
                }
            }
        }

        private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                textBox2.Text = Wishlist.list[listBox.SelectedIndex];
                button4_Click(sender, e);
            }
        }
    }
}
