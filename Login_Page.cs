using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fabrikaotomasyonu
{
    public partial class Login_Page : Form
    {
        public Login_Page()
        {
            InitializeComponent();
        }
        private const string connectionString = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=fabrikaDb; Trusted_Connection=True;";
        private const string adminUsername = "admin";
        private const string adminPassword = "admin";
        private void button1_Click(object sender, EventArgs e)
        {
            string kadi = kadiTb.Text;
            string sifre = ksifreTb.Text;
            if (kadi == adminUsername && sifre == adminPassword)
            {
                Anasayfa anasayfa = new Anasayfa();
                MessageBox.Show("Giriş başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                anasayfa.Show();

            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
    }
}
