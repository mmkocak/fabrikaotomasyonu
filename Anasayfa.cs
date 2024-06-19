using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fabrikaotomasyonu
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void personelBtn_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel();
            this.Hide();
            personel.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Yemekhane yemekhane = new Yemekhane();
            this.Hide();
            yemekhane.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pmuhasebe pancarmuh = new pmuhasebe();
            this.Hide();
            pancarmuh.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stok stoks = new stok();
            stoks.Hide();
            stoks.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
