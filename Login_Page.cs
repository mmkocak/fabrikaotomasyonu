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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace fabrikaotomasyonu
{
    public partial class Login_Page : Form
    {
        public Login_Page()
        {
            InitializeComponent();
        }
        string con = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=fabrikaDb; Trusted_Connection=True;";
        private bool CheckLogin(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM [adminTbl] WHERE aad = @username AND apass = @password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = kadiTb.Text;
            string password = ksifreTb.Text;

            if (CheckLogin(username, password))
            {
                Anasayfa anasayfa = new Anasayfa();
                anasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı");
            }

        }

        private void ksifreTb_TextChanged(object sender, EventArgs e)
        {
            ksifreTb.PasswordChar = '*';
        }
    }
}
