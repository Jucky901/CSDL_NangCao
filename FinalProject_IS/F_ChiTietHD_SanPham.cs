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
    public partial class F_ChiTietHD_SanPham : Form
    {
        private string mahd;
        public F_ChiTietHD_SanPham(string mahd)
        {
            InitializeComponent();
            this.mahd = mahd;
        }
        private void LoadBang(string id)
        {
            dtgv_ChiTietHD_SP.DataSource = HoaDonDAO.LayChiTietTheoMaHD(id);
        }

        private void F_ChiTietHD_SanPham_Load(object sender, EventArgs e)
        {
            LoadBang(this.mahd);
        }
    }
}
