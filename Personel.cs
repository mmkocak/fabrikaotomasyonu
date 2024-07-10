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
        private const string connectionString = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=fabrikaDb; Trusted_Connection=True;";
        private SqlConnection connection;
        public Personel()
        {
            connection = new SqlConnection(connectionString);
            InitializeComponent();
        }
        private void listeleBtn_Click(object sender, EventArgs e)
        {
            PersonelListeleme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = adTb.Text;
            string soyad = soyadTb.Text;
            string numara = noTb.Text;
            string cinsiyet = cinsCb.SelectedItem?.ToString(); // Null kontrolü
            DateTime kayitTarihi = dateTimePicker1.Value; // Tarihi DateTimePicker'dan al
            decimal perMaas;

            
            if (!decimal.TryParse(personelMaas.Text, out perMaas))
            {
                MessageBox.Show("Lütfen geçerli bir maaş girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Boş alan kontrolü
            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(numara) || string.IsNullOrEmpty(cinsiyet))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO personel (PersAd, PersSoyAd, PersNo, Cinsiyet, KayitTarihi, Pmaas) VALUES (@ad, @soyad, @numara, @cinsiyet, @ktarih, @perMaas)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ad", ad);
                        command.Parameters.AddWithValue("@soyad", soyad);
                        command.Parameters.AddWithValue("@numara", numara);
                        command.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                        command.Parameters.AddWithValue("@ktarih", kayitTarihi);
                        command.Parameters.AddWithValue("@perMaas", perMaas);

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
                catch (SqlException ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beklenmedik bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }


        }

        
        // Silme
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows[0].Cells["Id"].Value != null)
                {
                    try
                    {
                        int selectedId;
                        if (int.TryParse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString(), out selectedId))
                        {
                            string query = "DELETE FROM personel WHERE ID = @Id";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Id", selectedId);

                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Personel başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    PersonelListeleme();
                                }
                                else
                                {
                                    MessageBox.Show("Silme işlemi sırasında bir hata oluştu veya kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Geçersiz bir ID değeri seçildi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Personel silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        // Güncelle

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows[0].Cells["ID"].Value != null && int.TryParse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString(), out int selectedId))
                {
                    // Alanların doluluğunu kontrol ediyoruz
                    if (!string.IsNullOrEmpty(adTb.Text) && !string.IsNullOrEmpty(soyadTb.Text) && !string.IsNullOrEmpty(noTb.Text) && !string.IsNullOrEmpty(cinsCb.SelectedItem?.ToString()) && decimal.TryParse(personelMaas.Text, out decimal perMaas))
                    {
                        try
                        {
                            string query = "UPDATE personel SET PersAd = @ad, PersSoyAd = @soyad, PersNo = @numara, Cinsiyet = @cinsiyet, Pmaas = @perMaas WHERE ID = @persId";

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@persId", selectedId);
                                    command.Parameters.AddWithValue("@ad", adTb.Text);
                                    command.Parameters.AddWithValue("@soyad", soyadTb.Text);
                                    command.Parameters.AddWithValue("@numara", noTb.Text);
                                    command.Parameters.AddWithValue("@cinsiyet", cinsCb.SelectedItem.ToString());
                                    command.Parameters.AddWithValue("@perMaas", perMaas);

                                    connection.Open();
                                    command.ExecuteNonQuery();

                                    MessageBox.Show("Personel başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    PersonelListeleme();
                                }
                            }
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
                        MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Geçersiz bir satır seçtiniz. Lütfen güncellenecek geçerli bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


            private void button4_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }
        private void PersonelListeleme()
        {
            string query = "SELECT ID, PersAd, PersSoyAd, PersNo, Cinsiyet, KayitTarihi, Pmaas FROM personel";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Verileri yüklerken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            
            int rowIndex = e.RowIndex;

            
            adTb.Clear();
            soyadTb.Clear();
            noTb.Clear();
            cinsCb.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;

           
            adTb.Text = dataGridView1.Rows[rowIndex].Cells["PersAd"].Value.ToString();
            soyadTb.Text = dataGridView1.Rows[rowIndex].Cells["PersSoyAd"].Value.ToString();
            noTb.Text = dataGridView1.Rows[rowIndex].Cells["PersNo"].Value.ToString();
            cinsCb.SelectedItem = dataGridView1.Rows[rowIndex].Cells["Cinsiyet"].Value.ToString();

            
            DateTime dateValue;
            if (DateTime.TryParse(dataGridView1.Rows[rowIndex].Cells["KayitTarihi"].Value.ToString(), out dateValue))
            {
                dateTimePicker1.Value = dateValue;
            }
            else
            {
                dateTimePicker1.Value = DateTime.Now; 
            }

           
            personelMaas.Text = dataGridView1.Rows[rowIndex].Cells["Pmaas"].Value.ToString();
        
    }
    }
    
    
}

        
    

