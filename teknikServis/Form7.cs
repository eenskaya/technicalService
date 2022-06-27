using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teknikServis
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\teknikServis\teknikservis.mdf; Integrated Security = true;");

        private void button1_Click(object sender, EventArgs e)
        {
            string ürün_durumu = lbl_ürün_durumu.Text;
            if (ürün_durumu=="Hazır")
            {
                baglanti.Open();


                //SqlCommand cmd2 = new SqlCommand("UPDATE urunler SET  ürün_adı='" + ürün_adi.Text + "',ürün_markası='" + ürün_markasi.Text + "',ürün_sorunu='" + ürün_sorunu.Text + "',ürün_yapılan_islem='" + yapılan_islem.Text + "',ürün_sayısı='" + ürün_sayisi.Text + "',ürün_fiyatı='" + toplam_fiyat.Text + "',tarih='" + teslim_tarihi.Value + "' ,müsteri_adi='" + müsteri_adi.Text + "' ,müsteri_soyadi='" + müsteri_soyadi.Text + "' ,müsteri_telefon='" + müsteri_telefon.Text + "' ,müsteri_email='" + müsteri_email.Text + "' where id='" + urun_no.Text + "'", baglanti);
                //cmd2.ExecuteNonQuery();


                using (SqlCommand cmd = new SqlCommand())
                {
                    string sql = @"UPDATE urunler SET  ürün_durumu=@ürün_durumu,tarih=@tarih where id=@id";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@id", lbl_ürün_no.Text);
                    cmd.Parameters.AddWithValue("@ürün_durumu", "Teslim Edildi");
                    cmd.Parameters.AddWithValue("@tarih",DateTime.Today.Date);
                    cmd.Connection = baglanti;

                    cmd.ExecuteNonQuery();
                }


     
                MessageBox.Show("Ürün Teslim Edildi Ödemesi Alındı!", "Ürün durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();

                var myForm = new Form2();
                myForm.Show();
                baglanti.Close();


            }
            else
            {
                this.Hide();
                var myForm = new Form2();
                myForm.Show();
                MessageBox.Show("Ürün Teslime Hazır Değil", "Ürün Durumu",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new System.Drawing.Size(960, 440);
            this.MinimumSize = new System.Drawing.Size(960, 440);
        }
    }
}
