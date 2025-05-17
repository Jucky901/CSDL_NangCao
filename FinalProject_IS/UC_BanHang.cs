using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject_IS.DAOs;


namespace FinalProject_IS
{
    public partial class UC_BanHang : UserControl
    {
        private KhachHang khachHang;
        private SanPham sp;
        private DataTable dtTemp;
        public DataGridView SanPhamGridView
        {
            get { return this.dtgvDSSanPham; }
        }

        public string TenNhanVien => txt_TenNhanVien.Text;
        public string SDT => txt_SDT.Text;
        public string HoTen => txt_HoTen.Text;

        public UC_BanHang()
        {
            InitializeComponent();
            dtgvDSSanPham.CellClick += dtgvDSSanPham_CellClick;
        }



        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            khachHang = KhachHangDAO.TimKiemKhachHangTheoSDT(txt_SDT.Text);
            if (khachHang == null)
            {
                txt_HoTen.Text = "Không thấy khách hàng";
            }
            else
            {
                txt_HoTen.Text = khachHang.HoTen.ToString();
            }

        }

        private void txtHoTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                khachHang = new KhachHang
                {
                    HoTen = txt_HoTen.Text,
                    SoDienThoai = txt_SDT.Text,
                    TongChiTieu = 0, // Có thể là null nếu không cần
                    MaLoaiKH = 1    // Có thể là null nếu không cần
                };
                if (KhachHangDAO.ThemKhachHang(khachHang))
                {
                    MessageBox.Show("Thêm khách hàng thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại.");
                }
            }
        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {
            //if (txtMaSP.Text != "")
            {
                //SanPham sp = SanPhamDAO.TimSanPhamTheoMaSP(Convert.ToInt32(txtMaSP.Text));
                sp = SanPhamDAO.TimSanPhamTheoMaSP(txtMaSP.Text);

                if (sp != null)
                {
                    txtTenSP.Text = sp.TenSP;
                    txtGia.Text = sp.GiaBan.ToString();
                    txtGiaGoc.Text = sp.GiaGoc.ToString();
                }
                else
                {
                    txtTenSP.Text = "";
                    txtGia.Text = "";
                    txtGiaGoc.Text = "";
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
       
            int rowIndex = dtgvDSSanPham.Rows.Add(
                sp.MaSP,       // Cột 1: Mã sản phẩm
                sp.TenSP,      // Cột 2: Tên sản phẩm
                sp.LoaiSP,     // Cột 3: Loại sản phẩm
                txtSoLuong.Text, // Cột 4: Số Lượng     
                txtGia.Text, // Cột 5: GIá bán
                Convert.ToDecimal(txtGia.Text) * Convert.ToInt64(txtSoLuong.Text),// Cột 6: Thành Tiền
                "",// Cột 7: Ghi chú
                "",
                "Xóa" // Tạm thời gán giá trị cho cột Button
            );
            // Chuyển cột cuối cùng thành Button
            DataGridViewButtonCell btnCell = new DataGridViewButtonCell();
            btnCell.Value = "Xóa"; // Hiển thị nội dung trên Button
            dtgvDSSanPham.Rows[rowIndex].Cells[dtgvDSSanPham.ColumnCount - 1] = btnCell;
            CapNhatTongTien();
        }
        private void dtgvDSSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có phải nút "Xóa" không
            if (e.ColumnIndex == dtgvDSSanPham.ColumnCount - 1 && e.RowIndex >= 0)
            {
                // Hiển thị xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // Lấy giá trị của cột Thành tiền (cột thứ 6)
                    decimal thanhTien = 0;
                    if (dtgvDSSanPham.Rows[e.RowIndex].Cells[5].Value != null)
                    {
                        decimal.TryParse(dtgvDSSanPham.Rows[e.RowIndex].Cells[5].Value.ToString(), out thanhTien);
                    }

                    // Trừ đi giá trị của sản phẩm bị xóa
                    decimal tongTienHienTai = 0;
                    decimal.TryParse(txt_TongTienKhachHang.Text, out tongTienHienTai);
                    txt_TongTienKhachHang.Text = (tongTienHienTai - thanhTien).ToString("N0");

                    // Xóa dòng đã chọn
                    dtgvDSSanPham.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
       
        private void CapNhatTongTien()
        {
            decimal tongTien = 0;

            foreach (DataGridViewRow row in dtgvDSSanPham.Rows)
            {
                if (row.Cells[5].Value != null) // Cột 6: Thành tiền
                {
                    decimal thanhTien;
                    if (decimal.TryParse(row.Cells[5].Value.ToString(), out thanhTien))
                    {
                        tongTien += thanhTien;
                    }
                }
            }

            txt_TongTienKhachHang.Text = tongTien.ToString("N0"); // Hiển thị số tiền dạng 1,000,000
        }

        private void txt_TraTienMat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CapNhatSoTienConThieu(true);
            }
        }

        private void txt_ChuyenKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CapNhatSoTienConThieu(false);
            }
        }
        private void CapNhatSoTienConThieu(bool laTienMat)
        {
            // Lấy giá trị tổng tiền hàng
            decimal tongTien = 0, tienMat = 0, chuyenKhoan = 0;


            decimal.TryParse(txt_TongTienKhachHang.Text, out tongTien);
            decimal.TryParse(txt_TraTienMat.Text, out tienMat);
            decimal.TryParse(txt_ChuyenKhoan.Text, out chuyenKhoan);

            // Nếu nhập tiền mặt, cập nhật số tiền chuyển khoản còn thiếu
            if (laTienMat)
            {
                decimal tienThieu = tongTien - tienMat;
                txt_ChuyenKhoan.Text = (tienThieu > 0 ? tienThieu : 0).ToString("N0");
            }
            else // Nếu nhập chuyển khoản, cập nhật số tiền mặt còn thiếu
            {
                decimal tienThieu = tongTien - chuyenKhoan;
                txt_TraTienMat.Text = (tienThieu > 0 ? tienThieu : 0).ToString("N0");
            }

            // Kiểm tra nếu tiền mặt lớn hơn tổng tiền => Chuyển khoản = 0
            if (tienMat >= tongTien)
            {
                txt_ChuyenKhoan.Text = "0";
                //txt_TienThoi.Text = (tienMat - tongTien).ToString("N0"); // Hiển thị tiền thối
            }

        }
        private void InitTempTable()
        {
            // 2) Tạo DataTable với đúng các cột bạn cần
            dtTemp = new DataTable();
            dtTemp.Columns.Add("MaSP", typeof(string));
            dtTemp.Columns.Add("TenSP", typeof(string));
            dtTemp.Columns.Add("SoLuong", typeof(int));
            dtTemp.Columns.Add("GiaBan", typeof(decimal));
            // Cột tính toán tự động
            dtTemp.Columns.Add("ThanhTien", typeof(decimal), "SoLuong * GiaBan");

            // 3) Gán làm DataSource cho dtg_TinhTien
            dtg_TinhTien.DataSource = dtTemp;

            // 4) Khoá những cột không cho edit
            dtg_TinhTien.Columns["MaSP"].ReadOnly = true;
            dtg_TinhTien.Columns["TenSP"].ReadOnly = true;
            dtg_TinhTien.Columns["ThanhTien"].ReadOnly = true;

            // 5) Bắt sự kiện khi user sửa SoLuong hoặc GiaBan để cập nhật subtotal,...
            dtg_TinhTien.CellValueChanged += (s, e) =>
            {
                var col = dtg_TinhTien.Columns[e.ColumnIndex].Name;
                if (col == "SoLuong" || col == "GiaBan")
                    UpdateSubtotal();
            };
        }

        // 6) Hàm thêm 1 dòng vào dtTemp
        private void AddRowToTemp(String MaSP, string ten, int sl, decimal gia)
        {
            dtTemp.Rows.Add(MaSP, ten, sl, gia);
        }
        // 7) Hàm tính subtotal và cập nhật các label còn lại
        private void UpdateSubtotal()
        {
            lbl_SDTKH.Text = txt_SDT.Text;
            if (string.IsNullOrWhiteSpace(txt_HoTen.Text) || txt_HoTen.Text.Equals("Không thấy khách hàng"))
            {
                MessageBox.Show("Khách hàng chưa có thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                lbl_TenKH.Text = txt_HoTen.Text; // Gán giá trị nếu có
            }

            lbl_TenNV.Text = txt_TenNhanVien.Text;
            lbl_NgayXuat.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            decimal subtotal = 0m;
            foreach (DataRow r in dtTemp.Rows)
                subtotal += (decimal)r["ThanhTien"];

            lbl_TongTam.Text = subtotal.ToString("N0");

            // Giảm giá (ví dụ đọc từ txt_MaGiamGia là "10" nghĩa 10%)
            decimal discountPercent = 0m;
            //if (decimal.TryParse(txt_MaGiamGia.Text, out var dp))
            //    discountPercent = dp;
            //lbl_GiamGia.Text = discountPercent.ToString("N0") + "%";

            decimal rate = 1 - discountPercent / 100m;
            decimal totalAfterDiscount = subtotal * rate;
            lbl_TongCuoi.Text = totalAfterDiscount.ToString("N0");

            // Tiền khách đưa
            decimal cash = decimal.TryParse(txt_TraTienMat.Text, out var t1) ? t1 : 0m;
            decimal transfer = decimal.TryParse(txt_ChuyenKhoan.Text, out var t2) ? t2 : 0m;
            decimal paid = cash + transfer;
            lbl_TienKhachDua.Text = paid.ToString("N0");

            // Tiền thối
            lbl_TienThoi.Text = (paid - totalAfterDiscount).ToString("N0");
        }
        private void btn_LuuHoaDon_Click_1(object sender, EventArgs e)
        {
            LuuHoaDon();
        }
        private void button31_Click(object sender, EventArgs e)
        {
            lbl_TenNV.Text = txt_TenNhanVien.Text;
            lbl_SoHD.Text = TaoSoHoaDonNgauNhien();
            //  Xóa hết hàng trong dtTemp,
            dtTemp.Rows.Clear();

            // Lọc và add từng dòng mong muốn từ dtgvDSSanPham
            foreach (DataGridViewRow src in dtgvDSSanPham.Rows)
            {
                if (src.IsNewRow) continue;
               string MaSP = src.Cells["MaSP"].Value?.ToString();
                string ten = src.Cells["TenSP"].Value?.ToString();
                int sl = int.Parse(src.Cells["SoLuong"].Value?.ToString() ?? "0");
                decimal gia = decimal.Parse(src.Cells["GiaBan"].Value?.ToString() ?? "0");

                AddRowToTemp(MaSP, ten, sl, gia);
            }

            UpdateSubtotal();
        }

        private string TaoSoHoaDonNgauNhien()
        {
            string soHD;
            Random rnd = new Random();

            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                conn.Open();
                while (true)
                {
                    soHD = "HD" + DateTime.Now.ToString("yyyyMMddHHmm") + rnd.Next(10, 99);

                    string sql = "SELECT COUNT(*) FROM HoaDon WHERE MaHD = @soHD";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@soHD", soHD);
                        int count = (int)cmd.ExecuteScalar();
                        if (count == 0) break;
                    }
                }
            }
            return soHD;
        }
        private void LuuHoaDon()
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string MaHD = lbl_SoHD.Text;
                    int maKH = LayMaKH_TuSDT(txt_SDT.Text); // tự viết hàm này nếu chưa có
                    int maNV = LayMaNV_TuTen(txt_TenNhanVien.Text); // hoặc lấy từ user đăng nhập


                    string sqlHD = @"INSERT INTO HoaDon (NgayGioTao, MaKH, MaNV, TongTien, LoaiHoaDon, MaHD)
                             OUTPUT INSERTED.MaHD
                             VALUES (@Ngay, @MaKH, @MaNV, @TongTien, @LoaiHD, @MaHD)";
                    SqlCommand cmdHD = new SqlCommand(sqlHD, conn, tran);
                    cmdHD.Parameters.AddWithValue("@Ngay", DateTime.Now);
                    cmdHD.Parameters.AddWithValue("@MaKH", maKH);
                    cmdHD.Parameters.AddWithValue("@MaNV", maNV);
                    cmdHD.Parameters.AddWithValue("@TongTien", decimal.Parse(lbl_TongCuoi.Text));
                    cmdHD.Parameters.AddWithValue("@LoaiHD", "SP");
                    cmdHD.Parameters.AddWithValue("@MaHD", MaHD);

                    string maHD_inserted = (string)cmdHD.ExecuteScalar();

                    foreach (DataRow r in dtTemp.Rows)
                    {
                        string sqlCT = @"INSERT INTO ChiTietHD_SanPham (MaHD, MaSP, SoLuongSP, DonGia)
                                 VALUES (@MaHD, @MaSP, @SL, @Gia)";
                        SqlCommand cmdCT = new SqlCommand(sqlCT, conn, tran);
                        cmdCT.Parameters.AddWithValue("@MaHD", MaHD);
                        cmdCT.Parameters.AddWithValue("@MaSP", r["MaSP"]); // bạn cần viết
                        cmdCT.Parameters.AddWithValue("@SL", r["SoLuong"]);
                        cmdCT.Parameters.AddWithValue("@Gia", r["GiaBan"]);
                        cmdCT.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show($"Hóa đơn {MaHD} đã được lưu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message);
                }
            }
        }
        private int LayMaKH_TuSDT(string sdt)
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                conn.Open();
                string sql = "SELECT MaKH FROM KhachHang WHERE SoDienThoai = @sdt";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sdt", sdt);
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int maKH))
                {
                    return maKH;
                }
                else
                {
                    throw new Exception("Không tìm thấy khách hàng với số điện thoại này!");
                }
            }
        }
        private int LayMaNV_TuTen(string tenNV)
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                conn.Open();
                string sql = "SELECT MaNV FROM NhanVien WHERE HoTen = @ten";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ten", tenNV);
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int maNV))
                {
                    return maNV;
                }
                else
                {
                    throw new Exception("Không tìm thấy nhân viên với tên này!");
                }
            }
        }
        private void btn_LuuHoaDon_Click(object sender, EventArgs e)
        {
            if (dtTemp.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào trong hóa đơn!", "Thông báo");
                return;
            }

            LuuHoaDon();
        }
        private void UC_BanHang_Load(object sender, EventArgs e)
        {
            txt_NgayXuat.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            InitTempTable();
        }

        private void btn_InHoaDon_Click(object sender, EventArgs e)
        {
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            printDocument.Print();
        }

        private void btn_XemTruoc_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            previewDialog.Document = printDocument;
            previewDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Arial", 10);
            float y = 20;

            g.DrawString("Nhóm5 Sports", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 80, y);
            y += 30;

            g.DrawString("Shop Cầu Lông Nhóm_5", font, Brushes.Black, 10, y); y += 20;
            g.DrawString("1, Võ Văn Ngân, TP Thủ Đức", font, Brushes.Black, 10, y); y += 20;
            g.DrawString("ĐT: 0389355222", font, Brushes.Black, 10, y); y += 30;

            g.DrawString("PHIẾU TÍNH TIỀN", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 60, y); y += 30;

            g.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), font, Brushes.Black, 10, y); y += 20;
            g.DrawString("Khách hàng: " + lbl_TenKH.Text, font, Brushes.Black, 10, y); y += 20;
            g.DrawString("SĐT: " + lbl_SDTKH.Text, font, Brushes.Black, 10, y); y += 20;
            g.DrawString("Nhân viên: " + lbl_TenNV.Text, font, Brushes.Black, 10, y); y += 30;

            int tableX = 10;
            int colTenSP = 300;
            int colGia = 70;
            int colSL = 50;
            int colThanhTien = 100;

            int rowHeight = 25;

            // Header
            g.DrawRectangle(Pens.Black, tableX, y, colTenSP, rowHeight);
            g.DrawRectangle(Pens.Black, tableX + colTenSP, y, colGia, rowHeight);
            g.DrawRectangle(Pens.Black, tableX + colTenSP + colGia, y, colSL, rowHeight);
            g.DrawRectangle(Pens.Black, tableX + colTenSP + colGia + colSL, y, colThanhTien, rowHeight);

            g.DrawString("Tên sản phẩm", font, Brushes.Black, tableX + 5, y + 5);
            g.DrawString("Giá", font, Brushes.Black, tableX + colTenSP + 5, y + 5);
            g.DrawString("SL", font, Brushes.Black, tableX + colTenSP + colGia + 5, y + 5);
            g.DrawString("Thành tiền", font, Brushes.Black, tableX + colTenSP + colGia + colSL + 5, y + 5);

            y += rowHeight;

            // Body

            foreach (DataRow row in dtTemp.Rows)
            {
                string tenSP = row["TenSP"].ToString();
                decimal gia = (decimal)row["GiaBan"];
                int sl = (int)row["SoLuong"];
                decimal thanhTien = (decimal)row["ThanhTien"];

                // Tính kích thước cần thiết
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                sf.Trimming = StringTrimming.Word;

                SizeF textSize = g.MeasureString(tenSP, font, colTenSP - 10, sf);
                int actualHeight = (int)Math.Ceiling(textSize.Height + 10);

                // Vẽ khung
                g.DrawRectangle(Pens.Black, tableX, y, colTenSP, actualHeight);
                g.DrawRectangle(Pens.Black, tableX + colTenSP, y, colGia, actualHeight);
                g.DrawRectangle(Pens.Black, tableX + colTenSP + colGia, y, colSL, actualHeight);
                g.DrawRectangle(Pens.Black, tableX + colTenSP + colGia + colSL, y, colThanhTien, actualHeight);

                // Vẽ nội dung
                g.DrawString(tenSP, font, Brushes.Black, new RectangleF(tableX + 5, y + 5, colTenSP - 10, actualHeight), sf);
                g.DrawString(gia.ToString("N0"), font, Brushes.Black, tableX + colTenSP + 5, y + 5);
                g.DrawString(sl.ToString(), font, Brushes.Black, tableX + colTenSP + colGia + 5, y + 5);
                g.DrawString(thanhTien.ToString("N0"), font, Brushes.Black, tableX + colTenSP + colGia + colSL + 5, y + 5);

                y += actualHeight;
            }

            y += 10;
            g.DrawString("Tạm tính: " + lbl_TongTam.Text, font, Brushes.Black, 10, y); y += 20;
            g.DrawString("Số tiền phải thanh to: " + lbl_TongCuoi.Text, font, Brushes.Black, 10, y); y += 20;
            g.DrawString("Tiền khách đưa: " + lbl_TienKhachDua.Text, font, Brushes.Black, 10, y); y += 20;
            g.DrawString("Tiền thối lại: " + lbl_TienThoi.Text, font, Brushes.Black, 10, y); y += 30;

            g.DrawString("Xin cảm ơn quý khách!", font, Brushes.Black, 60, y); y += 20;
            g.DrawString("Hẹn gặp lại!", font, Brushes.Black, 90, y);
        }

        private void dtg_TinhTien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public List<string[]> LayDanhSachTenVaGiaSanPham()
        {
            List<string[]> danhSachTenVaGiaSanPham = new List<string[]>();

            foreach (DataGridViewRow row in dtgvDSSanPham.SelectedRows)
            {
                // Lấy giá trị từ cột "TenSP" và "GiaSP"
                string tenSP = row.Cells["TenSP"].Value?.ToString(); // Lấy Tên SP
                string giaSP = row.Cells["GiaBan"].Value?.ToString(); // Lấy Giá SP

                // Kiểm tra nếu cả hai giá trị đều không null hoặc rỗng
                if (!string.IsNullOrEmpty(tenSP) && !string.IsNullOrEmpty(giaSP))
                {
                    danhSachTenVaGiaSanPham.Add(new string[] { tenSP, giaSP });
                }
            }
            return danhSachTenVaGiaSanPham;
        }


        public string TenNV => txt_TenNhanVien.Text; // Lấy giá trị Tên Nhân Viên
        public string SDTKH => txt_SDT.Text;                 // Lấy giá trị SĐT
        public string HoTenKH => txt_HoTen.Text;             // Lấy giá trị Họ Tên
     

        private void dtgvDSSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu không phải tiêu đề cột và dòng hợp lệ
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy dòng hiện tại
                DataGridViewRow selectedRow = dtgvDSSanPham.Rows[e.RowIndex];

                // Lặp qua các ô trong dòng
                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    if (i == dtgvDSSanPham.ColumnCount - 1) // Kiểm tra cột cuối cùng (cột Button Xóa)
                    {
                        selectedRow.Cells[i].Style.BackColor = Color.White; // Không tô màu (giữ màu mặc định)
                    }
                    else
                    {
                        selectedRow.Cells[i].Style.BackColor = Color.LightGreen; // Tô xanh các ô còn lại
                    }
                }
            }

        }

       
    }
}