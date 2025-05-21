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
    public partial class UC_PhieuNhap : UserControl
    {
        public UC_PhieuNhap()
        {
            InitializeComponent();
            LoadDsPhieuNhapHang();
        }

        public void LoadDsPhieuNhapHang()
        {
            dtgvPhieuNhap.DataSource = PhieuNhapHangDAO_Mongo.DSPhieuNhap();
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.Name = "Action";
            btnColumn.HeaderText = "Action";
            btnColumn.Text = "View";
            btnColumn.UseColumnTextForButtonValue = true;

            dtgvPhieuNhap.Columns.Add(btnColumn);
            if (dtgvPhieuNhap.Columns["Id"] != null)
            {
                dtgvPhieuNhap.Columns["Id"].Visible = false;
            }

        }

        private void btn_ThemPhieu_Click(object sender, EventArgs e)
        {
            F_ThemPhieuNhapHang phieu = new F_ThemPhieuNhapHang();
            phieu.Show();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            //dtgvPhieuNhap.DataSource = PhieuNhapHangDAO.DSPhieuNhapHangTheoMa(rtxb_SearchBox.Text);
        }

        private void dtgvPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvPhieuNhap.Columns[e.ColumnIndex].Name == "Action" && e.RowIndex >= 0)
            {
                int idphieu = Convert.ToInt32(dtgvPhieuNhap.Rows[e.RowIndex].Cells["MaPhieuNhap"].Value);
                F_ChiTietPhieuNhap form = new F_ChiTietPhieuNhap(idphieu);
                form.Show();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                dtgvPhieuNhap.DataSource = PhieuNhapHangDAO_Mongo.DSPhieuNhapHangOrderbyMaPhieuNhap();
                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                btnColumn.Name = "Action";
                btnColumn.HeaderText = "Action";
                btnColumn.Text = "View";
                btnColumn.UseColumnTextForButtonValue = true;

                dtgvPhieuNhap.Columns.Add(btnColumn);
                if (dtgvPhieuNhap.Columns["Id"] != null)
                {
                    dtgvPhieuNhap.Columns["Id"].Visible = false;
                }
            }
        }
    }
}
