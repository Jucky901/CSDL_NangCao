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
    public partial class F_ChiTietPhieuNhan : Form
    {
        private int maphieu;
        public F_ChiTietPhieuNhan(int maphieu)
        {
            InitializeComponent();
            this.maphieu = maphieu;
        }

        private void btn_HuyPhieu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void F_ChiTietPhieuNhan_Load(object sender, EventArgs e)
        {
            LoadBang(this.maphieu);
        }

        private void LoadBang(int id)
        {
            dtgv_ChiTiet.DataSource = PhieuNhanDAO.GetChiTietByID(id);
        }
    }
}
