namespace FinalProject_IS
{
    partial class F_ChiTietPhieuNhap
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
            this.dtgv_ChiTiet = new System.Windows.Forms.DataGridView();
            this.btn_HuyPhieu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgv_ChiTiet
            // 
            this.dtgv_ChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgv_ChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_ChiTiet.Location = new System.Drawing.Point(12, 12);
            this.dtgv_ChiTiet.Name = "dtgv_ChiTiet";
            this.dtgv_ChiTiet.RowHeadersWidth = 51;
            this.dtgv_ChiTiet.RowTemplate.Height = 24;
            this.dtgv_ChiTiet.Size = new System.Drawing.Size(1160, 588);
            this.dtgv_ChiTiet.TabIndex = 1;
            // 
            // btn_HuyPhieu
            // 
            this.btn_HuyPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_HuyPhieu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.btn_HuyPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HuyPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_HuyPhieu.ForeColor = System.Drawing.Color.White;
            this.btn_HuyPhieu.Location = new System.Drawing.Point(954, 606);
            this.btn_HuyPhieu.Name = "btn_HuyPhieu";
            this.btn_HuyPhieu.Size = new System.Drawing.Size(218, 43);
            this.btn_HuyPhieu.TabIndex = 49;
            this.btn_HuyPhieu.Text = "+Thoát";
            this.btn_HuyPhieu.UseVisualStyleBackColor = false;
            // 
            // F_ChiTietPhieuNhap
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.btn_HuyPhieu);
            this.Controls.Add(this.dtgv_ChiTiet);
            this.Name = "F_ChiTietPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChiTietPhieuNhap";
            this.Load += new System.EventHandler(this.ChiTietPhieuNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgv_ChiTiet;
        private System.Windows.Forms.Button btn_HuyPhieu;
    }
}