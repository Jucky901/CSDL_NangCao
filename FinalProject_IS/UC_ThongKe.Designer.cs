namespace FinalProject_IS
{
    partial class UC_ThongKe
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDoanhThu = new System.Windows.Forms.Button();
            this.btnLoiNhuan = new System.Windows.Forms.Button();
            this.lb_TopSanPham = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.lbThongKeNam = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbThongKeThang = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgvTopSales = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTopSales)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDoanhThu);
            this.panel1.Controls.Add(this.btnLoiNhuan);
            this.panel1.Controls.Add(this.lb_TopSanPham);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dtgvTopSales);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(16, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1150, 448);
            this.panel1.TabIndex = 10;
            // 
            // btnDoanhThu
            // 
            this.btnDoanhThu.Location = new System.Drawing.Point(1003, 27);
            this.btnDoanhThu.Name = "btnDoanhThu";
            this.btnDoanhThu.Size = new System.Drawing.Size(103, 41);
            this.btnDoanhThu.TabIndex = 24;
            this.btnDoanhThu.Text = "DoanhThu";
            this.btnDoanhThu.UseVisualStyleBackColor = true;
            this.btnDoanhThu.Click += new System.EventHandler(this.btnDoanhThu_Click);
            // 
            // btnLoiNhuan
            // 
            this.btnLoiNhuan.Location = new System.Drawing.Point(882, 27);
            this.btnLoiNhuan.Name = "btnLoiNhuan";
            this.btnLoiNhuan.Size = new System.Drawing.Size(103, 41);
            this.btnLoiNhuan.TabIndex = 23;
            this.btnLoiNhuan.Text = "Lợi Nhuận";
            this.btnLoiNhuan.UseVisualStyleBackColor = true;
            this.btnLoiNhuan.Click += new System.EventHandler(this.btnLoiNhuan_Click);
            // 
            // lb_TopSanPham
            // 
            this.lb_TopSanPham.AutoSize = true;
            this.lb_TopSanPham.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TopSanPham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_TopSanPham.Location = new System.Drawing.Point(13, 20);
            this.lb_TopSanPham.Margin = new System.Windows.Forms.Padding(0);
            this.lb_TopSanPham.Name = "lb_TopSanPham";
            this.lb_TopSanPham.Size = new System.Drawing.Size(303, 31);
            this.lb_TopSanPham.TabIndex = 22;
            this.lb_TopSanPham.Text = "Sản phẩm bán chạy nhất";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(482, 692);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(245, 16);
            this.label14.TabIndex = 21;
            this.label14.Text = "__________________________________";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.dtpYear);
            this.panel2.Controls.Add(this.dtpMonth);
            this.panel2.Controls.Add(this.lbThongKeNam);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.chartDoanhThu);
            this.panel2.Controls.Add(this.lbThongKeThang);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(19, 360);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1087, 329);
            this.panel2.TabIndex = 20;
            // 
            // dtpYear
            // 
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(804, 42);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.Size = new System.Drawing.Size(200, 22);
            this.dtpYear.TabIndex = 42;
            this.dtpYear.ValueChanged += new System.EventHandler(this.dtpYear_ValueChanged);
            // 
            // dtpMonth
            // 
            this.dtpMonth.CustomFormat = "MM/yyyy";
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(236, 42);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.Size = new System.Drawing.Size(200, 22);
            this.dtpMonth.TabIndex = 41;
            this.dtpMonth.ValueChanged += new System.EventHandler(this.dtpMonth_ValueChanged);
            // 
            // lbThongKeNam
            // 
            this.lbThongKeNam.AutoSize = true;
            this.lbThongKeNam.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongKeNam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbThongKeNam.Location = new System.Drawing.Point(583, 36);
            this.lbThongKeNam.Margin = new System.Windows.Forms.Padding(0);
            this.lbThongKeNam.Name = "lbThongKeNam";
            this.lbThongKeNam.Size = new System.Drawing.Size(196, 31);
            this.lbThongKeNam.TabIndex = 40;
            this.lbThongKeNam.Text = "Doanh thu năm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 420);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "_";
            // 
            // chartDoanhThu
            // 
            this.chartDoanhThu.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(21, 109);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Size = new System.Drawing.Size(1011, 300);
            this.chartDoanhThu.TabIndex = 38;
            this.chartDoanhThu.Text = "chart1";
            // 
            // lbThongKeThang
            // 
            this.lbThongKeThang.AutoSize = true;
            this.lbThongKeThang.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongKeThang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbThongKeThang.Location = new System.Drawing.Point(15, 36);
            this.lbThongKeThang.Margin = new System.Windows.Forms.Padding(0);
            this.lbThongKeThang.Name = "lbThongKeThang";
            this.lbThongKeThang.Size = new System.Drawing.Size(218, 31);
            this.lbThongKeThang.TabIndex = 36;
            this.lbThongKeThang.Text = "Doanh thu tháng ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(238)))), ((int)(((byte)(249)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1066, 24);
            this.panel3.TabIndex = 35;
            // 
            // dtgvTopSales
            // 
            this.dtgvTopSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvTopSales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgvTopSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTopSales.Location = new System.Drawing.Point(19, 74);
            this.dtgvTopSales.Name = "dtgvTopSales";
            this.dtgvTopSales.RowHeadersWidth = 51;
            this.dtgvTopSales.Size = new System.Drawing.Size(1087, 266);
            this.dtgvTopSales.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(30, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Phần mềm bán hàng VNBSports";
            // 
            // UC_ThongKe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "UC_ThongKe";
            this.Size = new System.Drawing.Size(1182, 513);
            this.Load += new System.EventHandler(this.UC_ThongKe_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTopSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgvTopSales;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_TopSanPham;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Label lbThongKeThang;
        private System.Windows.Forms.Label lbThongKeNam;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.Button btnDoanhThu;
        private System.Windows.Forms.Button btnLoiNhuan;
    }
}
