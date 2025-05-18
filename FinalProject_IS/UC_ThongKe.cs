using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FinalProject_IS.DAOs;

namespace FinalProject_IS
{
    public partial class UC_ThongKe : UserControl
    {
        public string loaitk = "doanhthu";
        public UC_ThongKe()
        {
            InitializeComponent();
            int month = dtpMonth.Value.Month;
            int year = dtpMonth.Value.Year;
            DsLoiNhuanCao();
            HookupEvents();
            LoadDoanhThuTheoThang(month, year);
        }
        private void HookupEvents()
        {
            dtpMonth.ValueChanged += (s, e) => ReloadThongKe();
            dtpYear.ValueChanged += (s, e) => ReloadThongKe();
            btnDoanhThu.Click += (s, e) => { loaitk = "doanhthu"; ReloadThongKe(); };
            btnLoiNhuan.Click += (s, e) => { loaitk = "loinhuan"; ReloadThongKe(); };
        }

        private void ReloadThongKe()
        {
            int month = dtpMonth.Value.Month;
            int year = dtpYear.Value.Year;

            dtgvTopSales.DataSource = null;
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();

            if (loaitk == "doanhthu")
            {
                lb_TopSanPham.Text = "Sản phẩm bán chạy nhất";
                lbThongKeThang.Text = "Doanh Thu Tháng";
                lbThongKeNam.Text = "Doanh Thu Năm";

                DsBanChay();
                LoadDoanhThuTheoThang(month, year);
                LoadDoanhThuTheoNam(year);
            }
            else
            {
                lb_TopSanPham.Text = "Sản phẩm lợi nhuận cao nhất";
                lbThongKeThang.Text = "Lợi Nhuận Tháng";
                lbThongKeNam.Text = "Lợi Nhuận Năm";

                DsLoiNhuanCao();
                LoadLoiNhuanTheoThang(month, year);
                LoadLoiNhuanTheoNam(year);
            }
        }

        #region DoanhThu
        private void LoadDoanhThuTheoThang(int month, int year)
        {
            var data = ThongKeDAO.DSDoanhThuTheoThang(month, year);
            chartDoanhThu.Titles.Add($"Doanh thu tháng {month}/{year}");
            var series = new Series("Doanh thu theo ngày")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };
            foreach (var item in data)
                series.Points.AddXY($"{item.Ngay}/{month}", item.DoanhThu);
            chartDoanhThu.Series.Add(series);
        }

        private void LoadDoanhThuTheoNam(int year)
        {
            var data = ThongKeDAO.DSDoanhThuTheoNam(year);
            chartDoanhThu.Titles.Add($"Doanh thu năm {year}");
            var series = new Series("Doanh thu theo tháng")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };
            foreach (var item in data)
                series.Points.AddXY($"{item.Thang}/{year}", item.DoanhThu);
            chartDoanhThu.Series.Add(series);
        }

        private void DsBanChay()
        {
            var list = ThongKeDAO.DSTopBanChay();
            dtgvTopSales.DataSource = list;
        }
        #endregion

        #region LoiNhuan
        public void DsLoiNhuanCao()
        {
            var list = ThongKeDAO.DSLoiNhuanCao();
            dtgvTopSales.DataSource = list;
        }

        private void LoadLoiNhuanTheoThang(int month, int year)
        {
            var data = ThongKeDAO.DSLoiNhuanTheoThang(month, year);
            chartDoanhThu.Titles.Add($"Lợi nhuận tháng {month}/{year}");
            var series = new Series("Lợi nhuận theo ngày")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };
            foreach (var item in data)
                series.Points.AddXY($"{item.Ngay}/{month}", item.DoanhThu);
            chartDoanhThu.Series.Add(series);
        }

        private void LoadLoiNhuanTheoNam(int year)
        {
            var data = ThongKeDAO.DSLoiNhuanTheoNam(year);
            chartDoanhThu.Titles.Add($"Lợi nhuận năm {year}");
            var series = new Series("Lợi nhuận theo tháng")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };
            foreach (var item in data)
                series.Points.AddXY($"{item.Thang}/{year}", item.DoanhThu);
            chartDoanhThu.Series.Add(series);
        }
        #endregion

        #region ChucNang
        private void dtpMonth_ValueChanged(object sender, EventArgs e)
        {
            int month = dtpMonth.Value.Month;
            int year = dtpMonth.Value.Year;
            if (loaitk == "doanhthu")
            {
                LoadDoanhThuTheoThang(month, year);
            }
            else
            {
                LoadLoiNhuanTheoThang(month, year);
            }
        }

        private void dtpYear_ValueChanged(object sender, EventArgs e)
        {
            int year = dtpYear.Value.Year;
            if (loaitk == "doanhthu")
            {
                LoadDoanhThuTheoNam(year);
            }
            else
            {
                LoadLoiNhuanTheoNam(year);
            }
        }
        //private void ReloadThongKe()
        //{
        //    dtgvTopSales.DataSource = null;
        //    chartDoanhThu.Series.Clear();
        //    chartDoanhThu.Titles.Clear();
        //    UC_ThongKe_Load(this, EventArgs.Empty);
        //}
        private void btnLoiNhuan_Click(object sender, EventArgs e)
        {
            loaitk = "loinhuan";
            ReloadThongKe();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            loaitk = "doanhthu";
            ReloadThongKe();
        }

        private void UC_ThongKe_Load(object sender, EventArgs e)
        {
            int month = dtpMonth.Value.Month;
            int year = dtpMonth.Value.Year;
            if (loaitk == "doanhthu")
            {
                lb_TopSanPham.Text = "Sản phẩm bán chạy nhất";
                lbThongKeThang.Text = "Doanh Thu Tháng";
                lbThongKeNam.Text = "Doanh Thu Năm";
                DsBanChay();
                LoadDoanhThuTheoThang(month, year);
            }
            else if (loaitk == "loinhuan")
            {
                lb_TopSanPham.Text = "Sản phẩm có lợi nhuận cao nhất";
                lbThongKeThang.Text = "Lợi Nhuận Tháng";
                lbThongKeNam.Text = "Lợi Nhuận Năm";
                DsLoiNhuanCao();
                LoadLoiNhuanTheoThang(month, year);
            }
        }
        #endregion
    }
}
