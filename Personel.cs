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
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
        }
        private const string connectionString = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=fabrikaDb; Trusted_Connection=True;";
        private void listeleBtn_Click(object sender, EventArgs e)
        {
            string query = "SELECT PersId, PersAd, PersSoyAd, PersNo, cinsiyet FROM personel";

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

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = adTb.Text;
            string soyad = soyadTb.Text;
            string numara = noTb.Text;
            string idm = idTb.Text;
            string cinsiyet = cinsCb.SelectedItem.ToString();
            string query = "INSERT INTO personel (PersAd, PersSoyAd, PersNo, cinsiyet, PersId) VALUES (@ad, @soyad, @numara, @cinsiyet, @idm)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(numara))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                connection.Open();

                
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", GetNextPersonelId(connection)); 
                command.Parameters.AddWithValue("@ad", ad);
                command.Parameters.AddWithValue("@soyad", soyad);
                command.Parameters.AddWithValue("@numara", numara);
                command.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                command.Parameters.AddWithValue("@idm", idm);

                // Komutu çalıştır
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Personel başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Personel eklenirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Veritabanında bir sonraki artan PersId değerini alır
        private int GetNextPersonelId(SqlConnection connection)
        {
            string query = "SELECT ISNULL(MAX(PersId), 0) + 1 FROM personel";
            SqlCommand command = new SqlCommand(query, connection);
            object result = command.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(idTb.Text, out int persId) || persId <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir PersId girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "DELETE FROM personel WHERE PersId=@persId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Veritabanı bağlantısını aç
                connection.Open();

                // SQL komutu ve parametreleri oluştur
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@persId", persId);

                // Komutu çalıştır
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Personel başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Belirtilen PersId'ye sahip bir personel bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(idTb.Text, out int persId) || persId <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir PersId girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string yeniAd = adTb.Text;
            string yeniSoyad = soyadTb.Text;
            string yeniNumara = noTb.Text;
            string cinsiyet = cinsCb.SelectedItem.ToString();

            if (string.IsNullOrEmpty(yeniAd) || string.IsNullOrEmpty(yeniSoyad) || string.IsNullOrEmpty(yeniNumara) || string.IsNullOrEmpty(cinsiyet))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE personel SET PersAd=@ad, PersSoyAd=@soyad, PersNo=@numara, cinsiyet=@cinsiyet WHERE PersId=@persId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ad", yeniAd);
                command.Parameters.AddWithValue("@soyad", yeniSoyad);
                command.Parameters.AddWithValue("@numara", yeniNumara);
                command.Parameters.AddWithValue("@persId", persId);
                command.Parameters.AddWithValue("@cinsiyet", cinsiyet);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Personel başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Belirtilen PersId'ye sahip bir personel bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }
    }
    
    
}

        
    

