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
    public partial class Yemekhane : Form
    {
        public Yemekhane()
        {
            InitializeComponent();
        }
        private const string connectionString = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=fabrikaDb; Trusted_Connection=True;";
        private int GetNextYemeklId(SqlConnection connection)
        {
            string query = "SELECT ISNULL(MAX(id), 0) + 1 FROM yemekhaneTbl";
            SqlCommand command = new SqlCommand(query, connection);
            object result = command.ExecuteScalar();
            return Convert.ToInt32(result);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string yemekAd = yemekTb.Text;
            string tarih = dateTimePicker1.Value.Date.ToString();
            string ikinciyemek = ikinciTb.Text;
            string idmm = idm.Text;
            string icecekler = icecek.Text;
            string ucuncu = ucuncuTb.Text;
            
            string query = "INSERT INTO yemekhaneTbl (yemekid, anayemek, icecek, ikincicesit, ucuncucesit, tarih) VALUES (@idmm, @yemekAd, @icecekler, @ikinciyemek, @ucuncu, @tarih)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (string.IsNullOrEmpty(yemekAd) || string.IsNullOrEmpty(tarih) || string.IsNullOrEmpty(icecekler))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                connection.Open();


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", GetNextYemeklId(connection));
                command.Parameters.AddWithValue("@yemekAd", yemekAd);
                command.Parameters.AddWithValue("@tarih", tarih);
                command.Parameters.AddWithValue("@ikinciyemek", ikinciyemek);
                command.Parameters.AddWithValue("@icecekler", icecekler);
                command.Parameters.AddWithValue("@ucuncu", ucuncu);
                command.Parameters.AddWithValue("@idmm", idmm);

                // Komutu çalıştır
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Yemek başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Yemek eklenirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listeleBtn_Click(object sender, EventArgs e)
        {
            string query = "SELECT yemekid, anayemek, icecek, ikincicesit, ucuncucesit, tarih FROM yemekhaneTbl";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(idm.Text, out int idmm) || idmm <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir id girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string yemekAd = yemekTb.Text;
            string tarih = dateTimePicker1.Value.Date.ToString();
            string ikinciyemek = ikinciTb.Text;
          

            string icecekler = icecek.Text;
            string ucuncu = ucuncuTb.Text;

            // Güncelleme sorgusu
            string query = "UPDATE yemekhaneTbl SET anayemek=@yemekAd, icecek=@icecekler, ikincicesit=@ikinciyemek, ucuncucesit=@ucuncu, tarih=@tarih WHERE yemekid=@idmm ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Veritabanı bağlantısını aç
                connection.Open();

                // SQL komutu ve parametreleri oluştur
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@yemekAd", yemekAd);
                command.Parameters.AddWithValue("@tarih", tarih);
                command.Parameters.AddWithValue("@ikinciyemek", ikinciyemek);
                command.Parameters.AddWithValue("@icecekler", icecekler);
                command.Parameters.AddWithValue("@ucuncu", ucuncu);
                command.Parameters.AddWithValue("@idmm", idmm);

                // Komutu çalıştır
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Yemek başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Belirtilen id'ye ait bir yemek bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(idm.Text, out int idmm) || idmm <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir id girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "DELETE FROM yemekhaneTbl WHERE yemekid=@idmm";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Veritabanı bağlantısını aç
                connection.Open();

                // SQL komutu ve parametreleri oluştur
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idmm", idmm);

                // Komutu çalıştır
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("yemek başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Belirtilen id'ye ait bir yemek bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
