namespace FinalProject_IS
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
            this.dtgv_ChiTiet = new System.Windows.Forms.DataGridView();
            this.MaPhieuNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThuongHieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianBaoHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_HuyPhieu = new System.Windows.Forms.Button();
            this.btn_ThemPhieu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgv_ChiTiet
            // 
            this.dtgv_ChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgv_ChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_ChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhieuNhan,
            this.NgayNhan,
            this.MaSP,
            this.TenSP,
            this.LoaiSP,
            this.SoLuongNhap,
            this.DonGiaNhap,
            this.ThuongHieu,
            this.ThoiGianBaoHanh,
            this.MoTa,
            this.TongTien,
            this.Action});
            this.dtgv_ChiTiet.Location = new System.Drawing.Point(12, 33);
            this.dtgv_ChiTiet.Name = "dtgv_ChiTiet";
            this.dtgv_ChiTiet.RowHeadersWidth = 51;
            this.dtgv_ChiTiet.RowTemplate.Height = 24;
            this.dtgv_ChiTiet.Size = new System.Drawing.Size(1160, 540);
            this.dtgv_ChiTiet.TabIndex = 49;
            this.dtgv_ChiTiet.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_ChiTiet_CellEndEdit);
            this.dtgv_ChiTiet.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dtgv_ChiTiet_DefaultValuesNeeded);
            // 
            // MaPhieuNhan
            // 
            this.MaPhieuNhan.HeaderText = "Mã Phiếu Nhận";
            this.MaPhieuNhan.MinimumWidth = 6;
            this.MaPhieuNhan.Name = "MaPhieuNhan";
            this.MaPhieuNhan.ReadOnly = true;
            // 
            // NgayNhan
            // 
            this.NgayNhan.HeaderText = "Ngày nhận hàng";
            this.NgayNhan.MinimumWidth = 6;
            this.NgayNhan.Name = "NgayNhan";
            // 
            // MaSP
            // 
            this.MaSP.HeaderText = "Mã Sản Phẩm";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            // 
            // TenSP
            // 
            this.TenSP.HeaderText = "Tên Sản Phẩm";
            this.TenSP.MinimumWidth = 6;
            this.TenSP.Name = "TenSP";
            // 
            // LoaiSP
            // 
            this.LoaiSP.HeaderText = "Loại Sản Phẩm";
            this.LoaiSP.MinimumWidth = 6;
            this.LoaiSP.Name = "LoaiSP";
            // 
            // SoLuongNhap
            // 
            this.SoLuongNhap.HeaderText = "Số Lượng Nhập";
            this.SoLuongNhap.MinimumWidth = 6;
            this.SoLuongNhap.Name = "SoLuongNhap";
            // 
            // DonGiaNhap
            // 
            this.DonGiaNhap.HeaderText = "Đơn Giá Nhập";
            this.DonGiaNhap.MinimumWidth = 6;
            this.DonGiaNhap.Name = "DonGiaNhap";
            // 
            // ThuongHieu
            // 
            this.ThuongHieu.HeaderText = "Thương Hiệu";
            this.ThuongHieu.MinimumWidth = 6;
            this.ThuongHieu.Name = "ThuongHieu";
            // 
            // ThoiGianBaoHanh
            // 
            this.ThoiGianBaoHanh.HeaderText = "Thời gian bảo hành";
            this.ThoiGianBaoHanh.MinimumWidth = 6;
            this.ThoiGianBaoHanh.Name = "ThoiGianBaoHanh";
            // 
            // MoTa
            // 
            this.MoTa.HeaderText = "Mô tả";
            this.MoTa.MinimumWidth = 6;
            this.MoTa.Name = "MoTa";
            // 
            // TongTien
            // 
            this.TongTien.HeaderText = "Tổng Tiền";
            this.TongTien.MinimumWidth = 6;
            this.TongTien.Name = "TongTien";
            // 
            // Action
            // 
            this.Action.HeaderText = "";
            this.Action.MinimumWidth = 6;
            this.Action.Name = "Action";
            this.Action.Text = "Xóa";
            // 
            // btn_HuyPhieu
            // 
            this.btn_HuyPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_HuyPhieu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.btn_HuyPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HuyPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_HuyPhieu.ForeColor = System.Drawing.Color.White;
            this.btn_HuyPhieu.Location = new System.Drawing.Point(742, 601);
            this.btn_HuyPhieu.Name = "btn_HuyPhieu";
            this.btn_HuyPhieu.Size = new System.Drawing.Size(205, 27);
            this.btn_HuyPhieu.TabIndex = 51;
            this.btn_HuyPhieu.Text = "+Hủy bỏ";
            this.btn_HuyPhieu.UseVisualStyleBackColor = false;
            this.btn_HuyPhieu.Click += new System.EventHandler(this.btn_HuyPhieu_Click);
            // 
            // btn_ThemPhieu
            // 
            this.btn_ThemPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(161)))), ((int)(((byte)(203)))));
            this.btn_ThemPhieu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.btn_ThemPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ThemPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemPhieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(238)))), ((int)(((byte)(246)))));
            this.btn_ThemPhieu.Location = new System.Drawing.Point(967, 601);
            this.btn_ThemPhieu.Name = "btn_ThemPhieu";
            this.btn_ThemPhieu.Size = new System.Drawing.Size(205, 27);
            this.btn_ThemPhieu.TabIndex = 50;
            this.btn_ThemPhieu.Text = "+Thêm";
            this.btn_ThemPhieu.UseVisualStyleBackColor = false;
            this.btn_ThemPhieu.Click += new System.EventHandler(this.btn_ThemPhieu_Click);
            // 
            // Form3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.dtgv_ChiTiet);
            this.Controls.Add(this.btn_HuyPhieu);
            this.Controls.Add(this.btn_ThemPhieu);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgv_ChiTiet;
        private System.Windows.Forms.Button btn_HuyPhieu;
        private System.Windows.Forms.Button btn_ThemPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieuNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThuongHieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianBaoHanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTa;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
    }
}