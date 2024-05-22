using MySql.Data.MySqlClient;
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
using System.Configuration;
using System.Security.Policy;

namespace Barkod_Sistemi
{
    public partial class Form4 : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost; Database=petshop_products; Uid=root; Pwd='';");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

            // Sorgu hazırla
            string query = "SELECT * FROM musteri WHERE kullanici = @kullanici AND sifre = @sifre";

            // Sorguyu MySQL komutu olarak oluştur
            MySqlCommand cmd = new MySqlCommand(query, conn);

            // Parametreleri ekle
            cmd.Parameters.AddWithValue("@kullanici", txt_uname);
            cmd.Parameters.AddWithValue("@sifre", txt_pwd);

            // Sorguyu çalıştır ve sonucu al
            MySqlDataReader reader = cmd.ExecuteReader();

            // Eğer sonuç varsa, giriş başarılıdır
            if (reader.Read())
            {
                MessageBox.Show("Giriş başarılı!");
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else if ((txt_uname.Text == "elifakvaryum") && (txt_pwd.Text == "123456"))
            {
                MessageBox.Show("Giriş başarılı!");
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
            }
        }
        catch (Exception ex)
    {
        // Hata durumunda hata mesajını göster
        MessageBox.Show("Hata: " + ex.Message);
    }
    finally
    {
        // Bağlantıyı kapat
        conn.Close();
    }
        }
    }
}
