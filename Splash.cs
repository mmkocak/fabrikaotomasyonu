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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        int stPoint = 0;
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            stPoint += 1;
            Progressim.Value = stPoint;
            if (Progressim.Value == 100)
            {
                Progressim.Value = 0;
                timer1.Stop();
                Login_Page login = new Login_Page();
                login.Show();
                this.Hide();

            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
