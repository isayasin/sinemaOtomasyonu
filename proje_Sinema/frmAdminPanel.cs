using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje_Sinema
{
    public partial class frmAdminPanel : Form
    {
        public frmAdminPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmFilmEkle f7 = new frmFilmEkle();
            f7.Show();
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSeansEkle f8 = new frmSeansEkle();
            f8.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
