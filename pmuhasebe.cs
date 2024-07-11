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
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            this.Hide();
            anasayfa.Show();
        }
    }
}
