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
    public partial class UC_DichVu : UserControl
    {
        public UC_DichVu()
        {
            InitializeComponent();
            LoadDsHoaDonDichVu();
        }

        public void LoadDsHoaDonDichVu()
        {
            dtgvDichVu.DataSource = DichVuDAO.DSDichVu();
        }
    }
}
