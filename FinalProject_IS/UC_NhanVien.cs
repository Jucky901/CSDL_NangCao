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
using MongoDB.Driver;

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
            dtgvNhanVien.DataSource = NhanVienDAO_Mongo.DSNhanVien();
            if (dtgvNhanVien.Columns["Id"] != null)
            {
                dtgvNhanVien.Columns["Id"].Visible = false;
            }
        }

        private void btn_ThemNV_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtgvNhanVien.DataSource = NhanVienDAO_Mongo.DSNhanVienByName(richTextBox8.Text);
            if (dtgvNhanVien.Columns["Id"] != null)
            {
                dtgvNhanVien.Columns["Id"].Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                dtgvNhanVien.DataSource = NhanVienDAO_Mongo.DSNhanVienOrderByName();
                if (dtgvNhanVien.Columns["Id"] != null)
                {
                    dtgvNhanVien.Columns["Id"].Visible = false;
                }
            }
            else
            {
                dtgvNhanVien.DataSource = NhanVienDAO_Mongo.DSNhanVienOrderBySDT();
                if (dtgvNhanVien.Columns["Id"] != null)
                {
                    dtgvNhanVien.Columns["Id"].Visible = false;
                }
            }
        }
    }
}
