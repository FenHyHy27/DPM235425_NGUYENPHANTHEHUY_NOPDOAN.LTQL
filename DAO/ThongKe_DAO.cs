using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ThongKe_DAO
    {

        public static int TongSoSach()
        {
            string query = "SELECT ISNULL(SUM(SoLuong), 0) FROM Sach";
            SqlConnection conn = DataProvider.MoKetNoi();
            object result = DataProvider.TruyVanLayMotGiaTri(query, conn, null);
            DataProvider.DongKetNoi(conn);
            return Convert.ToInt32(result);
        }

        public static int TongSachDangMuon()
        {
            string query = "SELECT COUNT(*) FROM ChiTietPhieuMuon WHERE NgayTraThucTe IS NULL";
            SqlConnection conn = DataProvider.MoKetNoi();
            object result = DataProvider.TruyVanLayMotGiaTri(query, conn, null);
            DataProvider.DongKetNoi(conn);
            return Convert.ToInt32(result);
        }

        public static int TongDocGiaTreHan()
        {
            string query = @"SELECT COUNT(DISTINCT p.MaDocGia) 
                             FROM PhieuMuon p 
                             JOIN ChiTietPhieuMuon ct ON p.MaPhieu = ct.MaPhieu 
                             WHERE p.NgayHenTra < CAST(GETDATE() AS DATE) 
                             AND ct.NgayTraThucTe IS NULL";
            SqlConnection conn = DataProvider.MoKetNoi();
            object result = DataProvider.TruyVanLayMotGiaTri(query, conn, null);
            DataProvider.DongKetNoi(conn);
            return Convert.ToInt32(result);
        }

        public static DataTable DanhSachSachDangMuon()
        {
            string query = @"SELECT 
                                s.MaSach          AS [Mã sách],
                                s.TenSach         AS [Tên sách],
                                s.TacGia          AS [Tác giả],
                                dg.HoTen          AS [Độc giả mượn],
                                p.NgayMuon        AS [Ngày mượn],
                                p.NgayHenTra      AS [Hạn trả]
                             FROM ChiTietPhieuMuon ct
                             JOIN Sach s ON ct.MaSach = s.MaSach
                             JOIN PhieuMuon p ON ct.MaPhieu = p.MaPhieu
                             JOIN DocGia dg ON p.MaDocGia = dg.MaDocGia
                             WHERE ct.NgayTraThucTe IS NULL
                             ORDER BY p.NgayMuon DESC";
            SqlConnection conn = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(query, conn);
            DataProvider.DongKetNoi(conn);
            return dt;
        }

        public static DataTable DanhSachDocGiaTreHan()
        {
            string query = @"SELECT 
                                dg.MaDocGia       AS [Mã độc giả],
                                dg.HoTen          AS [Họ tên],
                                dg.SoDienThoai    AS [Số điện thoại],
                                s.TenSach         AS [Sách đang mượn],
                                p.NgayHenTra      AS [Hạn trả],
                                DATEDIFF(DAY, p.NgayHenTra, CAST(GETDATE() AS DATE)) AS [Số ngày trễ]
                             FROM PhieuMuon p
                             JOIN ChiTietPhieuMuon ct ON p.MaPhieu = ct.MaPhieu
                             JOIN DocGia dg ON p.MaDocGia = dg.MaDocGia
                             JOIN Sach s ON ct.MaSach = s.MaSach
                             WHERE p.NgayHenTra < CAST(GETDATE() AS DATE)
                               AND ct.NgayTraThucTe IS NULL
                             ORDER BY p.NgayHenTra ASC";
            SqlConnection conn = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(query, conn);
            DataProvider.DongKetNoi(conn);
            return dt;
        }
    }
}
