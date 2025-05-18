using System;
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
            dtgvTopSales.DataSource = null;
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();

            int month = dtpMonth.Value.Month;
            int year = dtpYear.Value.Year;

            if (loaitk == "doanhthu")
            {
                lb_TopSanPham.Text = "Sản phẩm bán chạy nhất";

                DsBanChay();

                lbThongKeThang.Text = "Doanh Thu Tháng";
                lbThongKeNam.Text = "Doanh Thu Năm";

                if (dtpMonth.Focused)
                {
                    LoadDoanhThuTheoThang(month, year);
                }
                else if (dtpYear.Focused)
                {
                    LoadDoanhThuTheoNam(year);
                }
                else
                {
                    LoadDoanhThuTheoThang(month, year);
                }
            }
            else
            {
                lb_TopSanPham.Text = "Sản phẩm lợi nhuận cao nhất";

                DsLoiNhuanCao();

                lbThongKeThang.Text = "Lợi Nhuận Tháng";
                lbThongKeNam.Text = "Lợi Nhuận Năm";

                if (dtpMonth.Focused)
                {
                    LoadLoiNhuanTheoThang(month, year);
                    lbThongKeNam.Text = "";
                }
                else if (dtpYear.Focused)
                {
                    LoadLoiNhuanTheoNam(year);
                    lbThongKeThang.Text = "";
                }
                else
                {
                    LoadLoiNhuanTheoThang(month, year);
                    lbThongKeNam.Text = "";
                }
            }
        }


        #region DoanhThu
        private void LoadDoanhThuTheoThang(int month, int year)
        {
            var data = ThongKeDAO.DSDoanhThuTheoThang(month, year);

            var series = new Series("Doanh thu theo ngày")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            foreach (var item in data)
                series.Points.AddXY($"{item.Ngay}/{month}", item.DoanhThu);

            chartDoanhThu.Series.Add(series);
            chartDoanhThu.Titles.Add($"Doanh thu tháng {month}/{year}");
        }

        private void LoadDoanhThuTheoNam(int year)
        {
            var data = ThongKeDAO.DSDoanhThuTheoNam(year);

            var series = new Series("Doanh thu theo tháng")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            foreach (var item in data)
                series.Points.AddXY($"{item.Thang}/{year}", item.DoanhThu);

            chartDoanhThu.Series.Add(series);
            chartDoanhThu.Titles.Add($"Doanh thu năm {year}");
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

            var series = new Series("Lợi nhuận theo ngày")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            foreach (var item in data)
                series.Points.AddXY($"{item.Ngay}/{month}", item.DoanhThu);

            chartDoanhThu.Series.Add(series);
            chartDoanhThu.Titles.Add($"Lợi nhuận tháng {month}/{year}");
        }

        private void LoadLoiNhuanTheoNam(int year)
        {
            var data = ThongKeDAO.DSLoiNhuanTheoNam(year);

            var series = new Series("Lợi nhuận theo tháng")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            foreach (var item in data)
                series.Points.AddXY($"{item.Thang}/{year}", item.DoanhThu);

            chartDoanhThu.Series.Add(series);
            chartDoanhThu.Titles.Add($"Lợi nhuận năm {year}");
        }
        #endregion

        #region ChucNang
        private void dtpMonth_ValueChanged(object sender, EventArgs e)
        {
            ReloadThongKe();
        }

        private void dtpYear_ValueChanged(object sender, EventArgs e)
        {
            ReloadThongKe();
        }

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
            ReloadThongKe();
        }
        #endregion
    }
}
