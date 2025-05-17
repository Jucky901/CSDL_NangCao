namespace FinalProject_IS
{
    partial class F_ChiTietHD_SanPham
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
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.dtgv_ChiTietHD_SP = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ChiTietHD_SP)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_Thoat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.btn_Thoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thoat.ForeColor = System.Drawing.Color.White;
            this.btn_Thoat.Location = new System.Drawing.Point(954, 606);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(218, 43);
            this.btn_Thoat.TabIndex = 53;
            this.btn_Thoat.Text = "+Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = false;
            // 
            // dtgv_ChiTietHD_SP
            // 
            this.dtgv_ChiTietHD_SP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgv_ChiTietHD_SP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_ChiTietHD_SP.Location = new System.Drawing.Point(12, 12);
            this.dtgv_ChiTietHD_SP.Name = "dtgv_ChiTietHD_SP";
            this.dtgv_ChiTietHD_SP.RowHeadersWidth = 51;
            this.dtgv_ChiTietHD_SP.RowTemplate.Height = 24;
            this.dtgv_ChiTietHD_SP.Size = new System.Drawing.Size(1160, 588);
            this.dtgv_ChiTietHD_SP.TabIndex = 52;
            // 
            // F_ChiTietHD_SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 659);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.dtgv_ChiTietHD_SP);
            this.Name = "F_ChiTietHD_SanPham";
            this.Text = "F_ChiTietHD_SanPham";
            this.Load += new System.EventHandler(this.F_ChiTietHD_SanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ChiTietHD_SP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.DataGridView dtgv_ChiTietHD_SP;
    }
}