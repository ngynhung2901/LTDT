namespace LTDT
{
    partial class formLogin
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
            this.btnthoat = new System.Windows.Forms.Button();
            this.btnlogin = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblQLHS = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(357, 219);
            this.btnthoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(106, 22);
            this.btnthoat.TabIndex = 11;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(215, 219);
            this.btnlogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(106, 22);
            this.btnlogin.TabIndex = 10;
            this.btnlogin.Text = "Đăng nhập";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(199, 156);
            this.Password.Margin = new System.Windows.Forms.Padding(2);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(235, 20);
            this.Password.TabIndex = 8;
            this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(103, 158);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password";
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(199, 106);
            this.Username.Margin = new System.Windows.Forms.Padding(2);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(235, 20);
            this.Username.TabIndex = 6;
            this.Username.TextChanged += new System.EventHandler(this.Username_TextChanged);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(103, 108);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 17);
            this.lblUsername.TabIndex = 7;
            this.lblUsername.Text = "Username";
            // 
            // lblQLHS
            // 
            this.lblQLHS.AutoSize = true;
            this.lblQLHS.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQLHS.ForeColor = System.Drawing.Color.Black;
            this.lblQLHS.Location = new System.Drawing.Point(210, 41);
            this.lblQLHS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQLHS.Name = "lblQLHS";
            this.lblQLHS.Size = new System.Drawing.Size(162, 29);
            this.lblQLHS.TabIndex = 12;
            this.lblQLHS.Text = "ĐĂNG NHẬP";
            // 
            // formLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 286);
            this.Controls.Add(this.lblQLHS);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.lblUsername);
            this.Name = "formLogin";
            this.Text = "formLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblQLHS;
    }
}