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
using MongoDB.Bson;
using MongoDB.Driver;

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
            LoadDoanhThuTheoThang(month, year);
        }
        #region DoanhThu
        private void LoadDoanhThuTheoThang(int month, int year)
        {
            try
            {
                var hoaDonSanPhamCol = MongoConnection.Database.GetCollection<BsonDocument>("HoaDonSanPham");

                DateTime startDate = new DateTime(year, month, 1);
                DateTime endDate = startDate.AddMonths(1);

                // Lọc hóa đơn theo tháng
                var filter = Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Gte("NgayGioTao", startDate),
                    Builders<BsonDocument>.Filter.Lt("NgayGioTao", endDate)
                );

                var hoaDonDocs = hoaDonSanPhamCol.Find(filter).ToList();

                var doanhThuTheoNgay = new Dictionary<int, decimal>();

                foreach (var doc in hoaDonDocs)
                {
                    if (doc.Contains("NgayGioTao") && doc.Contains("SanPham"))
                    {
                        DateTime ngay = doc["NgayGioTao"].ToLocalTime();
                        int day = ngay.Day;

                        decimal tongTien = 0;
                        var sanPhamArray = doc["SanPham"].AsBsonArray;

                        foreach (var sp in sanPhamArray)
                        {
                            var spDoc = sp.AsBsonDocument;
                            int soLuong = spDoc.Contains("SoLuong") ? spDoc["SoLuong"].ToInt32() : 0;
                            decimal donGia = spDoc.Contains("DonGia") ? spDoc["DonGia"].ToDecimal() : 0;
                            tongTien += soLuong * donGia;
                        }

                        if (!doanhThuTheoNgay.ContainsKey(day))
                            doanhThuTheoNgay[day] = 0;
                        doanhThuTheoNgay[day] += tongTien;
                    }
                }

                // Hiển thị biểu đồ
                chartDoanhThu.Series.Clear();
                chartDoanhThu.Titles.Clear();
                chartDoanhThu.Titles.Add($"Doanh thu tháng {month}/{year}");

                Series series = new Series("Doanh thu theo ngày")
                {
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };

                foreach (var kvp in doanhThuTheoNgay.OrderBy(k => k.Key))
                {
                    series.Points.AddXY($"{kvp.Key}/{month}", kvp.Value);
                }

                chartDoanhThu.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải doanh thu: " + ex.Message);
            }

        }

        private void LoadDoanhThuTheoNam(int year)
        {
            try
            {
                var hoaDonCol = MongoConnection.Database.GetCollection<BsonDocument>("HoaDonSanPham");

                DateTime startDate = new DateTime(year, 1, 1);
                DateTime endDate = startDate.AddYears(1);

                var filter = Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Gte("NgayGioTao", startDate),
                    Builders<BsonDocument>.Filter.Lt("NgayGioTao", endDate)
                );

                var hoaDonDocs = hoaDonCol.Find(filter).ToList();

                // Dictionary lưu doanh thu theo tháng
                var doanhThuTheoThang = new Dictionary<int, decimal>();

                foreach (var doc in hoaDonDocs)
                {
                    if (doc.Contains("NgayGioTao") && doc.Contains("SanPham"))
                    {
                        DateTime ngay = doc["NgayGioTao"].ToLocalTime();
                        int month = ngay.Month;

                        decimal tongTien = 0;
                        var sanPhamArray = doc["SanPham"].AsBsonArray;

                        foreach (var sp in sanPhamArray)
                        {
                            var spDoc = sp.AsBsonDocument;
                            int soLuong = spDoc.GetValue("SoLuong", 0).ToInt32();
                            decimal donGia = spDoc.GetValue("DonGia", 0).ToDecimal();
                            tongTien += soLuong * donGia;
                        }

                        if (!doanhThuTheoThang.ContainsKey(month))
                            doanhThuTheoThang[month] = 0;
                        doanhThuTheoThang[month] += tongTien;
                    }
                }

                // Vẽ biểu đồ
                chartDoanhThu.Series.Clear();
                chartDoanhThu.Titles.Clear();
                chartDoanhThu.Titles.Add($"Doanh thu năm {year}");

                Series series = new Series("Doanh thu theo tháng")
                {
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };

                foreach (var kvp in doanhThuTheoThang.OrderBy(k => k.Key))
                {
                    series.Points.AddXY($"{kvp.Key}/{year}", kvp.Value);
                }

                chartDoanhThu.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải doanh thu theo năm: " + ex.Message);
            }
        }

        private void DsBanChay()
        {
            try
            {
                var collection = MongoConnection.Database.GetCollection<BsonDocument>("HoaDonSanPham");

                var pipeline = new[]
                {
                    new BsonDocument("$unwind", "$SanPham"),
                    new BsonDocument("$group", new BsonDocument
                    {
                        { "_id", new BsonDocument {
                            { "MaSP", "$SanPham.MaSP" },
                            { "TenSP", "$SanPham.TenSP" }
                        }},
                        { "DoanhSo", new BsonDocument("$sum", "$SanPham.SoLuong") },
                        { "DoanhThu", new BsonDocument("$sum", new BsonDocument("$multiply", new BsonArray { "$SanPham.SoLuong", "$SanPham.DonGia" })) }
                    }),
                    new BsonDocument("$sort", new BsonDocument("DoanhSo", -1)),
                    new BsonDocument("$limit", 10)
                };

                var result = collection.Aggregate<BsonDocument>(pipeline).ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("MaSP", typeof(int));
                dt.Columns.Add("TenSP", typeof(string));
                dt.Columns.Add("DoanhSo", typeof(int));
                dt.Columns.Add("DoanhThu", typeof(decimal));

                foreach (var doc in result)
                {
                    var id = doc["_id"].AsBsonDocument;
                    int maSP = id["MaSP"].AsInt32;
                    string tenSP = id["TenSP"].AsString;
                    int doanhSo = doc["DoanhSo"].AsInt32;
                    decimal doanhThu = doc["DoanhThu"].ToDecimal();

                    dt.Rows.Add(maSP, tenSP, doanhSo, doanhThu);
                }

                dtgvTopSales.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải top sản phẩm: " + ex.Message);
            }
        }
        #endregion

        #region LoiNhuan
        public void DsLoiNhuanCao()
        {
            try
            {
                string query = @"
                            WITH GiaNhapTrungBinhCTE AS (
                                SELECT 
                                    MaSP,
                                    SoLuongNhap,
                                    DonGiaNhap
                                FROM ChiTietPhieuNhan
                                GROUP BY MaSP, SoLuongNhap, DonGiaNhap
                            )
                            SELECT TOP 10 
                                sp.MaSP,
                                sp.TenSP,
                                SUM(ct.SoLuongSP) AS DoanhSo,
                                SUM(ct.ThanhTien) AS DoanhThu,
                                ISNULL(gntb.DonGiaNhap, 0) as GiaTriNhap,
                                SUM(ct.ThanhTien) - SUM(gntb.SoLuongNhap * ISNULL(gntb.DonGiaNhap, 0)) AS LoiNhuan
                            FROM ChiTietHD_SanPham ct
                            JOIN SanPham sp ON ct.MaSP = sp.MaSP
                            LEFT JOIN GiaNhapTrungBinhCTE gntb ON ct.MaSP = gntb.MaSP
                            GROUP BY sp.MaSP, sp.TenSP, gntb.DonGiaNhap
                            ORDER BY LoiNhuan DESC;";

                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }

                dtgvTopSales.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadLoiNhuanTheoThang(int month, int year)
        {
            try
            {
                string query = @"
                                WITH ThongTinNhap AS (
                                    SELECT 
                                        MaSP,
                                        NgayNhan,
                                        SUM(SoLuongNhap * DonGiaNhap) * 1.0 / NULLIF(SUM(SoLuongNhap), 0) as GiaNhap
                                    FROM ChiTietPhieuNhan
                                    GROUP BY MaSP, NgayNhan
                                ),
                                LoiNhuanSanPham AS (
                                    SELECT 
                                        CAST(hd.NgayGioTao AS DATE) AS Ngay,
                                        SUM(ct.SoLuongSP * (ct.DonGia - ISNULL(ttn.GiaNhap, 0))) AS LoiNhuan
                                    FROM HoaDon hd
                                    JOIN ChiTietHD_SanPham ct ON hd.MaHD = ct.MaHD
                                    LEFT JOIN ThongtinNhap ttn ON ct.MaSP = ttn.MaSP
                                    WHERE MONTH(hd.NgayGioTao) = @Month AND YEAR(hd.NgayGioTao) = @Year
                                    GROUP BY CAST(hd.NgayGioTao AS DATE)
                                ),
                                LoiNhuanDichVu AS (
                                    SELECT 
                                        CAST(NgayGioTao AS DATE) AS Ngay,
                                        SUM(ThanhTien) AS LoiNhuan
                                    FROM HoaDonDichVu
                                    WHERE MONTH(NgayGioTao) = @Month AND YEAR(NgayGioTao) = @Year AND LoaiPhieu = 'DV'
                                    GROUP BY CAST(NgayGioTao AS DATE)
                                )
                                SELECT 
                                    DAY(Ngay) AS Ngay,
                                    SUM(LoiNhuan) AS LoiNhuan
                                FROM (
                                    SELECT * FROM LoiNhuanSanPham
                                    UNION ALL
                                    SELECT * FROM LoiNhuanDichVu
                                ) AS TongHop
                                GROUP BY DAY(Ngay)
                                ORDER BY Ngay;";

                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Month", month);
                        cmd.Parameters.AddWithValue("@Year", year);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }

                chartDoanhThu.Series.Clear();
                chartDoanhThu.Titles.Clear(); // Clear tiêu đề cũ
                chartDoanhThu.Titles.Add($"Lợi nhuận tháng {month}/{year}");
                Series series = new Series("Lợi nhuận theo ngày")
                {
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };

                foreach (DataRow row in dt.Rows)
                {
                    int ngay = Convert.ToInt32(row["Ngay"]);
                    decimal loinhuan = row["LoiNhuan"] != DBNull.Value ? Convert.ToDecimal(row["LoiNhuan"]) : 0;
                    series.Points.AddXY(ngay + "/" + month, loinhuan);
                }

                chartDoanhThu.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadLoiNhuanTheoNam(int year)
        {
            try
            {
                string query = @"
                                WITH ThongTinNhap AS (
                                    SELECT 
                                        MaSP,
                                        NgayNhan,
                                        SUM(SoLuongNhap * DonGiaNhap) * 1.0 / NULLIF(SUM(SoLuongNhap), 0) as GiaNhap
                                    FROM ChiTietPhieuNhan
                                    GROUP BY MaSP, NgayNhan
                                ),
                                LoiNhuanSanPham AS (
                                    SELECT 
                                        CAST(hd.NgayGioTao AS DATE) AS Ngay,
                                        SUM(ct.SoLuongSP * (ct.DonGia - ISNULL(ttn.GiaNhap, 0))) AS LoiNhuan
                                    FROM HoaDon hd
                                    JOIN ChiTietHD_SanPham ct ON hd.MaHD = ct.MaHD
                                    LEFT JOIN ThongTinNhap ttn ON ct.MaSP = ttn.MaSP
                                    WHERE YEAR(hd.NgayGioTao) = @Year
                                    GROUP BY CAST(hd.NgayGioTao AS DATE)
                                ),
                                LoiNhuanDichVu AS (
                                    SELECT 
                                        CAST(NgayGioTao AS DATE) AS Ngay,
                                        SUM(ThanhTien) AS LoiNhuan
                                    FROM HoaDonDichVu
                                    WHERE YEAR(NgayGioTao) = @Year AND LoaiPhieu = 'DV'
                                    GROUP BY CAST(NgayGioTao AS DATE)
                                )
                                SELECT 
                                    MONTH(Ngay) AS Thang,
                                    SUM(LoiNhuan) AS LoiNhuan
                                FROM (
                                    SELECT * FROM LoiNhuanSanPham
                                    UNION ALL
                                    SELECT * FROM LoiNhuanDichVu
                                ) AS TongHop
                                GROUP BY MONTH(Ngay)
                                ORDER BY Thang";

            
                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Year", year);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }

                chartDoanhThu.Series.Clear();
                chartDoanhThu.Titles.Clear(); // Clear tiêu đề cũ
                chartDoanhThu.Titles.Add($"Lợi nhuận năm {year}");
                Series series = new Series("Lợi nhuận theo tháng")
                {
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true
                };

                foreach (DataRow row in dt.Rows)
                {
                    int thang = Convert.ToInt32(row["Thang"]);
                    decimal loinhuan = row["LoiNhuan"] != DBNull.Value ? Convert.ToDecimal(row["LoiNhuan"]) : 0;
                    series.Points.AddXY(thang + "/" + year, loinhuan);
                }

                chartDoanhThu.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        private void ReloadThongKe()
        {
            dtgvTopSales.DataSource = null;
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();
            UC_ThongKe_Load(this, EventArgs.Empty);
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
