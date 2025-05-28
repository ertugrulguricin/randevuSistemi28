using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace randevuSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-EI3O5LF;Initial Catalog=RandevuSistemi;Integrated Security=True;"); 

        public void list()
        {
            SqlCommand cmd = new SqlCommand("select * from hasta", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list();
            textBox5.Text = "08.00";
            textBox5.Text = DateTime.Now.ToString("HH:mm");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmd = new SqlCommand("insert into hasta(ad ,soyad ,tc ,cep ,cinsiyet ,sikayet ,randevu_saati ,randevu_tarihi) values(@ad ,@soyad ,@tc ,@cep ,@cinsiyet ,@sikayet ,@randevu_saati ,@randevu_tarihi )", conn);

                cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
                cmd.Parameters.AddWithValue("@tc", textBox3.Text);
                cmd.Parameters.AddWithValue("@cep", textBox4.Text);
                cmd.Parameters.AddWithValue("@cinsiyet", comboBox1.Text);
                cmd.Parameters.AddWithValue("@sikayet", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@randevu_saati", textBox5.Text);
                cmd.Parameters.AddWithValue("@randevu_tarihi", dateTimePicker1.Value);
                cmd.ExecuteNonQuery();
                list();
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
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmd = new SqlCommand("update hasta set ad = @ad, soyad = @soyad, tc = @tc, cep = @cep , cinsiyet = @cinsiyet, sikayet = @sikayet, randevu_tarihi = @randevu_tarihi, randevu_saati = @randevu_saati", conn);
            
                cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
                cmd.Parameters.AddWithValue("@tc", textBox3.Text);
                cmd.Parameters.AddWithValue("@cep", textBox4.Text);
                cmd.Parameters.AddWithValue("@cinsiyet", comboBox1.Text);
                cmd.Parameters.AddWithValue("@sikayet", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@randevu_saati", textBox5.Text);
                cmd.Parameters.AddWithValue("@randevu_tarihi", dateTimePicker1.Value);
                cmd.ExecuteNonQuery();
                list();

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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.ReadOnly = true;
            textBox5.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Enabled = false;
        }
    }
}
