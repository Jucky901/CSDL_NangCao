﻿using System;
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
    public partial class UC_KhachHang : UserControl
    {
        public UC_KhachHang()
        {
            InitializeComponent();
            LoadDsKhachHang();
        }

        public void LoadDsKhachHang()
        {
            dtgvKhachHang.DataSource = KhachHangDAO_Mongo.DSKhachHang();
            if (dtgvKhachHang.Columns["Id"] != null)
            {
                dtgvKhachHang.Columns["Id"].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtgvKhachHang.DataSource = KhachHangDAO_Mongo.DSKhachHangBySDT(richTextBox8.Text);
            if (dtgvKhachHang.Columns["Id"] != null)
            {
                dtgvKhachHang.Columns["Id"].Visible = false;
            }
        }
    }
}
