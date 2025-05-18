using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject_IS.DAOs;
using FinalProject_IS.Model;

namespace FinalProject_IS
{
    public partial class F_ThemPhieuNhanHang : Form
    {
        public F_ThemPhieuNhanHang(int maphieu)
        {
            InitializeComponent();
        }

        private void btn_ThemPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                List<SanPhamPhieuNhan> sanPhamList = new List<SanPhamPhieuNhan>();
                DateTime ngayNhan = DateTime.UtcNow;

                foreach (DataGridViewRow row in dtgv_ChiTiet.Rows)
                {
                    if (row.IsNewRow) continue;

                    SanPhamPhieuNhan phieu = new SanPhamPhieuNhan
                    {
                        MaSP = Convert.ToInt32(row.Cells["MaSP"].Value),
                        TenSP = row.Cells["TenSP"].Value?.ToString(),
                        SoLuongNhap = Convert.ToInt32(row.Cells["SoLuongNhap"].Value),
                        DonGiaNhap = double.Parse(row.Cells["DonGiaNhap"].Value.ToString()),
                        ThuongHieu = row.Cells["ThuongHieu"].Value?.ToString(),
                        ThoiGianBaoHanh = Convert.ToInt32(row.Cells["ThoiGianBaoHanh"].Value),
                        MoTa = row.Cells["MoTa"].Value?.ToString(),
                        TongTien = double.Parse(row.Cells["TongTien"].Value.ToString())
                    };

                    // --- Begin update logic for PhieuNhapHang ---
                    int soLuongConLai = phieu.SoLuongNhap;
                    // Get all PhieuNhapHang with status "Chưa Duyệt" and this MaSP, ordered by oldest first
                    var phieuNhapList = PhieuNhapHangDAO_Mongo.GetPhieuNhapChuaDuyetByMaSP(phieu.MaSP);

                    foreach (var phieuNhap in phieuNhapList)
                    {
                        if (soLuongConLai <= 0) break;

                        // Find the product detail inside the PhieuNhapHang
                        var sanPham = phieuNhap.SanPham.FirstOrDefault(sp => sp.MaSP == phieu.MaSP);
                        if (sanPham == null) continue;

                        int soLuongThieu = sanPham.SoLuongThieu;
                        int tru = Math.Min(soLuongThieu, soLuongConLai);
                        sanPham.SoLuongThieu -= tru;
                        soLuongConLai -= tru;

                        // Update the entire PhieuNhapHang in DB
                        PhieuNhapHangDAO_Mongo.UpdatePhieuNhapHang(phieuNhap);
                    }
                    // --- End update logic ---

                    sanPhamList.Add(phieu);
                }

                PhieuNhanHang newPhieuNhan = new PhieuNhanHang
                {
                    NgayNhan = ngayNhan,
                    SanPham = sanPhamList
                };

                PhieuNhapHangDAO_Mongo.UpdateTinhTrangPhieuNhap();

                PhieuNhanHangDAO_Mongo.InsertPhieuNhan(newPhieuNhan);

                MessageBox.Show("Phiếu Nhận Hàng đã được thêm thành công.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm phiếu nhận: {ex.Message}");
            }
        }

        private void btn_HuyPhieu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgv_ChiTiet_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["NgayNhan"].Value = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void dtgv_ChiTiet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int id = Convert.ToInt32(dtgv_ChiTiet[2, e.RowIndex].Value);
                SanPham prod = SanPhamDAO_Mongo.GetProductByID(id);
                dtgv_ChiTiet[3, e.RowIndex].Value = prod.TenSP;
                dtgv_ChiTiet[4, e.RowIndex].Value = prod.LoaiSP;
                dtgv_ChiTiet[6, e.RowIndex].Value = prod.GiaGoc.ToString();
                dtgv_ChiTiet[7, e.RowIndex].Value = prod.ThuongHieu;
                dtgv_ChiTiet[8, e.RowIndex].Value = prod.ThoiGianBaoHanh.ToString();
                dtgv_ChiTiet[9, e.RowIndex].Value = prod.MoTa;
            }
            if (e.ColumnIndex == 5)
            {
                dtgv_ChiTiet[10, e.RowIndex].Value =
                    (Convert.ToInt32(dtgv_ChiTiet[5, e.RowIndex].Value) * Convert.ToDecimal(dtgv_ChiTiet[6, e.RowIndex].Value)).ToString();
            }
        }
    }
}
