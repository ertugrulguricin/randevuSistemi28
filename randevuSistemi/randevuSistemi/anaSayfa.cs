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

namespace randevuSistemi
{
    public partial class anaSayfa : Form
    {
        public anaSayfa()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=tsomtal.com;Initial Catalog=randevuSistemi;Integrated Security=True;");

        Dictionary<string, Button> saatButonlari = new Dictionary<string, Button>();

        private void anaSayfa_Load(object sender, EventArgs e)
        {
            saatButonlari.Add("08:00", button1);
            saatButonlari.Add("08:30", button2);
            saatButonlari.Add("09:00", button3);
            saatButonlari.Add("09:30", button4);
            saatButonlari.Add("10:00", button5);
            saatButonlari.Add("10:30", button6);
            saatButonlari.Add("11:00", button7);
            saatButonlari.Add("11:30", button8);
            saatButonlari.Add("13:00", button9);
            saatButonlari.Add("13:30", button10);
            saatButonlari.Add("14:00", button11);
            saatButonlari.Add("14:30", button12);
            saatButonlari.Add("15:00", button13);
            saatButonlari.Add("15:30", button14);
            saatButonlari.Add("16:00", button15);
            saatButonlari.Add("16:30", button16);

            SaatKontrol();
            ButonClickleriBagla();
        }

        private void SaatKontrol()
        {
            DateTime simdi = DateTime.Now;

            foreach (var saatButon in saatButonlari)
            {
                DateTime saat = DateTime.Today.Add(TimeSpan.Parse(saatButon.Key));
                if (saat < simdi)
                {
                    saatButon.Value.BackColor = Color.Goldenrod;
                    saatButon.Value.Enabled = false;
                }
            }
        }


        private void ButonClickleriBagla()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn && btn.Name.StartsWith("button") && btn.Name != "button17")
                {
                    btn.Click += saatButonu_Click;
                }
            }
        }

        private void saatButonu_Click(object sender, EventArgs e)
        {
            Button tiklananButon = sender as Button;

            if (tiklananButon != null)
            {
                string secilenSaat = tiklananButon.Text;

                hastaKayıt form = new hastaKayıt();
                form.secilenSaat = secilenSaat;
                form.Show();
            }
        }




        private void button1_Click_1(object sender, EventArgs e)
        {
            hastaKayıt form08 = new hastaKayıt();
            form08.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hastaKayıt form0830 = new hastaKayıt();
            form0830.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hastaKayıt form9 = new hastaKayıt();
            form9.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hastaKayıt form930 = new hastaKayıt();
            form930.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hastaKayıt form10 = new hastaKayıt();
            form10.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hastaKayıt form1030 = new hastaKayıt();
            form1030.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hastaKayıt form11 = new hastaKayıt();
            form11.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hastaKayıt form1130 = new hastaKayıt();
            form1130.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            hastaKayıt form13 = new hastaKayıt();
            form13.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            hastaKayıt form1330 = new hastaKayıt();
            form1330.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            hastaKayıt form14 = new hastaKayıt();
            form14.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            hastaKayıt form1430 = new hastaKayıt();
            form1430.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            hastaKayıt form15 = new hastaKayıt();
            form15.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            hastaKayıt form1530 = new hastaKayıt();
            form1530.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            hastaKayıt form16 = new hastaKayıt();
            form16.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            hastaKayıt form1630 = new hastaKayıt();
            form1630.ShowDialog();
        }  

        private void button17_Click(object sender, EventArgs e)
        {
            randevular formrandevu = new randevular();
            formrandevu.ShowDialog();
        }
    }
}