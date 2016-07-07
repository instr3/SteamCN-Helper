namespace SteamCNHelper
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("123");
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.LVPriceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LVAuthorColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LVTextColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.taskTimer = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMaxPage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(262, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "登陆";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(180, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "加载";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(350, 14);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(276, 102);
            this.textBox1.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LVPriceColumn,
            this.LVAuthorColumn,
            this.LVTextColumn});
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(181, 122);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(445, 254);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // LVPriceColumn
            // 
            this.LVPriceColumn.Text = "价格";
            // 
            // LVAuthorColumn
            // 
            this.LVAuthorColumn.Text = "作者";
            // 
            // LVTextColumn
            // 
            this.LVTextColumn.Text = "内容";
            this.LVTextColumn.Width = 308;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(561, 271);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "匹配";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(181, 95);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(156, 21);
            this.textBox2.TabIndex = 3;
            // 
            // taskTimer
            // 
            this.taskTimer.Enabled = true;
            this.taskTimer.Interval = 500;
            this.taskTimer.Tick += new System.EventHandler(this.taskTimer_Tick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(262, 66);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "搜索";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 12;
            this.listBox.Location = new System.Drawing.Point(22, 26);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(152, 316);
            this.listBox.TabIndex = 4;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            this.listBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "愿望单";
            // 
            // textBoxMaxPage
            // 
            this.textBoxMaxPage.Location = new System.Drawing.Point(180, 45);
            this.textBoxMaxPage.Name = "textBoxMaxPage";
            this.textBoxMaxPage.Size = new System.Drawing.Size(53, 21);
            this.textBoxMaxPage.TabIndex = 3;
            this.textBoxMaxPage.Text = "5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "页";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(70, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(22, 21);
            this.button5.TabIndex = 6;
            this.button5.Text = "新";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(98, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(22, 21);
            this.button6.TabIndex = 6;
            this.button6.Text = "删";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(126, 5);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(22, 21);
            this.button7.TabIndex = 6;
            this.button7.Text = "改";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(21, 353);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(153, 23);
            this.button8.TabIndex = 0;
            this.button8.Text = "搜索愿望单";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(262, 44);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "强制更新";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 388);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.textBoxMaxPage);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "SteamCN交易区搜索工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader LVPriceColumn;
        private System.Windows.Forms.ColumnHeader LVAuthorColumn;
        private System.Windows.Forms.ColumnHeader LVTextColumn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Timer taskTimer;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMaxPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

