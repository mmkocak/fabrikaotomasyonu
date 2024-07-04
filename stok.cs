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
        private const string connectionString = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=fabrikaDb; Trusted_Connection=True;";
        private SqlConnection connection;
        public stok()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }
        
        
        // Ekle
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUrunAdi.Text) || string.IsNullOrEmpty(txtMiktar.Text) || string.IsNullOrEmpty(txtFiyat.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string query = "INSERT INTO stokTbl (Ad, Miktar, Fiyat, Tarih) VALUES (@Ad, @Miktar, @Fiyat, @Tarih)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Ad", txtUrunAdi.Text);

                    if (int.TryParse(txtMiktar.Text, out int miktar))
                        command.Parameters.AddWithValue("@Miktar", miktar);
                    else
                    {
                        
                        return;
                    }

                    if (decimal.TryParse(txtFiyat.Text, out decimal fiyat))
                        command.Parameters.AddWithValue("@Fiyat", fiyat);
                    else
                    {
                        
                        return;
                    }

                    command.Parameters.AddWithValue("@Tarih", dtpTarih.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                Listele(); 
            }
            catch (SqlException ex)
            {
                
                Console.WriteLine("SQL Hatası: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        // Listele
        private void listeleBtn_Click(object sender, EventArgs e)
        {
            Listele();
        }
        // Güncelle
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int selectedId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;

                    
                    string query = "UPDATE stokTbl SET Ad = @Ad, Miktar = @Miktar, Fiyat = @Fiyat, Tarih = @Tarih WHERE id = @Id";

                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@Id", selectedId);
                        command.Parameters.AddWithValue("@Ad", txtUrunAdi.Text);

                        if (int.TryParse(txtMiktar.Text, out int miktar))
                            command.Parameters.AddWithValue("@Miktar", miktar);
                        else
                        {
                            MessageBox.Show("Miktar alanına geçerli bir sayı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; 
                        }

                        if (decimal.TryParse(txtFiyat.Text, out decimal fiyat))
                            command.Parameters.AddWithValue("@Fiyat", fiyat);
                        else
                        {
                            MessageBox.Show("Fiyat alanına geçerli bir sayı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        command.Parameters.AddWithValue("@Tarih", dtpTarih.Value);

                       
                        connection.Open();

                        
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Veri başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                    Listele();
                }
                catch (SqlException ex)
                {
                    
                    MessageBox.Show("Veri güncellenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Sil
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows[0].Cells["Id"].Value != null)
                {
                    try
                    {
                        int selectedId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;

                        string query = "DELETE FROM stokTbl WHERE id = @Id";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", selectedId);

                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            connection.Close();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Veri başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Listele();
                            }
                            else
                            {
                                MessageBox.Show("Silme işlemi sırasında bir hata oluştu veya kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Veri silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen silinecek bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        // Geri
        private void button4_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            this.Hide();
            anasayfa.Show();
        }
        public class Urun
        {
            public int Id { get; set; }
            public string Ad { get; set; }
            public int Miktar { get; set; }
            public decimal Fiyat { get; set; }
            public DateTime Tarih { get; set; }
        }
        private void Listele()
        {
            string query = "SELECT * FROM stokTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

               
                if (selectedRow.Cells["Id"].Value != null &&
                    selectedRow.Cells["Ad"].Value != null &&
                    selectedRow.Cells["Miktar"].Value != null &&
                    selectedRow.Cells["Fiyat"].Value != null &&
                    selectedRow.Cells["Tarih"].Value != null &&
                    !string.IsNullOrEmpty(selectedRow.Cells["Ad"].Value.ToString()) &&
                    !string.IsNullOrEmpty(selectedRow.Cells["Miktar"].Value.ToString()) &&
                    !string.IsNullOrEmpty(selectedRow.Cells["Fiyat"].Value.ToString()))
                {
                    int selectedId = (int)selectedRow.Cells["Id"].Value;
                    txtUrunAdi.Text = selectedRow.Cells["Ad"].Value.ToString();
                    txtMiktar.Text = selectedRow.Cells["Miktar"].Value.ToString();
                    txtFiyat.Text = selectedRow.Cells["Fiyat"].Value.ToString();
                    dtpTarih.Value = (DateTime)selectedRow.Cells["Tarih"].Value;
                }
                else
                {
                    
                    txtUrunAdi.Text = "";
                    txtMiktar.Text = "";
                    txtFiyat.Text = "";
                    dtpTarih.Value = DateTime.Today; 
                }
            }
        }
    }
}
