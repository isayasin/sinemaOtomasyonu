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
    public partial class frmSeansEkle : Form
    {
        public frmSeansEkle()
        {
            InitializeComponent();
        }

        OracleConnection baglanti = new OracleConnection
        ("DATA SOURCE=localhost:1521/XEPDB1;PERSIST SECURITY INFO=True;USER ID=USERYASO;Password=1234;");

        private void frmSeansEkle_Load(object sender, EventArgs e)
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
           
                OracleCommand komut2 = new OracleCommand();
            komut2.Connection = baglanti;
                komut2.CommandText = "SELECT * FROM SALONBİLGİLERİ";
                komut2.CommandType = CommandType.Text;
               OracleDataReader dr2 = komut2.ExecuteReader();
            
            while (dr2.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Value = dr2["SALONID"];
                item.Text = Convert.ToString(dr2["SALONADI"]);
                comboBox2.Items.Add(item);
            }
            baglanti.Close();
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }
        int filmId;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filmId = Convert.ToInt32((comboBox1.SelectedItem as ComboboxItem).Value.ToString());
        }

      
        String saat;
        private void radioButtonSeciliyse()
        {
            if (radioButton1.Checked == true) saat = radioButton1.Text;
            else if (radioButton2.Checked == true) saat = radioButton2.Text;
            else if (radioButton3.Checked == true) saat = radioButton3.Text;
            else if (radioButton4.Checked == true) saat = radioButton4.Text;
            else if (radioButton5.Checked == true) saat = radioButton5.Text;
        }
                                              

        private void button1_Click(object sender, EventArgs e)
        {
            radioButtonSeciliyse();
            string tarih = dateTimePicker1.Value.ToShortDateString();
            OracleCommand komut = new OracleCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "insert into SEANSBILGILERI (FILMID,SALONID,TARIH,SEANS)" +
                "values ('" + filmId +  "','"+ salonId + "','"+ tarih +"','"+saat+"')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Eklendi");
        }
        int salonId;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            salonId = Convert.ToInt32((comboBox2.SelectedItem as ComboboxItem).Value.ToString());
        }
      
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
