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
    public partial class frmUyeKayit : Form
    {
        public frmUyeKayit()
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
            komut.CommandText = "insert into UYEKAYIT (AD,SOYAD,EMAİL,KULLANICIADI,SIFRE)" +
                "values ('" + txtÜyeKytAd.Text + "','" + txtÜyeKytSoyad.Text + "','" + txtÜyeKytMail.Text + "','"
                + txtÜyeKytKullanıcıAdı.Text + "','" + txtÜyeKytSifre.Text + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Eklendi");
            this.Close();
        }
    }
}
