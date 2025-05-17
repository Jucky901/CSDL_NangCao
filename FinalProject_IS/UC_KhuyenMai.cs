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
    public partial class UC_KhuyenMai : UserControl
    {
        public UC_KhuyenMai()
        {
            InitializeComponent();
            LoadDSKhuyenMai();
        }

        public void LoadDSKhuyenMai()
        {
            dtgvKhuyenMai.DataSource = KhuyenMaiDAO.DsKhuyenMai();
        }

        private void btnThem_KM_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dtgvKhuyenMai.SelectedRows.Count > 0)
            {
                // Tạo một danh sách để lưu trữ các mã khuyến mãi cần xóa
                List<int> maKhuyenMaiCanXoa = new List<int>();

                // Duyệt qua các hàng đã được chọn
                foreach (DataGridViewRow row in dtgvKhuyenMai.SelectedRows)
                {                   
                    if (row.Cells["MaKM"].Value != null && int.TryParse(row.Cells["MaKM"].Value.ToString(), out int maKM))
                    {
                        maKhuyenMaiCanXoa.Add(maKM);
                    }
                    else
                    {
                        MessageBox.Show("Mã khuyến mãi không hợp lệ ở một số hàng đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; 
                    }
                }

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa {maKhuyenMaiCanXoa.Count} khuyến mãi đã chọn không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Gọi phương thức trong lớp DAO để xóa các khuyến mãi dựa trên danh sách mã
                        int rowsAffected = KhuyenMaiDAO.XoaNhieuKhuyenMai(maKhuyenMaiCanXoa);

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Đã xóa thành công {rowsAffected} khuyến mãi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Cập nhật lại DataGridView (ví dụ: tải lại dữ liệu)
                            LoadDSKhuyenMai(); 
                        }
                        else
                        {
                            MessageBox.Show("Không có khuyến mãi nào được xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi khi xóa khuyến mãi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
