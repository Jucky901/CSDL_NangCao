using FinalProject_IS.DAOs;
using FinalProject_IS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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

        public UC_BanHang(string tenNV)
        {
            InitializeComponent();
            dtgvDSSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvDSSanPham.MultiSelect = true;
            InitTempTable();// Chỉ chọn 1 hàng
            dtgvDSSanPham.CellClick += dtgvDSSanPham_CellClick;
            txt_TenNhanVien.Text = tenNV;
        }


        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            khachHang = KhachHangDAO_Mongo.GetKhachHangBySDT(txt_SDT.Text);
            if (khachHang == null)
            {
                txt_HoTen.Text = "Không thấy khách hàng";
                lbl_GiamGia.Text = "0%";
            }
            else
            {
                txt_HoTen.Text = khachHang.HoTen;

                // Lấy loại khách
                var loai = KhachHangDAO_Mongo.GetByMaLoai(khachHang.MaLoaiKH);
                if (loai != null)
                {
                    // Hiển thị mức giảm tối đa (ví dụ "10%")
                    lbl_GiamGia.Text = loai.GiamGiaToiDa.ToString("N0") + "%";
                }
                else
                {
                    lbl_GiamGia.Text = "0%";
                }
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
                    MaLoaiKH = 1,   // Có thể là null nếu không cần
                                    // Use this to get a short date string (no hour, minute, second)
                    NgayBatDau = DateTime.Now.Date
                };
                if (KhachHangDAO_Mongo.InsertKhachHang(khachHang))
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
            if (txtMaSP.Text != "")
            {
                sp = SanPhamDAO_Mongo.GetProductByID(Convert.ToInt32(txtMaSP.Text));

                if (sp != null)
                {
                    txtTenSP.Text = sp.TenSP;
                    txtGia.Text = sp.GiaSP.ToString();
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
            if (e.RowIndex < 0) return;              // Header click bỏ qua
            //dtgvDSSanPham.ClearSelection();          // Bỏ chọn cũ
            //dtgvDSSanPham.Rows[e.RowIndex].Selected = true;
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
            // 1) Tính subtotal và afterCode (như trên)
            decimal subtotal = dtTemp.AsEnumerable().Sum(r => r.Field<decimal>("ThanhTien"));
            decimal codeDiscount = decimal.TryParse(txt_GiamGia.Text, out var cd) ? cd : 0m;
            decimal afterCode = subtotal - codeDiscount;

            // 2) Parse tiền nhập
            decimal cash = decimal.TryParse(txt_TraTienMat.Text, out var t1) ? t1 : 0m;
            decimal transfer = decimal.TryParse(txt_ChuyenKhoan.Text, out var t2) ? t2 : 0m;

            // 3) Tính thiếu dựa trên afterCode
            if (laTienMat)
            {
                decimal missingTransfer = afterCode - cash;
                txt_ChuyenKhoan.Text = (missingTransfer > 0 ? missingTransfer : 0m)
                                        .ToString("N0");
            }
            else
            {
                decimal missingCash = afterCode - transfer;
                txt_TraTienMat.Text = (missingCash > 0 ? missingCash : 0m)
                                        .ToString("N0");
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

        //// 6) Hàm thêm 1 dòng vào dtTemp
        private void AddRowToTemp(String MaSP, string ten, int sl, decimal gia)
        {
            dtTemp.Rows.Add(MaSP, ten, sl, gia);
        }
        //// 7) Hàm tính subtotal và cập nhật các label còn lại
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
            // 1) Tính subtotal từ dtTemp
            decimal subtotal = dtTemp.AsEnumerable()
                                     .Sum(r => r.Field<decimal>("ThanhTien"));

            // 2) Lấy code discount (số tiền) và tính ra afterCode
            decimal codeDiscount = decimal.TryParse(txt_GiamGia.Text, out var cd) ? cd : 0m;
            decimal afterCode = subtotal - codeDiscount;
            lbl_TongTam.Text = afterCode.ToString("N0");

            // 3) Lấy loyalty percent từ label (ví dụ "10%")
            var raw = lbl_GiamGia.Text.Replace("%", "").Trim();
            decimal loyaltyPercent = decimal.TryParse(raw, out var lp) ? lp : 0m;

            // 4) Tính loyalty discount = afterCode * percent / 100
            decimal loyaltyDiscount = afterCode * loyaltyPercent / 100m;
            // 5) Tính tổng cuối và gán lbl_TongCuoi
            decimal totalFinal = afterCode - loyaltyDiscount;
            lbl_TongCuoi.Text = totalFinal.ToString("N0");

            // 5) Tiền khách đưa & tiền thối (dựa trên afterCode)
            decimal cash = decimal.TryParse(txt_TraTienMat.Text, out var t1) ? t1 : 0m;
            decimal transfer = decimal.TryParse(txt_ChuyenKhoan.Text, out var t2) ? t2 : 0m;
            decimal paid = cash + transfer;
            lbl_TienKhachDua.Text = paid.ToString("N0");

            decimal diff = paid - totalFinal;
            if (diff >= 0)
                lbl_TienThoi.Text = diff.ToString("N0");
            else
                lbl_TienThoi.Text = "Thiếu " + Math.Abs(diff).ToString("N0");
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

            while (true)
            {
                soHD = "HD" + DateTime.Now.ToString("yyyyMMddHHmm") + rnd.Next(10, 99);
                if (!HoaDonSanPhamDAO_Mongo.isExistSoHD(soHD))
                    break;
            }

            return soHD;
        }
        private void LuuHoaDon()
        {
            try
            {
                HoaDonSanPham hd = new HoaDonSanPham
                {
                    MaHD = lbl_SoHD.Text,
                    MaKH = khachHang.MaKH,
                    MaNV = NhanVienDAO_Mongo.GetMaNVByName(txt_TenNhanVien.Text), // Lấy từ txt_TenNhanVien.Text
                    NgayGioTao = DateTime.Now,
                    TongTien = double.Parse(lbl_TongCuoi.Text),
                    SanPham = new List<SanPhamHoaDon>()
                };
                foreach (DataRow r in dtTemp.Rows)
                {
                    SanPhamHoaDon spHD = new SanPhamHoaDon
                    {
                        MaSP = int.Parse(r["MaSP"].ToString()),
                        TenSP = r["TenSP"].ToString(),
                        SoLuong = int.Parse(r["SoLuong"].ToString()),
                        DonGia = double.Parse(r["GiaBan"].ToString())
                    };
                    hd.SanPham.Add(spHD);
                }
                HoaDonSanPhamDAO_Mongo.Insert(hd);
                MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private KhuyenMai khuyenMaiDangApDung;   // Lưu thông tin mã giảm giá đang dùng
        private double soTienGiamTuKM;
        private async void Btn_ApDungMaGiamGia_Click(object sender, EventArgs e)
        {
            // --- 1. Lấy danh sách sản phẩm hiện tại
            var products = dtgvDSSanPham.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .Select(r => new {
                    TenSP = r.Cells["TenSP"].Value?.ToString().Trim(),
                    DonGia = double.TryParse(r.Cells["GiaBan"].Value?.ToString(), out var d) ? d : 0
                })
                .Where(p => !string.IsNullOrEmpty(p.TenSP))
                .ToList();

            if (!products.Any())
            {
                MessageBox.Show("Chưa có sản phẩm trong đơn!");
                return;
            }

            // --- 2. Lấy danh sách KM hợp lệ theo ngày, điều kiện tên SP
            var allKm = KhuyenMaiDAO_Mongo.DSKhuyenMai();
            var now = DateTime.UtcNow;
            var eligiblePromotions = allKm
                .Where(km => km.SoLuong > 0
                          && km.NgayBatDau <= now
                          && km.NgayKetThuc >= now
                          && !string.IsNullOrWhiteSpace(km.DieuKienKhuyenMai))
                .ToList();

            // --- 3. Ghép products với Promotion: match TenSP.Contains(DieuKien)
            var matches = products
                .SelectMany(p => eligiblePromotions
                    .Where(km => p.TenSP
                        .IndexOf(km.DieuKienKhuyenMai.Trim(), StringComparison.OrdinalIgnoreCase) >= 0)
                    .Select(km => new ProductWithDiscount
                    {
                        TenSP = p.TenSP,
                        DonGia = p.DonGia,
                        Promotion = km
                    }))
                .ToList();

            if (!matches.Any())
            {
                MessageBox.Show("Không có sản phẩm nào được giảm giá!");
                return;
            }

            // --- 4. Lọc tiếp mã KM khách đã dùng
            var kmDaDungDao = new KhuyenMaiDaDungDAO(MongoConnection.Database);
            var sdt = txt_SDT.Text.Trim();
            var finalList = new List<ProductWithDiscount>();
            foreach (var pd in matches)
            {
                bool daDung = await kmDaDungDao.DaSuDungAsync(pd.Promotion.MaKM, sdt);
                if (!daDung) finalList.Add(pd);
            }

            if (!finalList.Any())
            {
                MessageBox.Show("Bạn đã sử dụng hết mã giảm giá cho các sản phẩm này hoặc không có mã phù hợp!");
                return;
            }

            // --- 5. Hiển thị form con để chọn sản phẩm muốn AP DỤNG
            using (var form = new F_DungMaKhuyenMai(finalList))
            {
                if (form.ShowDialog() != DialogResult.OK || form.SelectedItems.Count == 0)
                    return;

                // Tổng tiền
                if (!double.TryParse(txt_TongTienKhachHang.Text, out double tongTien))
                {
                    MessageBox.Show("Tổng tiền không hợp lệ");
                    return;
                }

                // Cộng dồn số tiền giảm
                double tongGiam = form.SelectedItems.Sum(x => x.SoTienGiam);
                txt_GiamGia.Text = tongGiam.ToString("N0");                 // số tiền giảm từ mã
                txt_TongTienKhachHang.Text = (tongTien - tongGiam).ToString("N0");

                // 6. Lưu các mã KM đã dùng & cập nhật số lượng
                try
                {
                    var khDao = new KhachHangDAO_Mongo(MongoConnection.Database);
                    var maKH = await khDao.TimMaKHTheoSDT(sdt);
                    if (!maKH.HasValue)
                    {
                        MessageBox.Show("Không tìm thấy khách hàng.");
                        return;
                    }

                    foreach (var pd in form.SelectedItems)
                    {
                        await kmDaDungDao.ThemKhuyenMaiDaDungAsync(new KhuyenMaiDaDung
                        {
                            MaKM = pd.Promotion.MaKM,
                            MaKH = maKH.Value,
                            SDT = sdt,
                            NgaySuDung = DateTime.UtcNow,
                            SoTienGiam = pd.SoTienGiam
                        });
                        KhuyenMaiDAO_Mongo.GiamSoLuong(pd.Promotion.MaKM, 1);
                    }

                    MessageBox.Show("Áp dụng mã giảm giá thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu khuyến mãi đã dùng: {ex.Message}");
                }
            }
        }
        public class ProductWithDiscount
        {
            public string TenSP { get; set; }
            public double DonGia { get; set; }
            public KhuyenMai Promotion { get; set; }
            /// <summary>Số tiền giảm trên sản phẩm này</summary>
            public double SoTienGiam => DonGia * (Promotion.GiaTriKhuyenMai / 100.0);
        }
        private List<string> LayDsTenSanPham()
        {
            var ds = new List<string>();
            foreach (DataGridViewRow row in dtgvDSSanPham.Rows)
            {
                if (row.IsNewRow) continue;
                var cell = row.Cells["TenSP"].Value;
                if (cell != null)
                    ds.Add(cell.ToString());
            }
            return ds;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}