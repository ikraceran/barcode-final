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

namespace Barkod_Sistemi
{
    public partial class Form2 : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost; Database=petshop_products; Uid=root; Pwd='';");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;

        public Form2()
        {
            InitializeComponent();
            FillTurComboBox();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void FillTurComboBox()
        {
            using (MySqlConnection conn = new MySqlConnection("Server=localhost; Database=petshop_products; Uid=root; Pwd='';"))
            {
                conn.Open();
                string query = "SELECT DISTINCT tur FROM products";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbKategori.Items.Add(reader["tur"].ToString());
                }
                reader.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKategori.SelectedItem != null)
            {
                FillAltTurComboBox(cmbKategori.SelectedItem.ToString());
            }
        }

        private void FillAltTurComboBox(string selectedTur)
        {
            cmbAltKategori.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection("Server=localhost; Database=petshop_products; Uid=root; Pwd='';"))
            {
                conn.Open();
                string query = "SELECT DISTINCT alt_tur FROM products WHERE tur = @selectedTur"; 
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@selectedTur", selectedTur);
                MySqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    cmbAltKategori.Items.Add(reader["alt_tur"].ToString());
                }
                reader.Close();
            }
        }

        void VeriGetir()
        {
            dt = new DataTable();
            conn.Open();
            adapter = new MySqlDataAdapter("SELECT *FROM products", conn);
            adapter.Fill(dt);
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox || control is ComboBox)
                {
                    if (string.IsNullOrWhiteSpace(control.Text))
                    {
                        MessageBox.Show("Lütfen tüm bilgileri doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; 
                    }
                }
            }

            if (IsBarcodeDuplicate(txtBarkod.Text))
            {
                MessageBox.Show("Bu barkod zaten kayıtlı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Kaydetme işlemi başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string sorgu = "Insert into products (isim,barkod,tur,alt_tur,fiyat,adet) values (@ad,@barkod,@kategori,@altkategori,@fiyat,@adet)";
            cmd = new MySqlCommand(sorgu, conn);
            cmd.Parameters.AddWithValue("@ad", txtAd.Text);
            cmd.Parameters.AddWithValue("@barkod", txtBarkod.Text);
            cmd.Parameters.AddWithValue("@kategori", cmbKategori.Text);
            cmd.Parameters.AddWithValue("@altkategori", cmbAltKategori.Text);
            cmd.Parameters.AddWithValue("@fiyat", txtFiyat.Text);
            cmd.Parameters.AddWithValue("@adet", Convert.ToInt32(txtAdet.Text));
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            VeriGetir();

            ResetFormControls();
        }

        private bool IsBarcodeDuplicate(string barcode)
        {
            conn.Open();
            string query = "SELECT COUNT(*) FROM products WHERE barkod = @barcode";
            MySqlCommand checkCmd = new MySqlCommand(query, conn);
            checkCmd.Parameters.AddWithValue("@barcode", barcode);
            int count = Convert.ToInt32(checkCmd.ExecuteScalar());
            conn.Close();

            // If count is greater than 0, the barcode is duplicate
            return count > 0;
        }

        private void ResetFormControls()
        {
            // Iterate through controls and reset values for TextBox and ComboBox
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
