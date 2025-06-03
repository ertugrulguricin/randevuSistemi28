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
    public partial class hastaKayıt : Form
    {
        public string secilenSaat;
        public int randevuId { get; set; }
        public bool guncellemeModu { get; set; } = false;

        public hastaKayıt()
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

        

        private void Form1_Load(object sender, EventArgs e)
        {
            label7.Text = secilenSaat;

            list();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                if (string.IsNullOrWhiteSpace(label7.Text))
                {
                    MessageBox.Show("Saat bilgisi boş. Lütfen bir saat seçin.");
                    return;
                }

                DateTime bugun = DateTime.Today; // Örneğin: 2025-06-01
                string saat = label7.Text;       // Örneğin: "08:30"
                DateTime tamTarihSaat = DateTime.Parse($"{bugun.ToShortDateString()} {saat}");


                SqlCommand cmd = new SqlCommand("insert into hasta(ad ,soyad ,tc ,cep ,cinsiyet ,sikayet ,randevu_saati ) values (@ad ,@soyad ,@tc ,@cep ,@cinsiyet ,@sikayet ,@randevu_saati)", conn);

                cmd.Parameters.AddWithValue("@hasta_id", dataGridView1.CurrentRow.Cells["hasta_id"].Value.ToString());
                cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
                cmd.Parameters.AddWithValue("@tc", textBox3.Text);
                cmd.Parameters.AddWithValue("@cep", textBox4.Text);
                cmd.Parameters.AddWithValue("@cinsiyet", comboBox1.Text);
                cmd.Parameters.AddWithValue("@sikayet", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@randevu_saati", label7.Text);

                cmd.ExecuteNonQuery();
                list();
                temizle();

                MessageBox.Show("Randevu eklendi!");

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

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();


                SqlCommand cmd = new SqlCommand("update hasta set ad = @ad, soyad = @soyad, tc = @tc, cep = @cep , cinsiyet = @cinsiyet, sikayet = @sikayet , randevu_saati = @randevu_saati WHERE hasta_id = @hasta_id", conn);

                cmd.Parameters.AddWithValue("@hasta_id", dataGridView1.CurrentRow.Cells["hasta_id"].Value.ToString());
                cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
                cmd.Parameters.AddWithValue("@tc", textBox3.Text);
                cmd.Parameters.AddWithValue("@cep", textBox4.Text);
                cmd.Parameters.AddWithValue("@cinsiyet", comboBox1.Text);
                cmd.Parameters.AddWithValue("@sikayet", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@randevu_saati", label7.Text);

                int sonuc = cmd.ExecuteNonQuery();
                list();
                temizle();

                MessageBox.Show(sonuc > 0 ? "Randevu güncellendi." : "Kayıt bulunamadı.");

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
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM hasta WHERE ad LIKE @aranacak", conn);

        }

        public void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            richTextBox1.Clear();
            label7.Text = DateTime.Now.ToString("HH:mm");
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            temizle();
            list();
        }

    }
}
