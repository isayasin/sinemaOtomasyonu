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
    public partial class frmAdminGiris : Form
    {
        public frmAdminGiris()
        {
            InitializeComponent();
        }
        OracleConnection baglanti = new OracleConnection
            ("DATA SOURCE=localhost:1521/XEPDB1;PERSIST SECURITY INFO=True;USER ID=USERYASO;Password=1234;");
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand komut = new OracleCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = 
                "SELECT * FROM admınbılgılerı where kullanıcıadı='" + txtKullanıcı.Text + 
                "' AND sıfre='" + txtSıfre.Text + "'";
            OracleDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız. ");
                frmAdminPanel f6 = new frmAdminPanel();
                f6.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
                txtKullanıcı.Text = "";
                txtSıfre.Text = "";
            }
            baglanti.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
