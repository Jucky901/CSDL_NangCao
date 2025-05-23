﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_IS
{
    public partial class F_Main : Form
    {
        private bool isLoggingOut = false;
        public UC_BanHang ucBanHang;

        public int manv;
        public string tenNV;
        public int maChucVu;

        private Form loginForm;
        public F_Main()
        {
            InitializeComponent();
        }
        public F_Main(Form loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
            this.FormClosing += F_Main_FormClosing;
        }
        private void F_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLoggingOut)
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ucBanHang = new UC_BanHang(tenNV);
            ucBanHang.Location = new Point(0, 83);
            panel_Main.Controls.Add(ucBanHang);
            ChangeTab(ucBanHang);

            btn_Name.Text = "Xin chào " + tenNV;
            ucBanHang.txt_TenNhanVien.Text = tenNV;

            if (maChucVu != 1)
            {
                btn_DoanhThu.Hide();
                btn_KhuyenMai.Hide();
                btn_PhieuNhan.Hide();
                btn_PhieuNhap.Hide();
                btn_NhanVien.Hide();
            }
        }

        private void btn_BanHang_Click(object sender, EventArgs e)
        {
            ChangeTab(ucBanHang);
        }

        private void btn_DoanhThu_Click(object sender, EventArgs e)
        {
            ChangeTab(new UC_ThongKe());
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            ChangeTab(new UC_KhachHang());
        }

        private void btn_Kho_Click(object sender, EventArgs e)
        {
            ChangeTab(new UC_Kho());
        }

        private void btn_KhuyenMai_Click(object sender, EventArgs e)
        {
            ChangeTab(new UC_KhuyenMai());
        }

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            ChangeTab(new UC_NhanVien());
        }

        private void btn_PhieuNhan_Click(object sender, EventArgs e)
        {
            ChangeTab(new UC_PhieuNhan());
        }

        private void btn_PhieuNhap_Click(object sender, EventArgs e)
        {
            ChangeTab(new UC_PhieuNhap());
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            ChangeTab(new UC_HoaDon());
        }

        private void btn_DichVu_Click(object sender, EventArgs e)
        {
            ChangeTab(new UC_DichVu());
        }

        private void ChangeTab(UserControl uc)
        {
            foreach (Control ctrl in panel_Main.Controls.Cast<Control>().ToList())
            {
                if (ctrl != fpanel_nav)
                {
                    panel_Main.Controls.Remove(ctrl);
                }
            }
            uc.Location = new Point(0, 83);
            panel_Main.Controls.Add(uc);
        }

        private void panel_banHang_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_ThemPhieuDanVot_Click(object sender, EventArgs e)
        {
            // Truy cập vào UC_BanHang để lấy các dòng được chọn
            List<string[]> danhSachDongDuocChon = ucBanHang.LayDanhSachTenVaGiaSanPham();
            string tenNV = ucBanHang.TenNV;
            string sdt = ucBanHang.SDTKH;
            string hoTen = ucBanHang.HoTenKH;

            // Kiểm tra nếu chưa chọn dòng nào
            if (danhSachDongDuocChon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Mở form Phiếu và truyền dữ liệu đã chọn
            FormHoaDonDichVu formPhieu = new FormHoaDonDichVu(tenNV, sdt, hoTen, danhSachDongDuocChon);
            formPhieu.Show();
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            isLoggingOut = true;
            this.Close(); 
            loginForm.Show(); 
        }
    }
}
