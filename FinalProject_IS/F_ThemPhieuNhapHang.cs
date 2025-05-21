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
    public partial class F_ThemPhieuNhapHang : Form
    {
        public F_ThemPhieuNhapHang()
        {
            InitializeComponent();
            
        }

        private void btn_ThemPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                List<SanPhamPhieuNhap> sanPhamList = new List<SanPhamPhieuNhap>();
                DateTime ngaytao = DateTime.UtcNow;
                foreach (DataGridViewRow row in dtgv_ChiTiet.Rows)
                {
                    if (row.IsNewRow) continue;
                    SanPhamPhieuNhap phieu = new SanPhamPhieuNhap
                    {
                        MaSP = Convert.ToInt32(row.Cells["MaSP"].Value),
                        TenSP = row.Cells["TenSP"].Value?.ToString(),
                        SoLuongNhap = Convert.ToInt32(row.Cells["SoLuongNhap"].Value),
                        SoLuongThieu = Convert.ToInt32(row.Cells["SoLuongNhap"].Value),
                    };
                    sanPhamList.Add(phieu);
                }
                PhieuNhapHang newPhieuNhap = new PhieuNhapHang
                {
                    NgayTao = ngaytao,
                    SanPham = sanPhamList
                };
                PhieuNhapHangDAO_Mongo.InsertPhieuNhap(newPhieuNhap);
                MessageBox.Show("Phiếu Nhập Hàng đã được thêm thành công.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm phiếu nhập: {ex.Message}");


            }
        }

        private void dtgv_ChiTiet_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
        }

        private void btn_HuyPhieu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgv_ChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgv_ChiTiet.Columns["Action"].Index && e.RowIndex >= 0)
            {
                // Confirm deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    dtgv_ChiTiet.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void dtgv_ChiTiet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewCell thirdCell = dtgv_ChiTiet[1, e.RowIndex];
                int id = Convert.ToInt32(dtgv_ChiTiet[e.ColumnIndex, e.RowIndex].Value);
                thirdCell.Value = SanPhamDAO_Mongo.GetProductByID(id).TenSP;
            }
        }
    }
}
