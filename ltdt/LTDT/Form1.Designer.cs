namespace LTDT
{
    partial class Form1
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
            this.btnXemThongTinPhong = new System.Windows.Forms.Button();
            this.btnnhapfilelich = new System.Windows.Forms.Button();
            this.btnnhapfilesvdk = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btnlammoi = new System.Windows.Forms.Button();
            this.btnxlt = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtngaysinh = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtsosv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcathi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txttenmonthi = new System.Windows.Forms.TextBox();
            this.txtphongthi = new System.Windows.Forms.TextBox();
            this.txtmamonthi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbctroldulieu = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvdangki = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvcathi = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvlichthi = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tbctroldulieu.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdangki)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcathi)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlichthi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnXemThongTinPhong);
            this.panel1.Controls.Add(this.btnnhapfilelich);
            this.panel1.Controls.Add(this.btnnhapfilesvdk);
            this.panel1.Controls.Add(this.btnthoat);
            this.panel1.Controls.Add(this.btnlammoi);
            this.panel1.Controls.Add(this.btnxlt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(586, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(127, 472);
            this.panel1.TabIndex = 0;
            // 
            // btnXemThongTinPhong
            // 
            this.btnXemThongTinPhong.Location = new System.Drawing.Point(17, 247);
            this.btnXemThongTinPhong.Name = "btnXemThongTinPhong";
            this.btnXemThongTinPhong.Size = new System.Drawing.Size(89, 53);
            this.btnXemThongTinPhong.TabIndex = 12;
            this.btnXemThongTinPhong.Text = "Xem Thông Tin Phòng";
            this.btnXemThongTinPhong.UseVisualStyleBackColor = true;
            this.btnXemThongTinPhong.Click += new System.EventHandler(this.btnXemThongTin_Click);
            // 
            // btnnhapfilelich
            // 
            this.btnnhapfilelich.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnhapfilelich.Location = new System.Drawing.Point(17, 80);
            this.btnnhapfilelich.Margin = new System.Windows.Forms.Padding(2);
            this.btnnhapfilelich.Name = "btnnhapfilelich";
            this.btnnhapfilelich.Size = new System.Drawing.Size(89, 47);
            this.btnnhapfilelich.TabIndex = 11;
            this.btnnhapfilelich.Text = "File Lịch/Phòng";
            this.btnnhapfilelich.UseVisualStyleBackColor = true;
            // 
            // btnnhapfilesvdk
            // 
            this.btnnhapfilesvdk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnhapfilesvdk.Location = new System.Drawing.Point(17, 10);
            this.btnnhapfilesvdk.Margin = new System.Windows.Forms.Padding(2);
            this.btnnhapfilesvdk.Name = "btnnhapfilesvdk";
            this.btnnhapfilesvdk.Size = new System.Drawing.Size(89, 47);
            this.btnnhapfilesvdk.TabIndex = 10;
            this.btnnhapfilesvdk.Text = "File SV Đăng Kí";
            this.btnnhapfilesvdk.UseVisualStyleBackColor = true;
            // 
            // btnthoat
            // 
            this.btnthoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthoat.Location = new System.Drawing.Point(17, 390);
            this.btnthoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(89, 47);
            this.btnthoat.TabIndex = 9;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            // 
            // btnlammoi
            // 
            this.btnlammoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlammoi.Location = new System.Drawing.Point(17, 317);
            this.btnlammoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnlammoi.Name = "btnlammoi";
            this.btnlammoi.Size = new System.Drawing.Size(89, 47);
            this.btnlammoi.TabIndex = 8;
            this.btnlammoi.Text = "Làm Mới";
            this.btnlammoi.UseVisualStyleBackColor = true;
            this.btnlammoi.Click += new System.EventHandler(this.btnlammoi_Click_1);
            // 
            // btnxlt
            // 
            this.btnxlt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxlt.Location = new System.Drawing.Point(17, 169);
            this.btnxlt.Margin = new System.Windows.Forms.Padding(2);
            this.btnxlt.Name = "btnxlt";
            this.btnxlt.Size = new System.Drawing.Size(89, 47);
            this.btnxlt.TabIndex = 4;
            this.btnxlt.Text = "Xếp Lịch Thi";
            this.btnxlt.UseVisualStyleBackColor = true;
            this.btnxlt.Click += new System.EventHandler(this.btnxlt_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtngaysinh);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtsosv);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtcathi);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txttenmonthi);
            this.panel2.Controls.Add(this.txtphongthi);
            this.panel2.Controls.Add(this.txtmamonthi);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 350);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(586, 122);
            this.panel2.TabIndex = 1;
            // 
            // dtngaysinh
            // 
            this.dtngaysinh.Location = new System.Drawing.Point(104, 94);
            this.dtngaysinh.Margin = new System.Windows.Forms.Padding(2);
            this.dtngaysinh.Name = "dtngaysinh";
            this.dtngaysinh.Size = new System.Drawing.Size(182, 20);
            this.dtngaysinh.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 89);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ngày Thi:";
            // 
            // txtsosv
            // 
            this.txtsosv.Location = new System.Drawing.Point(344, 38);
            this.txtsosv.Margin = new System.Windows.Forms.Padding(2);
            this.txtsosv.Name = "txtsosv";
            this.txtsosv.Size = new System.Drawing.Size(146, 20);
            this.txtsosv.TabIndex = 10;
            this.txtsosv.TextChanged += new System.EventHandler(this.txtsosv_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(296, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số SV:";
            // 
            // txtcathi
            // 
            this.txtcathi.Location = new System.Drawing.Point(344, 11);
            this.txtcathi.Margin = new System.Windows.Forms.Padding(2);
            this.txtcathi.Name = "txtcathi";
            this.txtcathi.Size = new System.Drawing.Size(146, 20);
            this.txtcathi.TabIndex = 7;
            this.txtcathi.TextChanged += new System.EventHandler(this.txtcathi_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(296, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ca Thi:";
            // 
            // txttenmonthi
            // 
            this.txttenmonthi.Location = new System.Drawing.Point(104, 67);
            this.txttenmonthi.Margin = new System.Windows.Forms.Padding(2);
            this.txttenmonthi.Name = "txttenmonthi";
            this.txttenmonthi.Size = new System.Drawing.Size(182, 20);
            this.txttenmonthi.TabIndex = 5;
            this.txttenmonthi.TextChanged += new System.EventHandler(this.txttenmonthi_TextChanged);
            // 
            // txtphongthi
            // 
            this.txtphongthi.Location = new System.Drawing.Point(104, 40);
            this.txtphongthi.Margin = new System.Windows.Forms.Padding(2);
            this.txtphongthi.Name = "txtphongthi";
            this.txtphongthi.Size = new System.Drawing.Size(96, 20);
            this.txtphongthi.TabIndex = 4;
            this.txtphongthi.TextChanged += new System.EventHandler(this.txtphongthi_TextChanged);
            // 
            // txtmamonthi
            // 
            this.txtmamonthi.Location = new System.Drawing.Point(104, 13);
            this.txtmamonthi.Margin = new System.Windows.Forms.Padding(2);
            this.txtmamonthi.Name = "txtmamonthi";
            this.txtmamonthi.Size = new System.Drawing.Size(96, 20);
            this.txtmamonthi.TabIndex = 3;
            this.txtmamonthi.TextChanged += new System.EventHandler(this.txtmamonthi_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên Môn Thi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phòng Thi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Môn Thi:";
            // 
            // tbctroldulieu
            // 
            this.tbctroldulieu.Controls.Add(this.tabPage2);
            this.tbctroldulieu.Controls.Add(this.tabPage3);
            this.tbctroldulieu.Controls.Add(this.tabPage1);
            this.tbctroldulieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbctroldulieu.Location = new System.Drawing.Point(0, 0);
            this.tbctroldulieu.Margin = new System.Windows.Forms.Padding(2);
            this.tbctroldulieu.Name = "tbctroldulieu";
            this.tbctroldulieu.SelectedIndex = 0;
            this.tbctroldulieu.Size = new System.Drawing.Size(586, 350);
            this.tbctroldulieu.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvdangki);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(578, 324);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DS Sinh Viên Đăng Kí";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvdangki
            // 
            this.dgvdangki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdangki.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvdangki.Location = new System.Drawing.Point(2, 2);
            this.dgvdangki.Margin = new System.Windows.Forms.Padding(2);
            this.dgvdangki.Name = "dgvdangki";
            this.dgvdangki.RowHeadersWidth = 51;
            this.dgvdangki.RowTemplate.Height = 24;
            this.dgvdangki.Size = new System.Drawing.Size(574, 320);
            this.dgvdangki.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvcathi);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(578, 324);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "DS Phòng Thi ( tài nguyên)";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvcathi
            // 
            this.dgvcathi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcathi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvcathi.Location = new System.Drawing.Point(2, 2);
            this.dgvcathi.Margin = new System.Windows.Forms.Padding(2);
            this.dgvcathi.Name = "dgvcathi";
            this.dgvcathi.RowHeadersWidth = 51;
            this.dgvcathi.RowTemplate.Height = 24;
            this.dgvcathi.Size = new System.Drawing.Size(574, 320);
            this.dgvcathi.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvlichthi);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(578, 324);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Kết Quả Xếp Lịch";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvlichthi
            // 
            this.dgvlichthi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlichthi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvlichthi.Location = new System.Drawing.Point(2, 2);
            this.dgvlichthi.Margin = new System.Windows.Forms.Padding(2);
            this.dgvlichthi.Name = "dgvlichthi";
            this.dgvlichthi.RowHeadersWidth = 51;
            this.dgvlichthi.RowTemplate.Height = 24;
            this.dgvlichthi.Size = new System.Drawing.Size(574, 320);
            this.dgvlichthi.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 472);
            this.Controls.Add(this.tbctroldulieu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tbctroldulieu.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdangki)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvcathi)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlichthi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tbctroldulieu;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvdangki;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvcathi;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvlichthi;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btnlammoi;
        private System.Windows.Forms.Button btnxlt;
        private System.Windows.Forms.TextBox txtsosv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtcathi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttenmonthi;
        private System.Windows.Forms.TextBox txtphongthi;
        private System.Windows.Forms.TextBox txtmamonthi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtngaysinh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnnhapfilelich;
        private System.Windows.Forms.Button btnnhapfilesvdk;
        private System.Windows.Forms.Button btnXemThongTinPhong;
    }
}

