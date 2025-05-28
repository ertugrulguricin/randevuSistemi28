using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace randevuSistemi
{
    public partial class anaSayfa : Form
    {
        public anaSayfa()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-EI3O5LF;Initial Catalog=RandevuSistemi;Integrated Security=True;");

        public void list()
        {
            SqlCommand cmd = new SqlCommand("select * from hasta",conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void anaSayfa_Load(object sender, EventArgs e)
        {
            list();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 form8 = new Form1();
            form8.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form830 = new Form2();
            form830.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form9 = new Form3();
            form9.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form930 = new Form4();
            form930.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 form10 = new Form5();
            form10.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 form1030 = new Form6();
            form1030.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form7 form11 = new Form7();
            form11.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form8 form1130 = new Form8();
            form1130.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form9 form13 = new Form9();
            form13.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form10 form1330 = new Form10();
            form1330.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form11 form14 = new Form11();
            form14.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form12 form1430 = new Form12();
            form1430.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form13 form15 = new Form13();
            form15.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form14 form1530 = new Form14();
            form1530.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form15 form16 = new Form15();
            form16.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form16 form1630 = new Form16();
            form1630.ShowDialog();
        }


        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmd = new SqlCommand("delete from hasta where hasta_id = @hasta_id", conn);

                cmd.Parameters.AddWithValue("@hasta_id", dataGridView1.CurrentRow.Cells["hasta_id"].Value.ToString());
                cmd.ExecuteNonQuery();
                list();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ara(textBox1.Text);
        }

        public void ara(string aranacakkelime)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmd = new SqlCommand("select ad from hasta where hasta_id = @hasta_id LIKE '" + aranacakkelime + "%'",conn);
                DataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

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
    }
}
