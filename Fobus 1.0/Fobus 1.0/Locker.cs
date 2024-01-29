using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fobus_1._0
{
    public partial class Locker : Form
    {
        public Locker()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login form1 = new Login();
            form1.Show();  // form2 göster diyoruz
            this.Hide();   // bu yani form1 gizle diyoruz
        }

        private void btnAc_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnKilit_Click(object sender, EventArgs e)
        {
            try
            {
                string dosyaYeri = textBox1.Text;
                string kullaniciAdi = Environment.UserName;
                DirectorySecurity ds = Directory.GetAccessControl(dosyaYeri);
                FileSystemAccessRule fsa = new FileSystemAccessRule(kullaniciAdi, FileSystemRights.FullControl, AccessControlType.Deny);
                ds.AddAccessRule(fsa);
                Directory.SetAccessControl(dosyaYeri, ds);
                MessageBox.Show("Locked");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKaldir_Click(object sender, EventArgs e)
        {
            try
            {
                string dosyaYeri = textBox1.Text;
                string kullaniciAdi = Environment.UserName;
                DirectorySecurity ds = Directory.GetAccessControl(dosyaYeri);
                FileSystemAccessRule fsa = new FileSystemAccessRule(kullaniciAdi, FileSystemRights.FullControl, AccessControlType.Deny);
                ds.RemoveAccessRule(fsa);
                Directory.SetAccessControl(dosyaYeri, ds);
                MessageBox.Show("Lock Removed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
