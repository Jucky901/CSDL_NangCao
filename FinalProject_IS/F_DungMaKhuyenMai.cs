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
using static FinalProject_IS.UC_BanHang;

namespace FinalProject_IS
{
    public partial class F_DungMaKhuyenMai : Form
    {
        private readonly List<ProductWithDiscount> _items;
        public List<ProductWithDiscount> SelectedItems { get; private set; }

        // CHỈ nhận đúng list đã lọc từ parent
        public F_DungMaKhuyenMai(List<ProductWithDiscount> items)
        {
            
            InitializeComponent();
            dgvKhuyenMai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhuyenMai.MultiSelect = true;
            _items = items;
        }

        private void F_DungMaKhuyenMai_Load(object sender, EventArgs e)
        {
            dgvKhuyenMai.DataSource = _items;
            dgvKhuyenMai.Columns["Promotion"].Visible = false; // nếu không muốn show object
            dgvKhuyenMai.Columns["SoTienGiam"].HeaderText = "Tiền giảm (VNĐ)";
        }
       
        private void btn_SuDung_Click(object sender, EventArgs e)
        {

            if (dgvKhuyenMai.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn ít nhất một sản phẩm để áp dụng mã!");
                return;
            }

            SelectedItems = dgvKhuyenMai.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(r => r.DataBoundItem as ProductWithDiscount)
                .Where(x => x != null)
                .ToList();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void lbl_ThongBao_Click(object sender, EventArgs e)
        {

        }
    }
}
