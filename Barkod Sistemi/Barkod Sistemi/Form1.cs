using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;

namespace Barkod_Sistemi
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost; Database=petshop_products; Uid=root; Pwd='';");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        int counter = 0;
        DataTable yeniDt = new DataTable();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            txtBarkod.KeyPress += txtBarkod_KeyPress;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VeriGetir();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            HizliMenuListeler("kedi", "hızlı menü", dgwKedi);
            HizliMenuListeler("köpek", "hızlı menü", dgwKopek);
            HizliMenuListeler("kuş", "hızlı menü", dgwKus);

            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.RowsRemoved += dataGridView1_RowsRemoved;
        }

        void VeriGetir()
        {
            dt = new DataTable();
            conn.Open();
            adapter = new MySqlDataAdapter("SELECT *FROM products", conn);
            adapter.Fill(dt);
            dgwListe.DataSource = dt;
            conn.Close();
        }

        private void olustur()
        {
            yeniDt.Columns.Add("BARKOD");
            yeniDt.Columns.Add("ÜRÜN ADI");
            yeniDt.Columns.Add("FİYAT");
            yeniDt.Columns.Add("ADET");
        }

        private void txtBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (counter == 0)
                {
                    olustur();
                }
                counter++;
                string barkod = txtBarkod.Text;
                BarkodAraVeGoster(barkod);
                txtBarkod.Clear();
            }
        }

        private void btnBarkodAra_Click(object sender, EventArgs e)
        {
            string barkod = txtBarkod.Text;
            if (barkod.Length == 13 || barkod.Length == 3)
            {
                if (counter == 0)
                {
                    olustur();
                }
                counter++;
                BarkodAraVeGoster(barkod);
                txtBarkod.Clear();
            }
        }

        private void BarkodAraVeGoster(string barkod)
        {
            conn.Open();
            cmd = new MySqlCommand("SELECT barkod, isim, fiyat FROM products WHERE barkod = @barkod", conn);
            cmd.Parameters.AddWithValue("@barkod", barkod);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string isim = reader["isim"].ToString();
                string fiyat = reader["fiyat"].ToString();

                DataRow existingRow = yeniDt.AsEnumerable().FirstOrDefault(row => row.Field<string>("barkod") == barkod);

                if (existingRow != null)
                {
                    existingRow["adet"] = Convert.ToInt32(existingRow["adet"]) + 1;
                }
                else
                {
                    DataRow newRow = yeniDt.NewRow();
                    newRow["BARKOD"] = barkod;
                    newRow["ÜRÜN ADI"] = isim;
                    newRow["FİYAT"] = fiyat;
                    newRow["ADET"] = 1;

                    yeniDt.Rows.Add(newRow);
                }

                dataGridView1.DataSource = yeniDt;
                HesaplaVeToplamYazdir();

                conn.Close();
            }
            else
            {
                MessageBox.Show("Barkod bulunamadı!");
            }
            conn.Close();
        }

        private void HesaplaVeToplamYazdir()
        {
            decimal toplamTutar = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    int adet = Convert.ToInt32(row.Cells["ADET"].Value);
                    decimal fiyat = Convert.ToDecimal(row.Cells["FİYAT"].Value);
                    decimal urunTutar = adet * fiyat;
                    toplamTutar += urunTutar;
                }
            }
            lblToplamTutar.Text = toplamTutar.ToString("C2"); // C2 formatıyla para birimi olarak yazdırma
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["ADET"].Index && e.RowIndex >= 0)
            {
                HesaplaVeToplamYazdir();
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            HesaplaVeToplamYazdir();
        }

        private void HizliMenuListeler(string tur, string altTur, DataGridView dataGridView)
        {
            string query = "SELECT barkod, isim, fiyat FROM products WHERE tur = @tur AND alt_tur = @altTur";

            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@tur", tur);
            cmd.Parameters.AddWithValue("@altTur", altTur);

            adapter = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);

            dataGridView.DataSource = dt;

            conn.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedNode = e.Node.Text;
            string parentNode = (e.Node.Parent != null) ? e.Node.Parent.Text : string.Empty;
            string query;

            if (e.Node.Parent == null)
            {
                if (selectedNode == "TÜM ÜRÜNLER")
                    query = "SELECT *FROM products";
                else if (selectedNode == "HIZLI MENÜ")
                    query = "SELECT barkod, isim, tur, fiyat, adet FROM products WHERE alt_tur = @alt_tur";
                else
                    query = "SELECT isim, alt_tur, fiyat, adet FROM products WHERE tur = @tur OR alt_tur = @tur";
            }
            else
            {
                query = "SELECT isim, fiyat, adet FROM products WHERE (tur = @tur AND alt_tur = @alt_tur) OR (tur = @alt_tur)";
            }

            conn.Open();
            cmd = new MySqlCommand(query, conn);
            if (e.Node.Parent == null)
            {
                cmd.Parameters.AddWithValue("@tur", selectedNode);
                if (selectedNode == "HIZLI MENÜ")
                {
                    cmd.Parameters.AddWithValue("@alt_tur", selectedNode);
                }
            }
            else
            {
                cmd.Parameters.AddWithValue("@tur", parentNode);
            }


            if (e.Node.Parent != null)
            {
                cmd.Parameters.AddWithValue("@alt_tur", selectedNode);
            }

            adapter = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dgwListe.DataSource = dt;
            conn.Close();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "isim LIKE '" + txtAra.Text + "%'";
            dgwListe.DataSource = dv;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string yeniDeger = dgwListe.CurrentCell.Value.ToString();
            string sutunAdi = dgwListe.Columns[dgwListe.CurrentCell.ColumnIndex].HeaderText;
            int rowIndex = dgwListe.CurrentCell.RowIndex;

            conn.Open();
            cmd = new MySqlCommand("UPDATE products SET " + sutunAdi + " = @yeniDeger WHERE isim = @isim", conn);
            cmd.Parameters.AddWithValue("@yeniDeger", yeniDeger);
            cmd.Parameters.AddWithValue("@isim", dgwListe.Rows[rowIndex].Cells["isim"].Value.ToString());
            cmd.ExecuteNonQuery();
            conn.Close();

            VeriGetir();

            MessageBox.Show("VERİ GÜNCELLENMİŞTİR.");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void btnSatisTamamla_Click(object sender, EventArgs e)
        {
            DateTime satisTarihi = DateTime.Now;
            List<string> satisListesi = new List<string>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string urunAdi = row.Cells["ÜRÜN ADI"].Value.ToString();
                    int adet = Convert.ToInt32(row.Cells["ADET"].Value);
                    satisListesi.Add($"{urunAdi} - Adet: {adet}");

                    UpdateProductQuantity(urunAdi, adet);
                }
            }

            decimal toplamTutar = Convert.ToDecimal(lblToplamTutar.Text.Replace("₺", "").Trim());

            conn.Open();
            cmd = new MySqlCommand("INSERT INTO satislar (tarih_saat, urun_listesi, toplam_tutar) VALUES (@tarihSaat, @urunListesi, @toplamTutar)", conn);
            cmd.Parameters.AddWithValue("@tarihSaat", satisTarihi);
            cmd.Parameters.AddWithValue("@urunListesi", string.Join(", ", satisListesi));
            cmd.Parameters.AddWithValue("@toplamTutar", toplamTutar);
            cmd.ExecuteNonQuery();
            conn.Close();

            TemizleVeYenidenBasla();
            MessageBox.Show($"Satış Tarihi: {satisTarihi}\nSatış Ürünleri: {string.Join(", ", satisListesi)}\nToplam Tutar: {toplamTutar:C2}", "Satış Bilgileri");
        }

        private void UpdateProductQuantity(string productName, int soldQuantity)
        {
            conn.Open();
            cmd = new MySqlCommand("UPDATE products SET adet = adet - @soldQuantity WHERE isim = @productName", conn);
            cmd.Parameters.AddWithValue("@soldQuantity", soldQuantity);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void TemizleVeYenidenBasla()
        {
            yeniDt.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            lblToplamTutar.Text = "₺0.00";
            txtBarkod.Focus();
        }

        private void btnGunlukRapor_Click(object sender, EventArgs e)
        {
            DateTime secilenTarih = dtpRapor.Value.Date;
            List<string[]> raporListesi = new List<string[]>();
            decimal toplamTutar = 0;

            conn.Open();
            cmd = new MySqlCommand("SELECT tarih_saat, urun_listesi, toplam_tutar FROM satislar WHERE DATE(tarih_saat) = @secilenTarih", conn);
            cmd.Parameters.AddWithValue("@secilenTarih", secilenTarih.ToString("yyyy-MM-dd"));
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string tarihSaat = reader["tarih_saat"].ToString();
                string urunListesi = reader["urun_listesi"].ToString();
                string toplamTutarStr = reader["toplam_tutar"].ToString();

                raporListesi.Add(new string[] { tarihSaat, urunListesi, toplamTutarStr });
                toplamTutar += decimal.Parse(toplamTutarStr, System.Globalization.NumberStyles.Currency);
            }
            conn.Close();

            lblSatis.Text = toplamTutar.ToString("C2");


            if (dgwRapor.ColumnCount == 0)
            {
                dgwRapor.Columns.Add("tarihSaat", "Tarih Saat");
                dgwRapor.Columns.Add("urunListesi", "Ürün Listesi");
                dgwRapor.Columns.Add("toplamTutar", "Toplam Tutar");

                dgwRapor.Columns[0].Width = 200;
                dgwRapor.Columns[1].Width = 1102;
                dgwRapor.Columns[2].Width = 150;
            }

            dgwRapor.Rows.Clear();
            foreach (var satir in raporListesi)
            {
                dgwRapor.Rows.Add(satir);
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnGider_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}