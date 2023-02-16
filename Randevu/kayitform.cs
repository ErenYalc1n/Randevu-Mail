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

namespace Randevu
{
    public partial class kayitform : Form
    {
        public kayitform()
        {
            InitializeComponent();
        }

        SqlConnection dbcon = new SqlConnection("Data Source=DESKTOP-TNAKM3U;Initial Catalog=Randevu;Integrated Security=True; TrustServerCertificate=True;");

        private void button1_Click_1(object sender, EventArgs e)
        {
            dbcon.Open();                      
            if(textBox1.Text!="" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text!="" && dateTimePicker1.Text!="")
            {
                SqlCommand kayit = new SqlCommand("INSERT INTO kisiler (tc, sifre, ad, soyad, cinsiyet, dog_tar, mail) VALUES (@1,@2,@3,@4,@5,@6,@7)", dbcon);
                kayit.Parameters.AddWithValue("@1", textBox1.Text);
                kayit.Parameters.AddWithValue("@2", textBox2.Text);
                kayit.Parameters.AddWithValue("@3", textBox3.Text);
                kayit.Parameters.AddWithValue("@4", textBox4.Text);
                kayit.Parameters.AddWithValue("@5", comboBox1.Text);
                kayit.Parameters.AddWithValue("@6", dateTimePicker1.Text);
                kayit.Parameters.AddWithValue("@7", textBox5.Text);
                kayit.ExecuteNonQuery();
                MessageBox.Show("Kayıt başarılı");
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }
            dbcon.Close();
        }
    }
}
