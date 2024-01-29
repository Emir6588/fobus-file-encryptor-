using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fobus_1._0
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Byte[] dosya = File.ReadAllBytes(label2.Text);
            for (int i = 0; i < dosya.Length; i++)
            {
                dosya[i] = (Byte)((int)dosya[i] + 1);
                if (dosya[i] > 255)
                {
                    dosya[i] = 0;

                }
            }
            File.WriteAllBytes(textBox1.Text, dosya);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Byte[] dosya = File.ReadAllBytes(label2.Text);
            for (int i = 0; i < dosya.Length; i++)
            {
                if ((Byte)((int)dosya[i] - 1) < 0)
                {
                    dosya[i] = 255;
                }
                else
                    dosya[i] = (Byte)((int)dosya[i] - 1);

            }
            File.WriteAllBytes(textBox1.Text, dosya);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                label2.Text = dlg.FileName;
                textBox1.Text = dlg.FileName;
            }  
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Locker lck = new Locker();
            lck.Show();
            this.Hide();
        }
    }
}
