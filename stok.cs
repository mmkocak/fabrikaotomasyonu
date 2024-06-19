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
    public partial class stok : Form
    {
        public stok()
        {
            InitializeComponent();
        }
        private const string connectionString = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=fabrikaDb; Trusted_Connection=True;";
        private int GetNextstokId(SqlConnection connection)
        {
            string query = "SELECT ISNULL(MAX(id), 0) + 1 FROM stokTbl";
            SqlCommand command = new SqlCommand(query, connection);
            object result = command.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kalan = KalanTb.Text;
            string tarih = dateTimePicker1.Value.Date.ToString();
            string idmm = idm.Text;
            string query = "INSERT INTO stokTbl (stid, kalan, tarih) VALUES (@idmm, @kalan, @tarih)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (string.IsNullOrEmpty(kalan) || string.IsNullOrEmpty(tarih))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                connection.Open();


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", GetNextstokId(connection));
                command.Parameters.AddWithValue("@kalan", kalan);
                command.Parameters.AddWithValue("@tarih", tarih);
                command.Parameters.AddWithValue("@idmm", idmm);

                // Komutu çalıştır
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Stok başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Stok eklenirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listeleBtn_Click(object sender, EventArgs e)
        {
            string query = "SELECT stid, kalan, tarih FROM stokTbl";

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

            string kalan = KalanTb.Text;
            string tarih = dateTimePicker1.Value.Date.ToString();
            if (!int.TryParse(idm.Text, out int idmm) || idmm <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir id girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE stokTbl SET kalan=@kalan, tarih=@tarih WHERE stid=@idmm ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Veritabanı bağlantısını aç
                connection.Open();

                // SQL komutu ve parametreleri oluştur
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@kalan", kalan);
                command.Parameters.AddWithValue("@tarih", tarih);
                command.Parameters.AddWithValue("@idmm", idmm);

                // Komutu çalıştır
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Stok başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Belirtilen id de Stok bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string query = "DELETE FROM stokTbl WHERE stid=@idmm";

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
                    MessageBox.Show("Stok başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Belirtilen id'ye ait Stok bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            this.Hide();
            anasayfa.Show();
        }
    }
}
