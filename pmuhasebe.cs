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
        private const string connectionString = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=fabrikaDb; Trusted_Connection=True;";
        private SqlConnection connection;
        public pmuhasebe()
        {
            connection = new SqlConnection(connectionString);
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }
        // Alınan Ekle
        private void alinanEkle_Click(object sender, EventArgs e)
        {
            string urunad = uadTb.Text;
            string urunadet = uadetTb.Text;
            string birimFiyat = ubrimfiyatTb.Text;
            DateTime kayitTarihi = utarihDTP.Value;

            // Adet ve birim fiyat için sayısal kontrol
            if (!int.TryParse(urunadet, out int urunAdet))
            {
                MessageBox.Show("Lütfen geçerli bir ürün adeti girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(birimFiyat, out int birimFiyatDegeri))
            {
                MessageBox.Show("Lütfen geçerli bir birim fiyatı girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Boş alan kontrolü
            if (string.IsNullOrEmpty(urunad))
            {
                MessageBox.Show("Lütfen ürün adını girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SQL sorgusu
            string query = "INSERT INTO alinanlar (urunAd, urunAdet, birimFiyat, tarih) VALUES (@urunad, @urunadet, @birimFiyat, @tarih)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@urunad", urunad);
                        command.Parameters.AddWithValue("@urunadet", urunAdet);
                        command.Parameters.AddWithValue("@birimFiyat", birimFiyatDegeri);
                        command.Parameters.AddWithValue("@tarih", kayitTarihi);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {

                            MessageBox.Show("Ürün başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AlinanlarListeleme();
                        }
                        else
                        {
                            MessageBox.Show("Ürün eklenirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Alınan sil
        private void alinanSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows[0].Cells["ID"].Value != null)
                {
                    try
                    {
                        int selectedId;
                        if (int.TryParse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString(), out selectedId))
                        {
                            string query = "DELETE FROM alinanlar WHERE ID = @Id";

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Id", selectedId);

                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    AlinanlarListeleme(); // alinanlar tablosunu listeleyen bir fonksiyon
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
                        MessageBox.Show("Kayıt silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void AlinanlarListeleme()
        {
            string query = "SELECT ID, urunAd, urunAdet, birimFiyat, tarih FROM alinanlar";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beklenmedik bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Alınan Güncelle
        private void alinanGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows[0].Cells["ID"].Value != null && int.TryParse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString(), out int selectedId))
                {
                    // Alanların doluluğunu kontrol ediyoruz
                    if (!string.IsNullOrEmpty(uadTb.Text) &&
                        !string.IsNullOrEmpty(uadetTb.Text) &&
                        !string.IsNullOrEmpty(ubrimfiyatTb.Text) &&
                        DateTime.TryParse(utarihDTP.Text, out DateTime kayitTarihi) &&
                        int.TryParse(uadetTb.Text, out int urunAdet) &&
                        int.TryParse(ubrimfiyatTb.Text, out int birimFiyat))
                    {
                        try
                        {
                            string query = "UPDATE alinanlar SET urunAd = @urunAd, urunAdet = @urunAdet, birimFiyat = @birimFiyat, tarih = @tarih WHERE ID = @Id";

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@Id", selectedId);
                                    command.Parameters.AddWithValue("@urunAd", uadTb.Text);
                                    command.Parameters.AddWithValue("@urunAdet", urunAdet);
                                    command.Parameters.AddWithValue("@birimFiyat", birimFiyat);
                                    command.Parameters.AddWithValue("@tarih", kayitTarihi);

                                    connection.Open();
                                    command.ExecuteNonQuery();

                                    MessageBox.Show("Ürün başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    AlinanlarListeleme();
                                }
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Veri güncellenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen tüm alanları doldurun ve geçerli değerler girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        // Listele butonu
        private void listeleBtn_Click(object sender, EventArgs e)
        {
            using (tablo selectionForm = new tablo())
            {
                selectionForm.Owner = this; // Bu satırda, MuhasebeForm'un Owner'ı olarak bu form belirleniyor.

                if (selectionForm.ShowDialog() == DialogResult.OK)
                {
                    string selectedTable = selectionForm.SelectedTable;
                    TabloListeleme(selectedTable);
                }
            }
        }
        // Tablo listeleme
        private void TabloListeleme(string tableName)
        {

            string query = $"SELECT * FROM {tableName}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beklenmedik bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //tablo için listeleme
        public void ListeleTablo(string tableName)
        {

            string query = $"SELECT * FROM {tableName}";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table; // DataGridView'e verileri yükle
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Gider Ekle
        private void giderEkle_Click(object sender, EventArgs e)
        {
            string birimAd = birimAdTb.Text;
            string birimNot = birimNotRTB.Text;
            string birimUcret = birimUcretTb.Text;
            DateTime kayitTarihi = utarihDTP.Value;


            if (!int.TryParse(birimUcret, out int ucret))
            {
                MessageBox.Show("Lütfen geçerli bir ücret girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (string.IsNullOrEmpty(birimAd))
            {
                MessageBox.Show("Lütfen birim adını girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string query = "INSERT INTO giderler (birimAd, birimNot, ucret, tarih) VALUES (@birimAd, @birimNot, @ucret, @tarih)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@birimAd", birimAd);
                        command.Parameters.AddWithValue("@birimNot", birimNot);
                        command.Parameters.AddWithValue("@ucret", ucret);
                        command.Parameters.AddWithValue("@tarih", kayitTarihi);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {

                            MessageBox.Show("Veri başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GiderlerListeleme();
                        }
                        else
                        {
                            MessageBox.Show("Veri eklenirken bir hata oluştu veya hiçbir satır etkilenmedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        // Gider Sil
        private void giderSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows[0].Cells["ID"].Value != null)
                {
                    try
                    {
                        int selectedId;
                        if (int.TryParse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString(), out selectedId))
                        {
                            string query = "DELETE FROM giderler WHERE ID = @Id";

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Id", selectedId);

                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    GiderlerListeleme(); // giderler tablosunu listeleyen bir fonksiyon
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
                        MessageBox.Show("Kayıt silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        // Gider Listeleme
        private void GiderlerListeleme()
        {
            string query = "SELECT ID, birimAd, birimNot, ucret, tarih FROM giderler";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beklenmedik bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Gider güncelle
        private void giderGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows[0].Cells["ID"].Value != null && int.TryParse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString(), out int selectedId))
                {
                    // Alanların doluluğunu kontrol ediyoruz
                    if (!string.IsNullOrEmpty(birimAdTb.Text) &&
                        !string.IsNullOrEmpty(birimNotRTB.Text) &&
                        !string.IsNullOrEmpty(birimUcretTb.Text) &&
                        DateTime.TryParse(utarihDTP.Text, out DateTime kayitTarihi) &&
                        int.TryParse(birimUcretTb.Text, out int ucret))
                    {
                        try
                        {
                            string query = "UPDATE giderler SET birimAd = @birimAd, birimNot = @birimNot, ucret = @ucret, tarih = @tarih WHERE ID = @Id";

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@Id", selectedId);
                                    command.Parameters.AddWithValue("@birimAd", birimAdTb.Text);
                                    command.Parameters.AddWithValue("@birimNot", birimNotRTB.Text);
                                    command.Parameters.AddWithValue("@ucret", ucret);
                                    command.Parameters.AddWithValue("@tarih", kayitTarihi);

                                    connection.Open();
                                    command.ExecuteNonQuery();

                                    MessageBox.Show("Gider başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    GiderlerListeleme();
                                }
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Veri güncellenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen tüm alanları doldurun ve geçerli değerler girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void hesapla_Click(object sender, EventArgs e)
        {

            string updateMuhasebeQuery = @"
    UPDATE muhasebe
    SET 
        pmaas = (SELECT SUM(pmaas) FROM personel),
        giderler = (SELECT SUM(ucret) FROM giderler),
        alinanlar = (SELECT SUM(urunAdet * birimFiyat) FROM alinanlar),
        kar = (
            (SELECT SUM(Fiyat * Satilan) FROM stokTbl) 
            - (SELECT SUM(ucret) FROM giderler)
            - (SELECT SUM(urunAdet * birimFiyat) FROM alinanlar)
            - (SELECT SUM(pmaas) FROM personel)
        )
";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(updateMuhasebeQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string displayMuhasebeQuery = "SELECT * FROM muhasebe";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(displayMuhasebeQuery, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // DataGridView'e veri kaynağını güncelle
                    dataGridView1.DataSource = dataTable;
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


        }
        // Tüm giderler
        private void giderlistele_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
