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
    public partial class frmUyeGiris : Form
    {
        public frmUyeGiris()
        {
            InitializeComponent();
        }
        OracleConnection baglanti = new OracleConnection
            ("DATA SOURCE=localhost:1521/XEPDB1;PERSIST SECURITY INFO=True;USER ID=USERYASO;Password=1234;");
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand komut = new OracleCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM uyekayıt where kullanıcıadı='" + txtKullanıcıAdı.Text + "' AND sıfre='" + txtSifre.Text + "'";
            OracleDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız. ");
                frmUyePanel f5 = new frmUyePanel();
                f5.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
                txtKullanıcıAdı.Text = "";
                txtSifre.Text = "";
            }
            baglanti.Close();
        }
    }
}
