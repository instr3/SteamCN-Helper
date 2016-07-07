using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamCNHelper
{
    class ListViewColumnComparer : IComparer
    {
        private int col;
        private bool rev;
        public int Column
        {
            get { return col; }
        }
        public bool Reverse
        {
            get { return rev; }
        }
        public ListViewColumnComparer()
        {
            col = 0;
            rev = false;
        }
        public ListViewColumnComparer(int column, bool reverse)
        {
            col = column;
            rev = reverse;
        }
        public int RawCompare(object x, object y)
        {
            if (col == 0)
            {
                string sx = ((ListViewItem)x).Text, sy = ((ListViewItem)y).Text;
                float res = (sx == "不详" ? 9e9f : float.Parse(sx)) - (sy == "不详" ? 9e9f : float.Parse(sy));
                return res > 0 ? 1 : res == 0 ? 0 : -1;
            }
            else return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
        }
        public int Compare(object x, object y)
        {
            return rev ? -RawCompare(x, y) : RawCompare(x, y);
        }
    }
}
