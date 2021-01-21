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
namespace proje_Sinema
{
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAdminGiris f2 = new frmAdminGiris();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmUyeGiris f3 = new frmUyeGiris();
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmUyeKayit f4 = new frmUyeKayit();
            f4.Show();
        }
    }
}
