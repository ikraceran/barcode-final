namespace Barkod_Sistemi
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtAd = new TextBox();
            txtBarkod = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtFiyat = new TextBox();
            label5 = new Label();
            txtAdet = new TextBox();
            label6 = new Label();
            button1 = new Button();
            cmbKategori = new ComboBox();
            cmbAltKategori = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 33);
            label1.Name = "label1";
            label1.Size = new Size(117, 30);
            label1.TabIndex = 0;
            label1.Text = "ÜRÜN ADI";
            // 
            // txtAd
            // 
            txtAd.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtAd.Location = new Point(176, 33);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(305, 30);
            txtAd.TabIndex = 1;
            // 
            // txtBarkod
            // 
            txtBarkod.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtBarkod.Location = new Point(176, 88);
            txtBarkod.Name = "txtBarkod";
            txtBarkod.Size = new Size(305, 30);
            txtBarkod.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 88);
            label2.Name = "label2";
            label2.Size = new Size(99, 30);
            label2.TabIndex = 2;
            label2.Text = "BARKOD";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(13, 142);
            label3.Name = "label3";
            label3.Size = new Size(116, 30);
            label3.TabIndex = 4;
            label3.Text = "KATEGORİ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12.2F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(12, 196);
            label4.Name = "label4";
            label4.Size = new Size(159, 30);
            label4.TabIndex = 6;
            label4.Text = "ALT KATEGORİ";
            // 
            // txtFiyat
            // 
            txtFiyat.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtFiyat.Location = new Point(177, 254);
            txtFiyat.Name = "txtFiyat";
            txtFiyat.Size = new Size(305, 30);
            txtFiyat.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12.2F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(13, 254);
            label5.Name = "label5";
            label5.Size = new Size(68, 30);
            label5.TabIndex = 8;
            label5.Text = "FİYAT";
            // 
            // txtAdet
            // 
            txtAdet.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtAdet.Location = new Point(176, 307);
            txtAdet.Name = "txtAdet";
            txtAdet.Size = new Size(305, 30);
            txtAdet.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12.2F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(12, 307);
            label6.Name = "label6";
            label6.Size = new Size(66, 30);
            label6.TabIndex = 10;
            label6.Text = "ADET";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.AppWorkspace;
            button1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(64, 384);
            button1.Name = "button1";
            button1.Size = new Size(366, 55);
            button1.TabIndex = 12;
            button1.Text = "ÜRÜNÜ KAYDET";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // cmbKategori
            // 
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(177, 142);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(304, 28);
            cmbKategori.TabIndex = 13;
            cmbKategori.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // cmbAltKategori
            // 
            cmbAltKategori.FormattingEnabled = true;
            cmbAltKategori.Location = new Point(177, 196);
            cmbAltKategori.Name = "cmbAltKategori";
            cmbAltKategori.Size = new Size(304, 28);
            cmbAltKategori.TabIndex = 14;
            cmbAltKategori.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(507, 474);
            Controls.Add(cmbAltKategori);
            Controls.Add(cmbKategori);
            Controls.Add(button1);
            Controls.Add(txtAdet);
            Controls.Add(label6);
            Controls.Add(txtFiyat);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtBarkod);
            Controls.Add(label2);
            Controls.Add(txtAd);
            Controls.Add(label1);
            Name = "Form2";
            Text = "YENİ ÜRÜN EKLE";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtAd;
        private TextBox txtBarkod;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtFiyat;
        private Label label5;
        private TextBox txtAdet;
        private Label label6;
        private Button button1;
        private ComboBox cmbKategori;
        private ComboBox cmbAltKategori;
    }
}