namespace Barkod_Sistemi
{
    partial class Form4
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
            txt_uname = new TextBox();
            txt_pwd = new TextBox();
            label2 = new Label();
            btn_giris = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(53, 85);
            label1.Name = "label1";
            label1.Size = new Size(151, 35);
            label1.TabIndex = 0;
            label1.Text = "Kullanıcı Adı";
            // 
            // txt_uname
            // 
            txt_uname.BackColor = SystemColors.InactiveCaption;
            txt_uname.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            txt_uname.Location = new Point(229, 79);
            txt_uname.Name = "txt_uname";
            txt_uname.Size = new Size(211, 41);
            txt_uname.TabIndex = 1;
            // 
            // txt_pwd
            // 
            txt_pwd.BackColor = SystemColors.InactiveCaption;
            txt_pwd.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            txt_pwd.Location = new Point(229, 171);
            txt_pwd.Name = "txt_pwd";
            txt_pwd.Size = new Size(211, 41);
            txt_pwd.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(53, 177);
            label2.Name = "label2";
            label2.Size = new Size(64, 35);
            label2.TabIndex = 2;
            label2.Text = "Şifre";
            // 
            // btn_giris
            // 
            btn_giris.BackColor = Color.Tan;
            btn_giris.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            btn_giris.Location = new Point(142, 262);
            btn_giris.Name = "btn_giris";
            btn_giris.Size = new Size(203, 67);
            btn_giris.TabIndex = 4;
            btn_giris.Text = "GİRİŞ YAP";
            btn_giris.UseVisualStyleBackColor = false;
            btn_giris.Click += btn_giris_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(534, 357);
            Controls.Add(btn_giris);
            Controls.Add(txt_pwd);
            Controls.Add(label2);
            Controls.Add(txt_uname);
            Controls.Add(label1);
            Name = "Form4";
            Text = "Form4";
            Load += Form4_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txt_uname;
        private TextBox txt_pwd;
        private Label label2;
        private Button btn_giris;
    }
}