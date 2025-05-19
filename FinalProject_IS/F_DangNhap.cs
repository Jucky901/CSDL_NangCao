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
    public partial class F_DangNhap : Form
    {
        public F_DangNhap()
        {
            InitializeComponent();
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            F_Main form = new F_Main();
            string email = txt_MaNV.Text.Trim();
            int manv = -1;

            if (!string.IsNullOrWhiteSpace(txt_MatKhau.Text))
            {
                int.TryParse(txt_MatKhau.Text, out manv);
            }

            NhanVien nv = NhanVienDAO_Mongo.KiemTraDangNhap(email, manv);

            if (nv != null)
            {
                form.manv = nv.MaNV;
                form.tenNV = nv.HoTen;

                if (nv.TenChucVu != null && nv.TenChucVu.ToLower().Contains("Manager"))
                {
                    form.maChucVu = 1;
                }
                else
                {
                    form.maChucVu = 0;
                }

                form.Show();
            }
            else if (string.IsNullOrWhiteSpace(email) && manv == -1)
            {
                form.Show(); // chế độ không đăng nhập
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công");
            }
        }
    }
}
