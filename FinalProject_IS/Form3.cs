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

namespace FinalProject_IS
{
    public partial class Form3 : Form
    {
        private int maphieu;
        public Form3(int maphieu)
        {
            InitializeComponent();
            this.maphieu = maphieu;
        }

        private void btn_ThemPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                List<ChiTietPhieuNhan> list = new List<ChiTietPhieuNhan>();
                foreach (DataGridViewRow row in dtgv_ChiTiet.Rows)
                {
                    if (row.IsNewRow) continue;


                    ChiTietPhieuNhan chitiet = new ChiTietPhieuNhan
                    {
                        
                        MaPhieuNhan = this.maphieu,
                        MaSP = Convert.ToInt32(row.Cells["MaSP"].Value),
                        TenSP = row.Cells["TenSP"].Value?.ToString(),
                        LoaiSP = row.Cells["LoaiSP"].Value?.ToString(),
                        SoLuongNhap = Convert.ToInt32(row.Cells["SoLuongNhap"].Value),
                        DonGiaNhap = decimal.Parse(row.Cells["DonGiaNhap"].Value.ToString()),
                        ThuongHieu = row.Cells["ThuongHieu"].Value?.ToString(),
                        ThoiGianBaoHanh = Convert.ToInt32(row.Cells["ThoiGianBaoHanh"].Value),
                        MoTa = row.Cells["MoTa"].Value?.ToString(),
                        TongTien = decimal.Parse(row.Cells["TongTien"].Value.ToString()),
                        NgayNhan = DateTime.Parse(row.Cells["NgayNhan"].Value.ToString())
                    };

                    list.Add(chitiet);
                }

                if (list.Count >= 1)
                {

                    PhieuNhanDAO.InsertPhieu(new PhieuNhan
                    {
                        NgayTao = list[0].NgayNhan,
                    });

                    for (int i = 0; i < list.Count; i++)
                    {
                        PhieuNhanDAO.InsertChiTietPhieu(list[i]);
                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        PhieuNhapHangDAO.UpdateChiTietPhieuNhapHang(list[i].MaSP, list[i].SoLuongNhap);
                        SanPhamDAO.UpdateSanPhamNhan(list[i].MaSP, list[i].SoLuongNhap);
                    }

                    PhieuNhapHangDAO.UpdateTinhTrangPhieuNhap();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
        }

        private void btn_HuyPhieu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgv_ChiTiet_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["MaPhieuNhan"].Value = this.maphieu;
            e.Row.Cells["NgayNhan"].Value = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void dtgv_ChiTiet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int id = Convert.ToInt32(dtgv_ChiTiet[2, e.RowIndex].Value);
                SanPham prod = SanPhamDAO.GetProductByID(id);
                dtgv_ChiTiet[3, e.RowIndex].Value = prod.TenSP;
                dtgv_ChiTiet[4, e.RowIndex].Value = prod.LoaiSP;
                dtgv_ChiTiet[6, e.RowIndex].Value = prod.GiaGoc.ToString();
                dtgv_ChiTiet[7, e.RowIndex].Value = ThuongHieuDAO.GetTenThuongHieuByID(prod.MaTH);
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
