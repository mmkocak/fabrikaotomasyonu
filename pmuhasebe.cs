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
    public partial class pmuhasebe : Form
    {
        public pmuhasebe()
        {
            InitializeComponent();
        }
        private const string connectionString = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=fabrikaDb; Trusted_Connection=True;";
        private int GetNextpmuhId(SqlConnection connection)
        {
            string query = "SELECT ISNULL(MAX(id), 0) + 1 FROM pmuhasebeTbl";
            SqlCommand command = new SqlCommand(query, connection);
            object result = command.ExecuteScalar();
            return Convert.ToInt32(result);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string fiyat = FiyatTb.Text;
            string tarih = dateTimePicker1.Value.Date.ToString();
            string aton = atonTb.Text;
            string idmm = idm.Text;
            string satici = saticiTb.Text;
            string query = "INSERT INTO pmuhasebeTbl (pid, fiyat, tarih, alinanton, satici) VALUES (@idmm, @fiyat, @tarih, @aton, @satici)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (string.IsNullOrEmpty(aton) || string.IsNullOrEmpty(tarih) || string.IsNullOrEmpty(fiyat))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                connection.Open();


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", GetNextpmuhId(connection));
                command.Parameters.AddWithValue("@fiyat", fiyat);
                command.Parameters.AddWithValue("@tarih", tarih);
                command.Parameters.AddWithValue("@aton", aton);
                command.Parameters.AddWithValue("@satici", satici);
                command.Parameters.AddWithValue("@idmm", idmm);

                // Komutu çalıştır
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Pancar başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Pancar eklenirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

     

        private void listeleBtn_Click_1(object sender, EventArgs e)
        {
            string query = "SELECT pid, fiyat, tarih, alinanton, satici FROM pmuhasebeTbl";

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
            string fiyat = FiyatTb.Text;
            string tarih = dateTimePicker1.Value.Date.ToString();
            string aton = atonTb.Text;
            string satici = saticiTb.Text;
            if (!int.TryParse(idm.Text, out int idmm) || idmm <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir id girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE pmuhasebeTbl SET fiyat=@fiyat, tarih=@tarih, alinanton=@aton, satici=@satici WHERE pid=@idmm ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Veritabanı bağlantısını aç
                connection.Open();

                // SQL komutu ve parametreleri oluştur
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fiyat", fiyat);
                command.Parameters.AddWithValue("@tarih", tarih);
                command.Parameters.AddWithValue("@aton", aton);
                command.Parameters.AddWithValue("@satici", satici);
                command.Parameters.AddWithValue("@idmm", idmm);

                // Komutu çalıştır
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Pancar başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Belirtilen id'ye ait pancar bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string query = "DELETE FROM pmuhasebeTbl WHERE pid=@idmm";

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
                    MessageBox.Show("pancar başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Belirtilen id'ye ait pancar bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
