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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\teknikServis\teknikservis.mdf; Integrated Security = true;");

        private void Form4_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new System.Drawing.Size(870, 495);
            this.MinimumSize = new System.Drawing.Size(870, 495);

            baglanti.Open();
            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From urunler", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "urunler");
            dataGridView1.DataSource = dataset.Tables["urunler"];
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();


            //SqlCommand cmd2 = new SqlCommand("UPDATE urunler SET  ürün_adı='" + ürün_adi.Text + "',ürün_markası='" + ürün_markasi.Text + "',ürün_sorunu='" + ürün_sorunu.Text + "',ürün_yapılan_islem='" + yapılan_islem.Text + "',ürün_sayısı='" + ürün_sayisi.Text + "',ürün_fiyatı='" + toplam_fiyat.Text + "',tarih='" + teslim_tarihi.Value + "' ,müsteri_adi='" + müsteri_adi.Text + "' ,müsteri_soyadi='" + müsteri_soyadi.Text + "' ,müsteri_telefon='" + müsteri_telefon.Text + "' ,müsteri_email='" + müsteri_email.Text + "' where id='" + urun_no.Text + "'", baglanti);
            //cmd2.ExecuteNonQuery();


            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @"UPDATE urunler SET  ürün_adı=@ürün_adı,ürün_markası=@ürün_markası,ürün_sorunu=@ürün_sorunu,ürün_yapılan_islem=@ürün_yapılan_islem,ürün_durumu=@ürün_durumu,ürün_sayısı=@ürün_sayısı,ürün_fiyatı=@ürün_fiyatı,tarih=@tarih,müsteri_adi=@müsteri_adi,müsteri_soyadi=@müsteri_soyadi,müsteri_telefon=@müsteri_telefon,müsteri_email=@müsteri_email where id=@id";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", urun_no.Text);
                cmd.Parameters.AddWithValue("@ürün_adı", ürün_adi.Text);
                cmd.Parameters.AddWithValue("@ürün_markası", ürün_markasi.Text);
                cmd.Parameters.AddWithValue("@ürün_sorunu", ürün_sorunu.Text);
                cmd.Parameters.AddWithValue("@ürün_yapılan_islem", yapılan_islem.Text);
                cmd.Parameters.AddWithValue("@ürün_durumu", "Hazır");
                cmd.Parameters.AddWithValue("@ürün_sayısı", Convert.ToInt32(ürün_sayisi.Text));
                cmd.Parameters.AddWithValue("@ürün_fiyatı", Convert.ToInt32(toplam_fiyat.Text));
                cmd.Parameters.AddWithValue("@tarih", (teslim_tarihi.Value.Date));
                cmd.Parameters.AddWithValue("@müsteri_adi", müsteri_adi.Text);
                cmd.Parameters.AddWithValue("@müsteri_soyadi", müsteri_soyadi.Text);
                cmd.Parameters.AddWithValue("@müsteri_telefon", müsteri_telefon.Text);
                cmd.Parameters.AddWithValue("@müsteri_email", müsteri_email.Text);
                cmd.Connection = baglanti;

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Ürün Tamir Edildi Teslime Hazır !", "Ürün Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);




            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From urunler", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "urunler");
            dataGridView1.DataSource = dataset.Tables["urunler"];

            this.Hide();

            var myForm = new Form2();
            myForm.Show();
            baglanti.Close();
        }

        private void müsteri_adi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
