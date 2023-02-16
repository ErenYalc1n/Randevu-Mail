using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Randevu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox3.Visible= false;
            textBox4.Visible= false;
            textBox5.Visible= false;
            dateTimePicker1.Visible= false;
            comboBox1.Visible= false;
            listView1.Visible= false;
            button2.Visible= false;
            label6.Visible= false;
            label7.Visible= false;
            label8.Visible= false;
            label9.Visible= false;
            label10.Visible= false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            label4.Visible= false;
            label5.Visible= false;
            button6.Visible = false;

        }
        public void mailguncelle()
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.office365.com";
            sc.EnableSsl = true;
            SqlCommand alici = new SqlCommand("Select mail From kisiler where tc=@1", dbcon);
            alici.Parameters.AddWithValue("@1", textBox3.Text);
            SqlDataReader oku = alici.ExecuteReader();

            while (oku.Read())
            {
                label11.Text = oku[0].ToString();
            }
            oku.Close();
            string kime = label11.Text;
            string konu = "Randevu";
            string icerik = "Sayýn " + textBox4.Text + " " + textBox5.Text + ",  " + comboBox1.Text + " bölümündeki randevunuz talebinizle "+dateTimePicker1.Text+" tarihine alýnmýþtýr.";

            sc.Credentials = new NetworkCredential("testhesap94@outlook.com", "sifre");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("testhesap94@outlook.com", "Eren Yalçýn");
            mail.To.Add(kime);
            //mail.To.Add("alici2@mail.com");
            mail.Subject = konu;
            mail.IsBodyHtml = true;
            mail.Body = icerik;
            sc.Send(mail);
        }
        public void mailsil()
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.office365.com";
            sc.EnableSsl = true;
            SqlCommand alici = new SqlCommand("Select mail From kisiler where tc=@1", dbcon);
            alici.Parameters.AddWithValue("@1", textBox3.Text);
            SqlDataReader oku = alici.ExecuteReader();

            while (oku.Read())
            {
                label11.Text = oku[0].ToString();
            }
            oku.Close();
            string kime = label11.Text;
            string konu = "Randevu";
            string icerik = "Sayýn " + textBox4.Text + " " + textBox5.Text + ", " + dateTimePicker1.Text + " tarihinde " + comboBox1.Text + " bölümündeki randevunuz talebinizle iptal edilmiþtir.";

            sc.Credentials = new NetworkCredential("testhesap94@outlook.com", "sifre");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("testhesap94@outlook.com", "Eren Yalçýn");
            mail.To.Add(kime);
            //mail.To.Add("alici2@mail.com");
            mail.Subject = konu;
            mail.IsBodyHtml = true;
            mail.Body = icerik;
            sc.Send(mail);
        }
        public void mail()
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.office365.com";
            sc.EnableSsl = true;
            SqlCommand alici = new SqlCommand("Select mail From kisiler where tc=@1", dbcon);
            alici.Parameters.AddWithValue("@1", textBox3.Text);
            SqlDataReader oku = alici.ExecuteReader();

            while (oku.Read())
            {
                label11.Text = oku[0].ToString();
            }          
            string kime = label11.Text;
            string konu = "Randevu";
            string icerik = "Sayýn " + textBox4.Text + " " + textBox5.Text + ", " + dateTimePicker1.Text + " tarihinde " + comboBox1.Text + " bölümünden randevunuz oluþturulmuþtur.";

            sc.Credentials = new NetworkCredential("testhesap94@outlook.com", "sifre");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("testhesap94@outlook.com", "Eren Yalçýn");
            mail.To.Add(kime);
            //mail.To.Add("alici2@mail.com");
            mail.Subject = konu;
            mail.IsBodyHtml = true;
            mail.Body = icerik;
            sc.Send(mail);
        }
        public void goruntule()
        {
            listView1.Items.Clear();           
            SqlCommand gor = new SqlCommand("Select * From randevular", dbcon);
            SqlDataReader oku = gor.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tc"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["soyad"].ToString());
                ekle.SubItems.Add(oku["ran_tar"].ToString());
                ekle.SubItems.Add(oku["bol_adi"].ToString());

                listView1.Items.Add(ekle);
            }            
        }

        SqlConnection dbcon = new SqlConnection("Data Source=DESKTOP-TNAKM3U;Initial Catalog=Randevu;Integrated Security=True; TrustServerCertificate=True;");
        private void button1_Click(object sender, EventArgs e)
        {
            dbcon.Open();
            SqlCommand giris = new SqlCommand("select tc, sifre, ad, soyad from kisiler where tc=@1",dbcon);
            giris.Parameters.AddWithValue("@1", textBox1.Text);
            SqlDataReader oku = giris.ExecuteReader();

            while (oku.Read())
            {
                label4.Text = oku[0].ToString();
                label5.Text = oku[1].ToString();
                textBox3.Text = oku[0].ToString();
                textBox4.Text = oku[2].ToString();
                textBox5.Text= oku[3].ToString();
            }
            if(label5.Text==textBox2.Text)
            {
                MessageBox.Show("Giriþ baþarýlý");
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                button1.Visible = false;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                dateTimePicker1.Visible = true;
                comboBox1.Visible = true;
                listView1.Visible = true;
                button2.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible=true;
            }
            else
            {
                MessageBox.Show("Hatalý giriþ. Kayýt olmadýysanýz lütfen kayýt olunuz.");
            }
            
            dbcon.Close();           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            kayitform f2 = new kayitform();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbcon.Open();
            SqlCommand al = new SqlCommand("Insert Into randevular (tc, ad, soyad, ran_tar, bol_adi) Values (@1,@2,@3,@4,@5)",dbcon);
            al.Parameters.AddWithValue("@1", textBox3.Text);
            al.Parameters.AddWithValue("@2", textBox4.Text);
            al.Parameters.AddWithValue("@3", textBox5.Text);
            al.Parameters.AddWithValue("@4", dateTimePicker1.Text);
            al.Parameters.AddWithValue("@5", comboBox1.Text);
            al.ExecuteNonQuery();
            goruntule();           
            dbcon.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dbcon.Open();
            goruntule();
            dbcon.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dbcon.Open();
            mailsil();
            SqlCommand sil = new SqlCommand("Delete From randevular where ran_tar=@1 and bol_adi=@2",dbcon);
            sil.Parameters.AddWithValue("@1",dateTimePicker1.Text);
            sil.Parameters.AddWithValue("@2", comboBox1.Text);
            sil.ExecuteNonQuery();
            goruntule();           
            dbcon.Close();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dbcon.Open();
            mailguncelle();
            SqlCommand guncelle = new SqlCommand("Update randevular Set tc=@1, ad=@2, soyad=@3, ran_tar=@4, bol_adi=@5 where bol_adi=@6",dbcon);
            guncelle.Parameters.AddWithValue("@1",textBox3.Text);
            guncelle.Parameters.AddWithValue("@2", textBox4.Text);
            guncelle.Parameters.AddWithValue("@3", textBox5.Text);
            guncelle.Parameters.AddWithValue("@4", dateTimePicker1.Text);
            guncelle.Parameters.AddWithValue("@5", comboBox1.Text);
            guncelle.Parameters.AddWithValue("@6", comboBox1.Text);
            guncelle.ExecuteNonQuery();
            goruntule();
            dbcon.Close();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dbcon.Open();
            mail();
            dbcon.Close();
        }
    }
}
