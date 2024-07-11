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
    public partial class tablo : Form
    {
        public string SelectedTable { get; private set; }
        private const string connectionString = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=fabrikaDb; Trusted_Connection=True;";
        private SqlConnection connection;
        public tablo()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);

        }

        private void tablo_Load(object sender, EventArgs e)
        {
            
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME IN ('alinanlar', 'personel', 'giderler', 'stokTbl')";

            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RadioButton radioButton = new RadioButton
                    {
                        Text = reader["TABLE_NAME"].ToString(),
                        AutoSize = true
                    };
                    radioButton.CheckedChanged += RadioButton_CheckedChanged;
                    flowLayoutPanel1.Controls.Add(radioButton);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Tablolar yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.Checked)
            {
                SelectedTable = radioButton.Text;
            }
        }
       

        private void OkButton_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(SelectedTable))
            {
                MessageBox.Show("Lütfen bir tablo seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close(); // Formu kapat

            
            if (Owner != null && Owner is pmuhasebe muhasebeForm)
            {
                muhasebeForm.ListeleTablo(SelectedTable);
            }
            else
            {
                MessageBox.Show("Muhasebe ekranı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
