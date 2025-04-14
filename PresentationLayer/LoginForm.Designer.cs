
namespace LibrarySystem
{
    partial class LoginFrom
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ckbHienMatKhau = new System.Windows.Forms.CheckBox();
            this.btDangNhap = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1133, 516);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.ckbHienMatKhau);
            this.groupBox1.Controls.Add(this.btDangNhap);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1131, 514);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibrarySystem.Properties.Resources.library;
            this.pictureBox1.Location = new System.Drawing.Point(6, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(397, 390);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // ckbHienMatKhau
            // 
            this.ckbHienMatKhau.AutoSize = true;
            this.ckbHienMatKhau.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ckbHienMatKhau.Location = new System.Drawing.Point(606, 256);
            this.ckbHienMatKhau.Name = "ckbHienMatKhau";
            this.ckbHienMatKhau.Size = new System.Drawing.Size(190, 34);
            this.ckbHienMatKhau.TabIndex = 8;
            this.ckbHienMatKhau.Text = "Hiện mật khẩu";
            this.ckbHienMatKhau.UseVisualStyleBackColor = true;
            this.ckbHienMatKhau.CheckedChanged += new System.EventHandler(this.ckbHienMatKhau_CheckedChanged);
            // 
            // btDangNhap
            // 
            this.btDangNhap.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btDangNhap.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btDangNhap.FlatAppearance.BorderSize = 0;
            this.btDangNhap.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btDangNhap.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btDangNhap.Location = new System.Drawing.Point(765, 306);
            this.btDangNhap.Name = "btDangNhap";
            this.btDangNhap.Size = new System.Drawing.Size(164, 56);
            this.btDangNhap.TabIndex = 2;
            this.btDangNhap.Text = "Đăng Nhập";
            this.btDangNhap.UseVisualStyleBackColor = false;
            this.btDangNhap.Click += new System.EventHandler(this.btDangNhap_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.Location = new System.Drawing.Point(595, 195);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(334, 44);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.Location = new System.Drawing.Point(595, 130);
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(334, 44);
            this.txtUsername.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(409, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật Khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(409, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên Đăng Nhập";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(510, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 77);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quản Lý Thư Viện";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1133, 516);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginFrom_KeyDown);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox ckbHienMatKhau;
        private System.Windows.Forms.Button btDangNhap;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
    }
}