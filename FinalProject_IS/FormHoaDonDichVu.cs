using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
    public partial class FormHoaDonDichVu : Form
    {
       



        //public FormHoaDonDichVu(List<DataGridViewRow> danhSachSP)
        //{
        //    InitializeComponent();

        //    foreach (var row in danhSachSP)
        //    {
        //        dtg_ChiTietDanLuoi.Rows.Add(
        //            row.Cells["MaSP"].Value,      // Cột Mã sản phẩm
        //            row.Cells["TenSP"].Value,     // Cột Tên sản phẩm
        //            row.Cells["SoLuong"].Value,   // Cột Số lượng
        //            row.Cells["GiaBan"].Value  // Cột Giá bán
        //        );
        //    }
        //}
        public FormHoaDonDichVu(string tenNV, string sdt, string hoTen, List<string[]> danhSachDuocChon)
        {
            InitializeComponent();

            txt_TenNhanVien.Text = tenNV;
            txt_SDT.Text = sdt;
            txt_HoTen.Text = hoTen;

            //dtg_ChiTietDanLuoi.DataSource = danhSachSP;
            foreach (var tenSP in danhSachDuocChon)
            {
                if (!string.IsNullOrEmpty(tenSP[0]) && !string.IsNullOrEmpty(tenSP[1]))
                {
                    dtg_ChiTietDanLuoi.Rows.Add(tenSP[0], "", "", tenSP[1]); // Thêm Tên Lưới và Giá vào bảng
                }
            }


        }
        private void FormHoaDonDichVu_Load(object sender, EventArgs e)
        {
            comboBoxTrangThai.Items.Add("Đã thanh toán");
            comboBoxTrangThai.Items.Add("Chưa thanh toán");
            comboBoxTrangThai.SelectedIndex = 0; // mặc định là "Đã thanh toán"
        }

        private void dtg_ChiTietDanLuoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không nhấn vào tiêu đề cột
            {
                DataGridViewRow row = dtg_ChiTietDanLuoi.Rows[e.RowIndex];

                // Hiển thị thông tin dòng được chọn vào các TextBox
                txtTenVot.Text = row.Cells["TenVot"].Value?.ToString();  // Cột Tên vợt
                txt_SoKG.Text = row.Cells["SoKg"].Value?.ToString();      // Cột Số KG (nếu có)
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dtg_ChiTietDanLuoi.SelectedCells.Count > 0) // Kiểm tra có ô nào được chọn không
            {
                int selectedRowIndex = dtg_ChiTietDanLuoi.SelectedCells[0].RowIndex; // Lấy chỉ số dòng được chọn
                DataGridViewRow selectedRow = dtg_ChiTietDanLuoi.Rows[selectedRowIndex];

                // Cập nhật dữ liệu cho cột Loại Dây và Số KG
                selectedRow.Cells["TenVot"].Value = txtTenVot.Text;  // Nhập Loại Dây
                selectedRow.Cells["SoKg"].Value = txt_SoKG.Text;        // Nhập Số KG
                decimal thanhTienHienTai = selectedRow.Cells["ThanhTien"].Value != null ? Convert.ToDecimal(selectedRow.Cells["ThanhTien"].Value) : 0;

                decimal tienCong = !string.IsNullOrEmpty(txt_TienCong.Text)
                    ? Convert.ToDecimal(txt_TienCong.Text)
                    : 0; // Nếu trống, gán mặc định là 0

                // Cập nhật lại giá trị Thành Tiền
                selectedRow.Cells["ThanhTien"].Value = thanhTienHienTai + tienCong;


                MessageBox.Show("Đã cập nhật chi tiết thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trước khi thêm chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void txt_NgayXuat_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            txt_NgayXuat.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
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
            Font boldFont = new Font("Arial", 10, FontStyle.Bold);
            float y = 20;
            StringFormat sf = new StringFormat(); // để hỗ trợ xuống dòng
            sf.LineAlignment = StringAlignment.Near;

            // Header
            g.DrawString("Nhóm5 Sports", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 80, y); y += 30;
            g.DrawString("Shop Cầu Lông Nhóm_5", font, Brushes.Black, 10, y); y += 20;
            g.DrawString("1, Võ Văn Ngân, TP Thủ Đức", font, Brushes.Black, 10, y); y += 20;
            g.DrawString("ĐT: 0389355222", font, Brushes.Black, 10, y); y += 30;

            g.DrawString("PHIẾU TÍNH TIỀN", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 60, y); y += 30;

            g.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), font, Brushes.Black, 10, y); y += 20;
            g.DrawString("Khách hàng: " + txt_HoTen.Text, font, Brushes.Black, 10, y); y += 20;
            g.DrawString("SĐT: " + txt_SDT.Text, font, Brushes.Black, 10, y); y += 20;
            g.DrawString("Nhân viên: " + txt_TenNhanVien.Text, font, Brushes.Black, 10, y); y += 30;

            string trangThai = comboBoxTrangThai.SelectedItem.ToString();

            // Table layout
            int tableX = 10;
            int colLoaiDay = 200;
            int colTenVot = 120;
            int colSoKG = 60;
            int colThanhTien = 100;
            int rowHeight = 25;

            // Table Header
            g.DrawRectangle(Pens.Black, tableX, y, colLoaiDay, rowHeight);
            g.DrawRectangle(Pens.Black, tableX + colLoaiDay, y, colTenVot, rowHeight);
            g.DrawRectangle(Pens.Black, tableX + colLoaiDay + colTenVot, y, colSoKG, rowHeight);

            g.DrawString("Loại Dây", boldFont, Brushes.Black, tableX + 5, y + 5);
            g.DrawString("Tên Vợt", boldFont, Brushes.Black, tableX + colLoaiDay + 5, y + 5);
            g.DrawString("Số KG", boldFont, Brushes.Black, tableX + colLoaiDay + colTenVot + 5, y + 5);

            if (trangThai == "Chưa thanh toán")
            {
                g.DrawRectangle(Pens.Black, tableX + colLoaiDay + colTenVot + colSoKG, y, colThanhTien, rowHeight);
                g.DrawString("Thành tiền", boldFont, Brushes.Black, tableX + colLoaiDay + colTenVot + colSoKG + 5, y + 5);
            }

            y += rowHeight;

            decimal tongTien = 0;

            foreach (DataGridViewRow row in dtg_ChiTietDanLuoi.Rows)
            {
                if (row.IsNewRow) continue;

                string loaiDay = row.Cells["LoaiDay"].Value?.ToString() ?? "";
                string tenVot = row.Cells["TenVot"].Value?.ToString() ?? "";
                string soKg = row.Cells["SoKg"].Value?.ToString() ?? "";
                string giaStr = row.Cells["ThanhTien"].Value?.ToString() ?? "0";

                decimal gia = 0;
                decimal.TryParse(giaStr, out gia);
                tongTien += gia;

                // Tính chiều cao dòng dựa trên nội dung
                float height1 = g.MeasureString(loaiDay, font, colLoaiDay - 10, sf).Height;
                float height2 = g.MeasureString(tenVot, font, colTenVot - 10, sf).Height;
                float height3 = g.MeasureString(soKg, font, colSoKG - 10, sf).Height;
                float height4 = 0;
                if (trangThai == "Chưa thanh toán")
                    height4 = g.MeasureString(gia.ToString("N0") + "đ", font, colThanhTien - 10, sf).Height;

                float maxHeight = Math.Max(Math.Max(height1, height2), Math.Max(height3, height4));
                float dynamicRowHeight = Math.Max(rowHeight, maxHeight + 10);

                // Kiểm tra tràn trang
                if (y + dynamicRowHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                // Vẽ khung
                g.DrawRectangle(Pens.Black, tableX, y, colLoaiDay, dynamicRowHeight);
                g.DrawRectangle(Pens.Black, tableX + colLoaiDay, y, colTenVot, dynamicRowHeight);
                g.DrawRectangle(Pens.Black, tableX + colLoaiDay + colTenVot, y, colSoKG, dynamicRowHeight);
                if (trangThai == "Chưa thanh toán")
                    g.DrawRectangle(Pens.Black, tableX + colLoaiDay + colTenVot + colSoKG, y, colThanhTien, dynamicRowHeight);

                // Vẽ nội dung
                g.DrawString(loaiDay, font, Brushes.Black, new RectangleF(tableX + 5, y + 5, colLoaiDay - 10, dynamicRowHeight - 10), sf);
                g.DrawString(tenVot, font, Brushes.Black, new RectangleF(tableX + colLoaiDay + 5, y + 5, colTenVot - 10, dynamicRowHeight - 10), sf);
                g.DrawString(soKg, font, Brushes.Black, new RectangleF(tableX + colLoaiDay + colTenVot + 5, y + 5, colSoKG - 10, dynamicRowHeight - 10), sf);
                if (trangThai == "Chưa thanh toán")
                    g.DrawString(gia.ToString("N0") + "đ", font, Brushes.Black, new RectangleF(tableX + colLoaiDay + colTenVot + colSoKG + 5, y + 5, colThanhTien - 10, dynamicRowHeight - 10), sf);

                y += dynamicRowHeight;
            }

            // Thông tin cuối
            g.DrawString("Ngày lấy vợt: " + date_layvot.Value.ToString("dd/MM/yyyy"), boldFont, Brushes.Black, tableX, y); y += 30;

            if (trangThai == "Chưa thanh toán")
            {
                g.DrawString("Tổng tiền: " + tongTien.ToString("N0") + "đ", boldFont, Brushes.Black, tableX, y); y += 30;
                g.DrawString("Tình trạng: chưa thanh toán", boldFont, Brushes.Black, tableX, y); y += 30;
            }
            else if (trangThai == "Đã thanh toán")
            {
                g.DrawString("Tình trạng: Đã thanh toán: " + tongTien.ToString("N0") + "đ", boldFont, Brushes.Black, tableX, y); y += 30;
            }

            g.DrawString("Xin cảm ơn quý khách!", font, Brushes.Black, tableX + 50, y); y += 20;
            g.DrawString("Hẹn gặp lại!", font, Brushes.Black, tableX + 80, y);
        }

        private void comboBoxTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    int maKH = LayMaKH_TuSDT(txt_SDT.Text);
                    int maNV = LayMaNV_TuTen(txt_TenNhanVien.Text);

                    string sqlHD = @"INSERT INTO HoaDonDichVu 
                             (NgayGioTao, MaKH, SoDienThoai, MaNV, NgayGioLayVot, LoaiPhieu)
                             OUTPUT INSERTED.MaHDDV
                             VALUES 
                             (@NgayGioTao, @MaKH, @SoDienThoai, @MaNV, @NgayGioLayVot, @LoaiPhieu)";
                    SqlCommand cmdHD = new SqlCommand(sqlHD, conn, tran);
                    cmdHD.Parameters.AddWithValue("@NgayGioTao", DateTime.Now);
                    cmdHD.Parameters.AddWithValue("@MaKH", maKH);
                    cmdHD.Parameters.AddWithValue("@SoDienThoai", txt_SDT.Text);
                    cmdHD.Parameters.AddWithValue("@MaNV", maNV);
                    cmdHD.Parameters.AddWithValue("@NgayGioLayVot", date_layvot.Value);
                    cmdHD.Parameters.AddWithValue("@LoaiPhieu", "DV");

                    int maHDDV = (int)cmdHD.ExecuteScalar();

                    foreach (DataGridViewRow row in dtg_ChiTietDanLuoi.Rows)
                    {
                        if (row.IsNewRow) continue; // bỏ dòng trống cuối

                        string tenVot = row.Cells["TenVot"].Value?.ToString();
                        string loaiDay = row.Cells["LoaiDay"].Value?.ToString();
                        int soKG = int.Parse(row.Cells["SoKG"].Value.ToString());
                        decimal thanhTien = decimal.Parse(row.Cells["ThanhTien"].Value.ToString());

                        string sqlCT = @"INSERT INTO ChiTiet_HoaDonDichVu 
                                 (MaHDDV, TenVot, LoaiDay, SoKG, ThanhTien)
                                 VALUES 
                                 (@MaHDDV, @TenVot, @LoaiDay, @SoKG, @ThanhTien)";
                        SqlCommand cmdCT = new SqlCommand(sqlCT, conn, tran);
                        cmdCT.Parameters.AddWithValue("@MaHDDV", maHDDV);
                        cmdCT.Parameters.AddWithValue("@TenVot", tenVot);
                        cmdCT.Parameters.AddWithValue("@LoaiDay", loaiDay);
                        cmdCT.Parameters.AddWithValue("@SoKG", soKG);
                        cmdCT.Parameters.AddWithValue("@ThanhTien", thanhTien);
                        cmdCT.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("Lưu hóa đơn dịch vụ  thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public class ChiTietSanPham
        {
            public string MaVach { get; set; }
            public string TenSP { get; set; }
            public string Size { get; set; }
            public int SoLuong { get; set; }
            public decimal Gia { get; set; }
            public decimal ThanhTien { get; set; }
        }

        private void btn_InHoaDon_Click(object sender, EventArgs e)
        {
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            printDocument.Print();
        }
    }
}
