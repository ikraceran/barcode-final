namespace Barkod_Sistemi
{
    partial class Form3
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
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dtpGider = new DateTimePicker();
            txtTutar = new TextBox();
            txtToptanci = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.AppWorkspace;
            button1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(74, 223);
            button1.Name = "button1";
            button1.Size = new Size(366, 55);
            button1.TabIndex = 25;
            button1.Text = "GİDER BİLGİSİNİ KAYDET";
            button1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(27, 146);
            label3.Name = "label3";
            label3.Size = new Size(80, 30);
            label3.TabIndex = 19;
            label3.Text = "TUTAR";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(26, 92);
            label2.Name = "label2";
            label2.Size = new Size(168, 30);
            label2.TabIndex = 17;
            label2.Text = "TOPTANCI İSMİ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(26, 37);
            label1.Name = "label1";
            label1.Size = new Size(143, 30);
            label1.TabIndex = 15;
            label1.Text = "İŞLEM TARİH";
            // 
            // dtpGider
            // 
            dtpGider.Location = new Point(210, 39);
            dtpGider.Name = "dtpGider";
            dtpGider.Size = new Size(285, 27);
            dtpGider.TabIndex = 27;
            // 
            // txtTutar
            // 
            txtTutar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtTutar.Location = new Point(210, 148);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(285, 30);
            txtTutar.TabIndex = 28;
            // 
            // txtToptanci
            // 
            txtToptanci.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtToptanci.Location = new Point(210, 94);
            txtToptanci.Name = "txtToptanci";
            txtToptanci.Size = new Size(285, 30);
            txtToptanci.TabIndex = 29;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(523, 308);
            Controls.Add(txtToptanci);
            Controls.Add(txtTutar);
            Controls.Add(dtpGider);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form3";
            Text = "GİDER BİLGİSİ EKLE";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbKategori;
        private Button button1;
        private Label label3;
        private TextBox txtBarkod;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpGider;
        private TextBox txtTutar;
        private TextBox txtToptanci;
    }
}