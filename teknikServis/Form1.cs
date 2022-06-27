using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teknikServis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string kullaniciadi = textBox1.Text;
            string kullaniciparola = textBox2.Text;
            if (kullaniciadi=="teknik"&&kullaniciparola=="teknik123")
            {
                var myForm = new Form2();
                myForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı bilgileri yanlış");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new System.Drawing.Size(390, 200);
            this.MinimumSize = new System.Drawing.Size(390, 200);
        }
    }
}
