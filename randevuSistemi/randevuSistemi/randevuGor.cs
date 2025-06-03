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

namespace randevuSistemi
{
    public partial class randevular: Form
    {
        public randevular()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=tsomtal.com;Initial Catalog=randevuSistemi;Integrated Security=True;");

        public void list()
        {
            SqlCommand cmd = new SqlCommand("select * from hasta", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void randevular_Load(object sender, EventArgs e)
        {
            list();
        }

        public void ara(string aranacakelime)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmd = new SqlCommand("select * from hasta where ad LIKE '" + aranacakelime + "%'", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ara(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmd = new SqlCommand("delete from hasta where hasta_id = @hasta_id", conn);

                cmd.Parameters.AddWithValue("@hasta_id", dataGridView1.CurrentRow.Cells["hasta_id"].Value.ToString());
                cmd.ExecuteNonQuery();

                list();

                MessageBox.Show("Randevu iptal edildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}