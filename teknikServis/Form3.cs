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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\teknikServis\teknikservis.mdf; Integrated Security = true;");

        private void Form3_Load(object sender, EventArgs e)
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

            using (SqlCommand cmd = new SqlCommand())
            {
                string sql = @"insert into urunler (ürün_adı,ürün_markası,ürün_sorunu,ürün_durumu,ürün_sayısı,tarih,müsteri_adi,müsteri_soyadi,müsteri_telefon,müsteri_email)  VALUES (@ürün_adı, @ürün_markası, @ürün_sorunu, @ürün_durumu, @ürün_sayısı, @tarih, @müsteri_adi, @müsteri_soyadi, @müsteri_telefon, @müsteri_email)";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ürün_adı", ürün_adi.Text);
                cmd.Parameters.AddWithValue("@ürün_markası", ürün_markasi.Text);
                cmd.Parameters.AddWithValue("@ürün_sorunu", ürün_sorunu.Text);
                //cmd.Parameters.AddWithValue("@ürün_yapılan_islem", ürün_sorunu.Text);
                cmd.Parameters.AddWithValue("@ürün_durumu", "Serviste");
                cmd.Parameters.AddWithValue("@ürün_sayısı", Convert.ToInt32(ürün_sayisi.Text));
                //cmd.Parameters.AddWithValue("@ürün_fiyatı", Convert.ToInt32(100));
                cmd.Parameters.AddWithValue("@tarih", (teslim_tarihi.Value.Date));
                cmd.Parameters.AddWithValue("@müsteri_adi", müsteri_adi.Text);
                cmd.Parameters.AddWithValue("@müsteri_soyadi", müsteri_soyadi.Text);
                cmd.Parameters.AddWithValue("@müsteri_telefon", müsteri_telefon.Text);
                cmd.Parameters.AddWithValue("@müsteri_email", müsteri_email.Text);
                cmd.Connection = baglanti;
              
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Arıza Kayıtı Başarılı !", "Kaydet", MessageBoxButtons.OK, MessageBoxIcon.Information);
        




        SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From urunler", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "urunler");
            dataGridView1.DataSource = dataset.Tables["urunler"];

            ürün_adi.Text = "";
            ürün_markasi.Text = "";
            ürün_sorunu.Text = "";
            ürün_sayisi.Text = "";
            müsteri_telefon.Text = "";
            müsteri_adi.Text = "";
            müsteri_soyadi.Text = "";
            müsteri_email.Text = "";
            baglanti.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string müsteri_adı = "";
            string müsteri_soyadı = "";
            string müsteri_tc = "";
            string müsteri_telefon = "";
            string müsteri_email = "";

            string arama = textBox6.Text;
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM Müsteri  where adı like '%" + arama.ToString() + "%'", baglanti);
            baglanti.Open();

            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                müsteri_adı = dr[1].ToString();
                müsteri_soyadı = dr[2].ToString();
                müsteri_tc = dr[3].ToString();
                müsteri_telefon = dr[4].ToString();
                müsteri_email = dr[5].ToString();
            }
            müsteri_adi.Text = müsteri_adı;
            müsteri_soyadi.Text = müsteri_soyadı;
            this.müsteri_tc.Text = müsteri_tc;
            this.müsteri_telefon.Text = müsteri_telefon;
            this.müsteri_email.Text = müsteri_email;
            baglanti.Close();
        }
    }
}
