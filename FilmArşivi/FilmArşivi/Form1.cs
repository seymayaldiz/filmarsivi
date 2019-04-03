using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace FilmArşivi
{   //Data Source=ŞEYMA\SQLEXPRESS;Initial Catalog=FilmArşivi;Integrated Security=True
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=ŞEYMA\SQLEXPRESS;Initial Catalog=FilmArşivi;Integrated Security=True");
        void filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLFİLMLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource= dt;


        }



        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand KOMUT = new SqlCommand("insert into TBLFİLMLER (AD,KATEGORİ,LİNK) values (@P1,@P2,@P3)",baglanti);
            KOMUT.Parameters.AddWithValue("@P1",TxtFilmAdi.Text);
            KOMUT.Parameters.AddWithValue("@P2", TxtKategori.Text);
            KOMUT.Parameters.AddWithValue("@P3", TxtLink.Text);
            KOMUT.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("FİLM LİSTENİZE EKLENDİ","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            filmler();



        }
    }
}
