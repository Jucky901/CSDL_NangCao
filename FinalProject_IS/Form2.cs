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
    public partial class Form2 : Form
    {
        private int maphieu;
        public Form2(int maphieu)
        {
            InitializeComponent();
            this.maphieu = maphieu;
            
        }

        private void btn_ThemPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                List<ChiTietPhieuNhapHang> list = new List<ChiTietPhieuNhapHang>();
                foreach (DataGridViewRow row in dtgv_ChiTiet.Rows)
                {
                    if (row.IsNewRow) continue;

                    ChiTietPhieuNhapHang chitiet = new ChiTietPhieuNhapHang();
                    chitiet.MaPhieuNhap = this.maphieu;
                    chitiet.MaSP = Convert.ToInt32(row.Cells["MaSP"].Value);
                    chitiet.TenSP = row.Cells["TenSP"].Value?.ToString();
                    chitiet.SoLuongNhap = Convert.ToInt32(row.Cells["SoLuongNhap"].Value);
                    list.Add(chitiet);
                }

                if (list.Count >= 1)
                {
                    PhieuNhapHangDAO.InsertPhieu(new PhieuNhapHang
                    {
                        NgayTao = DateTime.Now,
                        TinhTrangPhieuNhap = "Dang cho"
                    });

                    for (int i = 0; i < list.Count; i++)
                    {
                        PhieuNhapHangDAO.InsertChiTietPhieu(list[i]);
                    }
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("You got StickBug");
            }
            

        }

        private void dtgv_ChiTiet_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["MaPhieuNhap"].Value = this.maphieu;
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
            if (e.ColumnIndex == 1)
            {
                DataGridViewCell thirdCell = dtgv_ChiTiet[2, e.RowIndex];
                int id = Convert.ToInt32(dtgv_ChiTiet[e.ColumnIndex, e.RowIndex].Value);
                thirdCell.Value = SanPhamDAO.GetProductNameByID(id);
            }
        }
    }
}
