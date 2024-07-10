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
            if (string.IsNullOrEmpty(txtUrunAdi.Text) || string.IsNullOrEmpty(uretilenTb.Text) || string.IsNullOrEmpty(satilanTb.Text) || string.IsNullOrEmpty(txtFiyat.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "INSERT INTO stokTbl (Ad, Uretilen, Satilan, Kalan, Fiyat, Tarih) VALUES (@Ad, @Uretilen, @Satilan, @Kalan, @Fiyat, @Tarih)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Ad", txtUrunAdi.Text);

                    if (int.TryParse(uretilenTb.Text, out int uretilen) && int.TryParse(satilanTb.Text, out int satilan))
                    {
                        int miktar = uretilen - satilan;
                        command.Parameters.AddWithValue("@Uretilen", uretilen);
                        command.Parameters.AddWithValue("@Satilan", satilan);
                        command.Parameters.AddWithValue("@Kalan", miktar);
                    }
                    else
                    {
                        MessageBox.Show("Lütfen geçerli sayılar girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (decimal.TryParse(txtFiyat.Text, out decimal fiyat))
                        command.Parameters.AddWithValue("@Fiyat", fiyat);
                    else
                    {
                        MessageBox.Show("Lütfen geçerli bir fiyat girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow.Cells["Id"].Value != null)
                {
                    try
                    {
                        int selectedId = (int)selectedRow.Cells["Id"].Value;

                        string query = "UPDATE stokTbl SET Ad = @Ad, Uretilen = @Uretilen, Satilan = @Satilan, Kalan = @Kalan, Fiyat = @Fiyat, Tarih = @Tarih WHERE id = @Id";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", selectedId);
                            command.Parameters.AddWithValue("@Ad", txtUrunAdi.Text);

                            if (int.TryParse(uretilenTb.Text, out int uretilen) && int.TryParse(satilanTb.Text, out int satilan))
                            {
                                int miktar = uretilen - satilan; // Kalan miktar hesaplanıyor
                                command.Parameters.AddWithValue("@Uretilen", uretilen);
                                command.Parameters.AddWithValue("@Satilan", satilan);
                                command.Parameters.AddWithValue("@Kalan", miktar);
                            }
                            else
                            {
                                MessageBox.Show("Lütfen geçerli sayılar girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            if (decimal.TryParse(txtFiyat.Text, out decimal fiyat))
                                command.Parameters.AddWithValue("@Fiyat", fiyat);
                            else
                            {
                                MessageBox.Show("Lütfen geçerli bir fiyat girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow.Cells["Id"].Value != null)
                {
                    try
                    {
                        int selectedId = (int)selectedRow.Cells["Id"].Value;

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
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen silinecek bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            public int Uretilen { get; set; }
            public int Satilan { get; set; }
            public int Kalan { get; set; }
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
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                if (selectedRow.Cells["Id"].Value != DBNull.Value && selectedRow.Cells["Id"].Value != null)
                {
                    txtUrunAdi.Text = selectedRow.Cells["Ad"].Value?.ToString() ?? "";
                    uretilenTb.Text = selectedRow.Cells["Uretilen"].Value?.ToString() ?? "";
                    satilanTb.Text = selectedRow.Cells["Satilan"].Value?.ToString() ?? "";
                    txtFiyat.Text = selectedRow.Cells["Fiyat"].Value?.ToString() ?? "";
                    dtpTarih.Value = selectedRow.Cells["Tarih"].Value != DBNull.Value && selectedRow.Cells["Tarih"].Value != null
                                     ? (DateTime)selectedRow.Cells["Tarih"].Value
                                     : DateTime.Today;
                }
                else
                {
                    txtUrunAdi.Text = "";
                    uretilenTb.Text = "";
                    satilanTb.Text = "";
                    txtFiyat.Text = "";
                    dtpTarih.Value = DateTime.Today;
                }
            }
        }
    }
}
