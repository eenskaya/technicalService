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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\teknikServis\teknikservis.mdf; Integrated Security = true;");

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sql = "SELECT * FROM urunler Where tarih BETWEEN @tar1 and @tar2";
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(sql, baglanti);
            adp.SelectCommand.Parameters.AddWithValue("@tar1", ilk_tarih.Value.Date);
            adp.SelectCommand.Parameters.AddWithValue("@tar2", ikinci_tarih.Value.Date);
            adp.Fill(dt);
 
            baglanti.Close();
            dataGridView1.DataSource = dt;
            int toplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                toplam += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
            }
            this.toplam_tl.Text = toplam.ToString()+" TL";
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new System.Drawing.Size(815, 420);
            this.MinimumSize = new System.Drawing.Size(815, 420);

            baglanti.Open();
            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From urunler", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "urunler");
            dataGridView1.DataSource = dataset.Tables["urunler"];
            baglanti.Close();
        }
    }
}
