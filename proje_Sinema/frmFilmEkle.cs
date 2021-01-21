using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using Oracle.ManagedDataAccess.Client;

namespace proje_Sinema
{
    public partial class frmFilmEkle : Form
    {
        public frmFilmEkle()
        {
            InitializeComponent();
        }
        OracleConnection baglanti = new OracleConnection
            ("DATA SOURCE=localhost:1521/XEPDB1;PERSIST SECURITY INFO=True;USER ID=USERYASO;Password=1234;");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OracleCommand komut = new OracleCommand();
            komut.Connection = baglanti;
            komut.CommandText = "insert into FİLMBİLGİLERİ (fılmadı,yonetmen,kategorı_ıd)" +
                "values ('" + txtFilmAdi.Text + "', '" 
                + txtYonetmen.Text + "','"
                + Convert.ToInt32(comboBox1.SelectedIndex+1) + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Eklendi");
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmFilmEkle_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OracleCommand komut = new OracleCommand();
            komut.Connection = baglanti;
            komut.CommandText = "Select * from FILMKATEGORILERI ";
            OracleDataReader kategoriler = komut.ExecuteReader();
            while (kategoriler.Read())
            {
                comboBox1.Items.Add(kategoriler["KATEGORIADI"]);
            }
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void txtFilmTuru_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
