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
    public partial class UC_NhanVien : UserControl
    {
        public UC_NhanVien()
        {
            InitializeComponent();
            LoadNV();
        }

        public void LoadNV()
        {
            dtgvNhanVien.DataSource = NhanVienDAO.DsNhanVien();
        }

        private void btn_ThemNV_Click(object sender, EventArgs e)
        {

        }
    }
}
