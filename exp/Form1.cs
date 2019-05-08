using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDirectory_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = imageList1.Images[0];

            string dir = "c:\\windows";
            //string dir = @"c:\windows";
            DirectoryInfo d = new DirectoryInfo(dir);

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                d = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                textBoxPath.Text = d.FullName;
                FileInfo[] files = d.GetFiles();
                listBoxFiles.Items.Clear();
                imageList1.ImageSize = new Size(32, 32);
                foreach (var f in files)
                {
                    listBoxFiles.Items.Add(f.Name + " " + f.Length);
                    //string[] s = new string[] { f.Name, f.Length.ToString() };
                    //ListViewItem item = new ListViewItem(s);
                    //listViewFiles.Items.Add(item);
                    listViewFiles.Items.Add(new ListViewItem(new string[] { f.Name, f.Length.ToString(), f.Extension }));
                    
                    
                }
                this.listViewFiles.LargeImageList = imageList1;
            }

        }
    }
}
