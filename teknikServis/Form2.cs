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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\teknikServis\teknikservis.mdf; Integrated Security = true;");

        private void Form2_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new System.Drawing.Size(770, 490);
            this.MinimumSize = new System.Drawing.Size(770, 490);

            baglanti.Open();


        

            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From urunler ", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "urunler");
            dataGridView1.DataSource = dataset.Tables["urunler"];



            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myForm = new Form3();
            myForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var myForm = new Form4();
            myForm.Show();
            

            myForm.urun_no.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            myForm.ürün_adi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            myForm.ürün_markasi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            myForm.ürün_sorunu.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            myForm.yapılan_islem.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            myForm.ürün_sayisi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            myForm.toplam_fiyat.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            myForm.teslim_tarihi.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            myForm.müsteri_adi.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            myForm.müsteri_soyadi.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            myForm.müsteri_telefon.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            myForm.müsteri_email.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            baglanti.Open();

            int id = 0;
            //Seçili Satırları Silme
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                id = Convert.ToInt32(drow.Cells[0].Value);
            }

            //DATAGİRİTDEN SEÇİLEN SATIRI SİLME İŞLEMİ
            string sql = "DELETE FROM urunler WHERE id=@id";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@id", id);
            komut.ExecuteNonQuery();

            //MÜSTERİ TABLOSUNU TEKRAR DATAGRİD E YAZDIRIYORUM
            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From urunler", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "urunler");
            dataGridView1.DataSource = dataset.Tables["urunler"];
            this.Hide();
            MessageBox.Show("Ürüm Başarılı Şekilde Silindi");
          
            var myForm = new Form2();
            myForm.Show();
            baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var myForm = new Form5();
            myForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var myForm = new Form6();
            myForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From urunler", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "urunler");
            dataGridView1.DataSource = dataset.Tables["urunler"];
            baglanti.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var myForm = new Form7();
            myForm.Show();

            myForm.lbl_ürün_no.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            myForm.lbl_ürün_adi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            myForm.lbl_ürün_marka.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            myForm.lbl_ürün_sorun.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            myForm.lbl_ürün_yapılan_islem.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            myForm.lbl_ürün_durumu.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            myForm.lbl_ürün_sayısı.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            myForm.lbl_toplam_tl.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString()+ " TL";
            myForm.lbl_teslim_tarih.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            myForm.lbl_müsteri_adi.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            myForm.lbl_müsteri_soyadi.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            myForm.lbl_müsteri_telefon.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            myForm.lbl_müsteri_email.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();





        }
    }
}
