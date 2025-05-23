﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject_IS.DAOs;

namespace FinalProject_IS
{
    public partial class UC_Kho : UserControl
    {
        public UC_Kho()
        {
            InitializeComponent();
            LoadSP();
        }

        public void LoadSP()    
        {
            dtgvKhoSP.DataSource = SanPhamDAO_Mongo.DSSanPham();
            if (dtgvKhoSP.Columns["Id"] != null)
            {
                dtgvKhoSP.Columns["Id"].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtgvKhoSP.DataSource = SanPhamDAO_Mongo.DSSanPhamByName(richTextBox8.Text);
            if (dtgvKhoSP.Columns["Id"] != null)
            {
                dtgvKhoSP.Columns["Id"].Visible = false;
            }
        }
    }
}
