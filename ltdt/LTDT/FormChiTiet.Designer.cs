namespace LTDT
{
    partial class FormChiTiet
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.btnXuatFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(74, 37);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(468, 24);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "LẬP TRÌNH C# | PHÒNG: P.101 | CA: 7h00 - 9h00";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Location = new System.Drawing.Point(42, 91);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.Size = new System.Drawing.Size(589, 275);
            this.dgvChiTiet.TabIndex = 1;
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.Location = new System.Drawing.Point(254, 392);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(150, 40);
            this.btnXuatFile.TabIndex = 2;
            this.btnXuatFile.Text = "Print File ";
            this.btnXuatFile.UseVisualStyleBackColor = true;
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            // 
            // FormChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 464);
            this.Controls.Add(this.btnXuatFile);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "FormChiTiet";
            this.Text = "FormChiTiet";
            this.Load += new System.EventHandler(this.FormChiTiet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Button btnXuatFile;
    }
}