namespace FinalProject_IS
{
    partial class FormHoaDonDichVu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHoaDonDichVu));
            this.txt_HoTen = new System.Windows.Forms.RichTextBox();
            this.button27 = new System.Windows.Forms.Button();
            this.txt_TenNhanVien = new System.Windows.Forms.RichTextBox();
            this.button26 = new System.Windows.Forms.Button();
            this.txt_SDT = new System.Windows.Forms.RichTextBox();
            this.button25 = new System.Windows.Forms.Button();
            this.txt_NgayXuat = new System.Windows.Forms.RichTextBox();
            this.button24 = new System.Windows.Forms.Button();
            this.dtg_ChiTietDanLuoi = new System.Windows.Forms.DataGridView();
            this.LoaiDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenVot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoKG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenVot = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.date_layvot = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_TienCong = new System.Windows.Forms.RichTextBox();
            this.lab_tt = new System.Windows.Forms.Label();
            this.comboBoxTrangThai = new System.Windows.Forms.ComboBox();
            this.txt_SoKG = new System.Windows.Forms.RichTextBox();
            this.btn_InHoaDon = new System.Windows.Forms.Button();
            this.btn_XemTruoc = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_ChiTietDanLuoi)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_HoTen
            // 
            this.txt_HoTen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.txt_HoTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_HoTen.Location = new System.Drawing.Point(596, 84);
            this.txt_HoTen.Multiline = false;
            this.txt_HoTen.Name = "txt_HoTen";
            this.txt_HoTen.Size = new System.Drawing.Size(179, 26);
            this.txt_HoTen.TabIndex = 40;
            this.txt_HoTen.Text = "";
            this.txt_HoTen.WordWrap = false;
            // 
            // button27
            // 
            this.button27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(220)))));
            this.button27.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button27.Location = new System.Drawing.Point(455, 84);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(152, 26);
            this.button27.TabIndex = 39;
            this.button27.Text = "Họ tên";
            this.button27.UseVisualStyleBackColor = false;
            // 
            // txt_TenNhanVien
            // 
            this.txt_TenNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.txt_TenNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TenNhanVien.Location = new System.Drawing.Point(596, 42);
            this.txt_TenNhanVien.Name = "txt_TenNhanVien";
            this.txt_TenNhanVien.Size = new System.Drawing.Size(179, 26);
            this.txt_TenNhanVien.TabIndex = 38;
            this.txt_TenNhanVien.Text = "";
            // 
            // button26
            // 
            this.button26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(220)))));
            this.button26.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button26.Location = new System.Drawing.Point(455, 42);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(152, 26);
            this.button26.TabIndex = 37;
            this.button26.Text = "Nhân viên bán hàng";
            this.button26.UseVisualStyleBackColor = false;
            // 
            // txt_SDT
            // 
            this.txt_SDT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.txt_SDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SDT.Location = new System.Drawing.Point(260, 87);
            this.txt_SDT.Name = "txt_SDT";
            this.txt_SDT.Size = new System.Drawing.Size(167, 26);
            this.txt_SDT.TabIndex = 36;
            this.txt_SDT.Text = "";
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(220)))));
            this.button25.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button25.Location = new System.Drawing.Point(160, 87);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(105, 26);
            this.button25.TabIndex = 35;
            this.button25.Text = "SĐT";
            this.button25.UseVisualStyleBackColor = false;
            // 
            // txt_NgayXuat
            // 
            this.txt_NgayXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.txt_NgayXuat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_NgayXuat.Enabled = false;
            this.txt_NgayXuat.Location = new System.Drawing.Point(260, 42);
            this.txt_NgayXuat.Name = "txt_NgayXuat";
            this.txt_NgayXuat.Size = new System.Drawing.Size(167, 26);
            this.txt_NgayXuat.TabIndex = 34;
            this.txt_NgayXuat.Text = "";
            this.txt_NgayXuat.TextChanged += new System.EventHandler(this.txt_NgayXuat_TextChanged);
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(220)))));
            this.button24.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button24.Location = new System.Drawing.Point(160, 42);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(105, 26);
            this.button24.TabIndex = 33;
            this.button24.Text = "Ngày xuất";
            this.button24.UseVisualStyleBackColor = false;
            // 
            // dtg_ChiTietDanLuoi
            // 
            this.dtg_ChiTietDanLuoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_ChiTietDanLuoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoaiDay,
            this.TenVot,
            this.SoKG,
            this.ThanhTien});
            this.dtg_ChiTietDanLuoi.Location = new System.Drawing.Point(233, 202);
            this.dtg_ChiTietDanLuoi.MultiSelect = false;
            this.dtg_ChiTietDanLuoi.Name = "dtg_ChiTietDanLuoi";
            this.dtg_ChiTietDanLuoi.RowHeadersWidth = 51;
            this.dtg_ChiTietDanLuoi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_ChiTietDanLuoi.Size = new System.Drawing.Size(588, 117);
            this.dtg_ChiTietDanLuoi.TabIndex = 20;
            this.dtg_ChiTietDanLuoi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_ChiTietDanLuoi_CellContentClick);
            // 
            // LoaiDay
            // 
            this.LoaiDay.HeaderText = "Loại Dây";
            this.LoaiDay.MinimumWidth = 6;
            this.LoaiDay.Name = "LoaiDay";
            this.LoaiDay.Width = 125;
            // 
            // TenVot
            // 
            this.TenVot.HeaderText = "Tên vợt";
            this.TenVot.MinimumWidth = 6;
            this.TenVot.Name = "TenVot";
            this.TenVot.Width = 125;
            // 
            // SoKG
            // 
            this.SoKG.HeaderText = "SỐ KG";
            this.SoKG.MinimumWidth = 6;
            this.SoKG.Name = "SoKG";
            this.SoKG.Width = 125;
            // 
            // ThanhTien
            // 
            this.ThanhTien.HeaderText = "Giá ";
            this.ThanhTien.MinimumWidth = 6;
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.Width = 125;
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(515, -5);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Phiếu đan vợt";
            // 
            // txtTenVot
            // 
            this.txtTenVot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.txtTenVot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenVot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.txtTenVot.Location = new System.Drawing.Point(160, 133);
            this.txtTenVot.Name = "txtTenVot";
            this.txtTenVot.Size = new System.Drawing.Size(252, 25);
            this.txtTenVot.TabIndex = 28;
            this.txtTenVot.Text = "Tên Vợt";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.date_layvot);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txt_TienCong);
            this.panel1.Controls.Add(this.lab_tt);
            this.panel1.Controls.Add(this.comboBoxTrangThai);
            this.panel1.Controls.Add(this.txt_SoKG);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_HoTen);
            this.panel1.Controls.Add(this.button27);
            this.panel1.Controls.Add(this.dtg_ChiTietDanLuoi);
            this.panel1.Controls.Add(this.btn_InHoaDon);
            this.panel1.Controls.Add(this.txt_TenNhanVien);
            this.panel1.Controls.Add(this.btn_XemTruoc);
            this.panel1.Controls.Add(this.button26);
            this.panel1.Controls.Add(this.txt_SDT);
            this.panel1.Controls.Add(this.button25);
            this.panel1.Controls.Add(this.txt_NgayXuat);
            this.panel1.Controls.Add(this.button24);
            this.panel1.Controls.Add(this.txtTenVot);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 607);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // date_layvot
            // 
            this.date_layvot.Location = new System.Drawing.Point(667, 133);
            this.date_layvot.Name = "date_layvot";
            this.date_layvot.Size = new System.Drawing.Size(154, 22);
            this.date_layvot.TabIndex = 47;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(633, 461);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 29);
            this.button1.TabIndex = 46;
            this.button1.Text = "Lưu phiếu ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_TienCong
            // 
            this.txt_TienCong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.txt_TienCong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TienCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.txt_TienCong.Location = new System.Drawing.Point(555, 133);
            this.txt_TienCong.Name = "txt_TienCong";
            this.txt_TienCong.Size = new System.Drawing.Size(92, 25);
            this.txt_TienCong.TabIndex = 45;
            this.txt_TienCong.Text = "Tiền công";
            // 
            // lab_tt
            // 
            this.lab_tt.AutoSize = true;
            this.lab_tt.Location = new System.Drawing.Point(281, 398);
            this.lab_tt.Name = "lab_tt";
            this.lab_tt.Size = new System.Drawing.Size(134, 16);
            this.lab_tt.TabIndex = 44;
            this.lab_tt.Text = "Trạng thái thanh toán:";
            // 
            // comboBoxTrangThai
            // 
            this.comboBoxTrangThai.FormattingEnabled = true;
            this.comboBoxTrangThai.Location = new System.Drawing.Point(434, 395);
            this.comboBoxTrangThai.Name = "comboBoxTrangThai";
            this.comboBoxTrangThai.Size = new System.Drawing.Size(159, 24);
            this.comboBoxTrangThai.TabIndex = 43;
            this.comboBoxTrangThai.SelectedIndexChanged += new System.EventHandler(this.comboBoxTrangThai_SelectedIndexChanged);
            // 
            // txt_SoKG
            // 
            this.txt_SoKG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.txt_SoKG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SoKG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.txt_SoKG.Location = new System.Drawing.Point(434, 133);
            this.txt_SoKG.Name = "txt_SoKG";
            this.txt_SoKG.Size = new System.Drawing.Size(89, 25);
            this.txt_SoKG.TabIndex = 42;
            this.txt_SoKG.Text = "Số Kg";
            // 
            // btn_InHoaDon
            // 
            this.btn_InHoaDon.Location = new System.Drawing.Point(455, 458);
            this.btn_InHoaDon.Name = "btn_InHoaDon";
            this.btn_InHoaDon.Size = new System.Drawing.Size(142, 29);
            this.btn_InHoaDon.TabIndex = 15;
            this.btn_InHoaDon.Text = "In hóa đơn";
            this.btn_InHoaDon.UseVisualStyleBackColor = true;
            this.btn_InHoaDon.Click += new System.EventHandler(this.btn_InHoaDon_Click);
            // 
            // btn_XemTruoc
            // 
            this.btn_XemTruoc.Location = new System.Drawing.Point(260, 461);
            this.btn_XemTruoc.Name = "btn_XemTruoc";
            this.btn_XemTruoc.Size = new System.Drawing.Size(152, 26);
            this.btn_XemTruoc.TabIndex = 14;
            this.btn_XemTruoc.Text = "Xem trước";
            this.btn_XemTruoc.UseVisualStyleBackColor = true;
            this.btn_XemTruoc.Click += new System.EventHandler(this.btn_XemTruoc_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(161)))), ((int)(((byte)(203)))));
            this.btnThem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(238)))), ((int)(((byte)(246)))));
            this.btnThem.Location = new System.Drawing.Point(848, 131);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(126, 27);
            this.btnThem.TabIndex = 27;
            this.btnThem.Text = "+Thêm chi tiết (F2) ";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(482, 628);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(245, 16);
            this.label14.TabIndex = 21;
            this.label14.Text = "__________________________________";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // FormHoaDonDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 686);
            this.Controls.Add(this.panel1);
            this.Name = "FormHoaDonDichVu";
            this.Text = "FormHoaDonDichVu";
            this.Load += new System.EventHandler(this.FormHoaDonDichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_ChiTietDanLuoi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox txt_HoTen;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.RichTextBox txt_TenNhanVien;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.RichTextBox txt_SDT;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.RichTextBox txt_NgayXuat;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.DataGridView dtg_ChiTietDanLuoi;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtTenVot;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox txt_SoKG;
        private System.Windows.Forms.Button btn_InHoaDon;
        private System.Windows.Forms.Button btn_XemTruoc;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ComboBox comboBoxTrangThai;
        private System.Windows.Forms.Label lab_tt;
        private System.Windows.Forms.RichTextBox txt_TienCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenVot;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoKG;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker date_layvot;
    }
}