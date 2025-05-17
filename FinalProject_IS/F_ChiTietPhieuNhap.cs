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
    public partial class F_ChiTietPhieuNhap : Form
    {
        private int maphieu;
        public F_ChiTietPhieuNhap(int maphieu)
        {
            InitializeComponent();
            this.maphieu = maphieu;
        }

        private void ChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadBang(this.maphieu);
        }

        private void LoadBang(int id)
        {
            dtgv_ChiTiet.DataSource = PhieuNhapHangDAO.GetChiTietByID(id);
        }
    }
}
