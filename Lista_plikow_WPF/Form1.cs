using System;
using System.IO;
using System.Windows.Forms;

namespace Lista_plikow_WPF
{
    public partial class Form1 : Form
    {
        #region inicjalizacja formsa
        public Form1()
        {
            InitializeComponent();
            label1.Text = ("Witaj w przeglądarce plików, aby rozpocząć kliknij start :>");
        }
        #endregion
        #region przycisk start folderbrowser
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                string[] files = Directory.GetFiles(FBD.SelectedPath, "*.exe", SearchOption.TopDirectoryOnly);
                string[] files2 = Directory.GetFiles(FBD.SelectedPath, "*.lnk", SearchOption.TopDirectoryOnly);
                string[] dirs = Directory.GetDirectories(FBD.SelectedPath);

                foreach(string file in files)
                {
                    listBox1.Items.Add(Path.GetFileName(file));
                }
                foreach (string file in files2)
                {
                    listBox1.Items.Add(Path.GetFileName(file));
                }
            }
        }
        #endregion
        #region zamykanie 
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
        #region test
        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region biezacy katalog
        private void button3_Click(object sender, EventArgs e)
        {
            string dir = Directory.GetCurrentDirectory();
            string[] file = Directory.GetFiles(dir, "*.exe", SearchOption.TopDirectoryOnly);
            string[] file2 = Directory.GetFiles(dir, "*.lnk", SearchOption.TopDirectoryOnly);

            foreach(string first in file)
            {
                listBox1.Items.Add(Path.GetFileName(first));
            }
            foreach (string second in file2)
            {
                listBox1.Items.Add(Path.GetFileName(second));
            }
        }
        #endregion
        #region czyszczenie listboxa
        private void button4_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
        }
        #endregion
        #region dodanie notifyicona + toolstripmenu
        /// <summary>
        /// z przybornika nalezy wybraz notifyicon i strip menu item, nastepnie dodac opcje przywroc i zamknij w liscie rozwijanej
        /// zaimplementowac funkcjonalnosci
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.Text = "Schowaj";
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            this.ShowInTaskbar = false;
            this.Visible = false;
        }

        private void przywróćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
            notifyIcon1.Visible = false;
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
