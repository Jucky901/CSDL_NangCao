using FinalProject_IS.DAOs;
using FinalProject_IS.Model;
using System;
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
    public partial class F_TaoKhuyenMai : Form
    {
        public F_TaoKhuyenMai()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhuyenMai khuyenMai = new KhuyenMai();
            khuyenMai.TenCTKM = txtTenKM.Text;
            khuyenMai.GiaTriKhuyenMai= double.Parse(txtGiaTri.Text);
            khuyenMai.DieuKienKhuyenMai = txtDieuKien.Text.Trim();
            khuyenMai.NgayBatDau = dateTimePicker1.Value;
            khuyenMai.NgayKetThuc = dateTimePicker2.Value;
            khuyenMai.SoLuong = Convert.ToInt32(txtSoLuong.Text);

            KhuyenMaiDAO_Mongo.InsertKhuyenMai(khuyenMai);
            ClearForm();
            this.Close();
        }
        private void ClearForm()
        {
            txtTenKM.Clear();
            txtGiaTri.Clear();
            txtDieuKien.Clear();
            txtSoLuong.Clear();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }
    }
}
