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
    public partial class frmUyePanel : Form
    {
        public frmUyePanel()
        {
            InitializeComponent();
        }
        OracleConnection baglanti = new OracleConnection
            ("DATA SOURCE=localhost:1521/XEPDB1;PERSIST SECURITY INFO=True;USER ID=USERYASO;Password=1234;");
        private void frmUyePanel_Load(object sender, EventArgs e)
        {
            OracleCommand komut = new OracleCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM FİLMBİLGİLERİ";
            komut.CommandType = CommandType.Text;

            OracleDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Value = dr["FILMID"];
                item.Text = Convert.ToString(dr["FILMADI"]);

                comboBox1.Items.Add(item);

            }

            baglanti.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        int filmId;

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            filmId = Convert.ToInt32((comboBox1.SelectedItem as ComboboxItem).Value.ToString());
            MessageBox.Show(filmId.ToString());
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
         
            string dt = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            OracleCommand komut = new OracleCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM SEANSBILGILERI WHERE FILMID='" + filmId + "' AND BASLANGICTARIHI= to_date('"+dt+"','dd/MM/yyyy hh:mm:ss')";
            komut.CommandType = CommandType.Text;

            OracleDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Value = dr["SEANSID"];
                item.Text = Convert.ToString(dr["BASLANGICTARIHI"]);
                comboBox3.Items.Add(item);
            }

            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
