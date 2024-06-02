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
    }
}
