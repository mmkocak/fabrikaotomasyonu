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
        private const string connectionString = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=fabrikaDb; Trusted_Connection=True;";
        private SqlConnection connection;
        public Yemekhane()
        {
            connection = new SqlConnection(connectionString);

            InitializeComponent();
            ListeleYemekMenusu();
        }
      
       
        // Ekle
        private void button1_Click(object sender, EventArgs e)
        {
            string yemekAd = yemekTb.Text;
            DateTime tarih = dateTimePicker1.Value.Date; 
            string ikinciyemek = ikinciTb.Text;
            string icecekler = icecek.Text;
            string ucuncu = ucuncuTb.Text;

            string query = "INSERT INTO yemekhaneTbl (AnaYemek, IkinciYemek, UcuncuYemek, Icecek, Tarih) VALUES (@yemekAd, @ikinciyemek, @ucuncu, @icecekler, @tarih)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (string.IsNullOrEmpty(yemekAd) || tarih == null || string.IsNullOrEmpty(icecekler))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@yemekAd", yemekAd);
                command.Parameters.AddWithValue("@tarih", tarih);
                command.Parameters.AddWithValue("@ikinciyemek", ikinciyemek);
                command.Parameters.AddWithValue("@icecekler", icecekler);
                command.Parameters.AddWithValue("@ucuncu", ucuncu);

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
        // Listele
        private void listeleBtn_Click(object sender, EventArgs e)
        {
            ListeleYemekMenusu();
        }

        // Güncelle
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows[0].Cells["ID"].Value != null && int.TryParse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString(), out int selectedId))
                {
                    // Alanların doluluğunu kontrol ediyoruz
                    if (!string.IsNullOrEmpty(yemekTb.Text) && !string.IsNullOrEmpty(ikinciTb.Text) && !string.IsNullOrEmpty(ucuncuTb.Text) && !string.IsNullOrEmpty(icecek.Text))
                    {
                        try
                        {
                            string query = "UPDATE yemekhaneTbl SET AnaYemek = @AnaYemek, IkinciYemek = @IkinciYemek, UcuncuYemek = @UcuncuYemek, Icecek = @Icecek, Tarih = @Tarih WHERE ID = @ID";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@ID", selectedId);
                                command.Parameters.AddWithValue("@AnaYemek", yemekTb.Text);
                                command.Parameters.AddWithValue("@IkinciYemek", ikinciTb.Text);
                                command.Parameters.AddWithValue("@UcuncuYemek", ucuncuTb.Text);
                                command.Parameters.AddWithValue("@Icecek", icecek.Text);
                                command.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);

                                connection.Open();
                                command.ExecuteNonQuery();

                                MessageBox.Show("Yemek başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                ListeleYemekMenusu();
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
        // Sil
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
                            string query = "DELETE FROM yemekhaneTbl WHERE ID = @Id";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Id", selectedId);

                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Yemek başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ListeleYemekMenusu();
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
                        MessageBox.Show("Yemek silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            anasayfa.Show();
            this.Hide();
        }
        // Listeleme Fonksiyonu
        private void ListeleYemekMenusu()
        {
            string query = "SELECT ID, AnaYemek, IkinciYemek, UcuncuYemek, Icecek, Tarih FROM yemekhaneTbl";
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

    }
}
