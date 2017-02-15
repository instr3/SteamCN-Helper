using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamCNHelper
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://steamcn.com/");
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Poster.AddCookieInString("steamcn.com", FullWebBrowserCookie.GetCookieInternal(new Uri("https://steamcn.com"), false), ref Poster.LoginCookie);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
