using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject_IS.DAOs;

namespace FinalProject_IS
{
    public partial class UC_PhieuNhan : UserControl
    {
        private bool isAscending = true;
        public UC_PhieuNhan()
        {
            InitializeComponent();
            LoadDsPhieuNhan();
        }

        public void LoadDsPhieuNhan()
        {
            dtgvPhieuNhan.DataSource = PhieuNhanDAO.DSPhieuNhan();
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.Name = "Action";
            btnColumn.HeaderText = "Action";
            btnColumn.Text = "View";
            btnColumn.UseColumnTextForButtonValue = true;

            dtgvPhieuNhan.Columns.Add(btnColumn);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            dtgvPhieuNhan.DataSource = PhieuNhanDAO.DSPhieuNhanTheoMa(rtxb_SearchBox.Text);
        }

        //private void btn_ThemPhieu_Click(object sender, EventArgs e)
        //{
        //    int ID = PhieuNhapHangDAO.GetNewPhieuNhapID();
        //    Form2 phieu = new Form2(ID);
        //    phieu.Show();
        //}

        private void btnFilter_Click(object sender, EventArgs e)
        {
            isAscending = !isAscending; // Đảo ngược trạng thái sắp xếp
            cb_Box_Filter_SelectedIndexChanged(sender, e); // Cập nhật DataGridView
        }

        private void cb_Box_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            String values = cb_Box_Filter.Text;
            String nameColum = string.Empty; ;
            if (values == "Sắp xếp theo ngày")
            {
                nameColum = "NgayTao";
            }
            else if (values == "Sắp xếp theo mã")
            {
                nameColum = "MaPhieuNhan";
            }
            try
            {
                dtgvPhieuNhan.DataSource = PhieuNhanDAO.DSSapXepPhieuNhan(nameColum, isAscending);
                // Thông báo sau khi sắp xếp
                string sortOrder = isAscending ? "tăng dần" : "giảm dần";
                MessageBox.Show($"Đã sắp xếp theo {sortOrder} theo cột {nameColum}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }

        }

        private void btn_ThemPhieu_Click(object sender, EventArgs e)
        {
            int id = PhieuNhanDAO.GetNewPhieuNhanID();
            Form3 form = new Form3(id);
            form.Show();
        }

        private void dtgvPhieuNhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvPhieuNhan.Columns[e.ColumnIndex].Name == "Action" && e.RowIndex >= 0)
            {
                MessageBox.Show(dtgvPhieuNhan.Rows[e.RowIndex].Cells["MaPhieuNhan"].Value.ToString());
                int idphieu = Convert.ToInt32(dtgvPhieuNhan.Rows[e.RowIndex].Cells["MaPhieuNhan"].Value);
                F_ChiTietPhieuNhan form = new F_ChiTietPhieuNhan(idphieu);
                form.Show();

            }
        }
    }
}
