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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new System.Drawing.Size(600, 490);
            this.MinimumSize = new System.Drawing.Size(600, 490);

            baglanti.Open();
            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Müsteri", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "Müsteri");
            dataGridView1.DataSource = dataset.Tables["Müsteri"];
            baglanti.Close();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\teknikServis\teknikservis.mdf; Integrated Security = true;");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into Müsteri (adı,soyadı,tc,telefon,email)   values ('" + adi.Text + "','" + soyadi.Text + "','" + tc.Text + "','" + telefon.Text + "','" + email.Text + "')", baglanti);
            cmd.ExecuteNonQuery();


            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Müsteri", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "Müsteri");
            dataGridView1.DataSource = dataset.Tables["Müsteri"];


            //TEXTBOXLARIN İÇERİSİNDEKİ DEGERLERİ SİLDİM.
            adi.Text = "";
            soyadi.Text = "";
            tc.Text = "";
            telefon.Text = "";
            email.Text = "";

            MessageBox.Show("Müşteri Başarılı Şekilde Eklendi !");

            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            int id = 0;
            //Seçili Satırları Silme
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                id = Convert.ToInt32(drow.Cells[0].Value);
            }

            //DATAGİRİTDEN SEÇİLEN SATIRI SİLME İŞLEMİ
            string sql = "DELETE FROM Müsteri WHERE id=@id";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@id", id);
            komut.ExecuteNonQuery();

            //MÜSTERİ TABLOSUNU TEKRAR DATAGRİD E YAZDIRIYORUM
            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Müsteri", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "Müsteri");
            dataGridView1.DataSource = dataset.Tables["Müsteri"];
            this.Hide();
            MessageBox.Show("Müsteri Başarılı Şekilde Silindi");

            var myForm = new Form2();
            myForm.Show();
            baglanti.Close();
        }
    }
}
