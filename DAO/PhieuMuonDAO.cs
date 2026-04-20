using DataAccessLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PhieuMuonDAO
    {
        public List<PhieuMuonDTO> LayDanhSachPhieuMuon()
        {
            List<PhieuMuonDTO> danhSach = new List<PhieuMuonDTO>();

            SqlConnection conn = DataProvider.MoKetNoi();

            string query = @"SELECT p.MaPhieu, p.MaDocGia, d.HoTen AS TenDocGia,
                                    p.NgayMuon, p.NgayHenTra, p.TinhTrang
                             FROM PhieuMuon p
                             LEFT JOIN DocGia d ON p.MaDocGia = d.MaDocGia
                             ORDER BY p.MaPhieu DESC";

            DataTable dt = DataProvider.TruyVanLayDuLieu(query, conn);
            DataProvider.DongKetNoi(conn);

            foreach (DataRow row in dt.Rows)
            {
                PhieuMuonDTO pm = new PhieuMuonDTO();
                pm.MaPhieu = Convert.ToInt32(row["MaPhieu"]);
                pm.MaDocGia = Convert.ToInt32(row["MaDocGia"]);
                pm.TenDocGia = row["TenDocGia"].ToString();
                pm.NgayMuon = Convert.ToDateTime(row["NgayMuon"]);
                pm.NgayHenTra = Convert.ToDateTime(row["NgayHenTra"]);
                pm.TinhTrang = row["TinhTrang"].ToString();
                danhSach.Add(pm);
            }

            return danhSach;
        }

        public List<PhieuMuonDTO> TimKiemPhieuMuon(string tuKhoa)
        {
            List<PhieuMuonDTO> danhSach = new List<PhieuMuonDTO>();

            SqlConnection conn = DataProvider.MoKetNoi();

            string query = @"SELECT p.MaPhieu, p.MaDocGia, d.HoTen AS TenDocGia,
                                    p.NgayMuon, p.NgayHenTra, p.TinhTrang
                             FROM PhieuMuon p
                             LEFT JOIN DocGia d ON p.MaDocGia = d.MaDocGia
                             WHERE d.HoTen LIKE @TuKhoa
                                OR p.TinhTrang LIKE @TuKhoa
                                OR CAST(p.MaPhieu AS NVARCHAR) LIKE @TuKhoa
                             ORDER BY p.MaPhieu DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@TuKhoa", "%" + tuKhoa + "%")
            };

            DataTable dt = DataProvider.TruyVanLayDuLieuCoThamSo(query, conn, parameters);
            DataProvider.DongKetNoi(conn);

            foreach (DataRow row in dt.Rows)
            {
                PhieuMuonDTO pm = new PhieuMuonDTO();
                pm.MaPhieu = Convert.ToInt32(row["MaPhieu"]);
                pm.MaDocGia = Convert.ToInt32(row["MaDocGia"]);
                pm.TenDocGia = row["TenDocGia"].ToString();
                pm.NgayMuon = Convert.ToDateTime(row["NgayMuon"]);
                pm.NgayHenTra = Convert.ToDateTime(row["NgayHenTra"]);
                pm.TinhTrang = row["TinhTrang"].ToString();
                danhSach.Add(pm);
            }

            return danhSach;
        }

        public int TimMaDocGiaTheoTen(string tenDocGia)
        {
            SqlConnection conn = DataProvider.MoKetNoi();

            string query = "SELECT MaDocGia FROM DocGia WHERE HoTen = @TenDocGia";

            SqlParameter[] parameters = {
                new SqlParameter("@TenDocGia", tenDocGia.Trim())
            };

            object result = DataProvider.TruyVanLayMotGiaTri(query, conn, parameters);
            DataProvider.DongKetNoi(conn);

            if (result != null && result != DBNull.Value)
                return Convert.ToInt32(result);

            return -1; // không tìm thấy đọc giả 
        }

        public List<DocGia_DTO> LayDanhSachDocGia()
        {
            List<DocGia_DTO> danhSach = new List<DocGia_DTO>();

            SqlConnection conn = DataProvider.MoKetNoi();

            string query = "SELECT MaDocGia, HoTen FROM DocGia ORDER BY HoTen";
            DataTable dt = DataProvider.TruyVanLayDuLieu(query, conn);
            DataProvider.DongKetNoi(conn);

            foreach (DataRow row in dt.Rows)
            {
                DocGia_DTO dg = new DocGia_DTO();
                dg.MaDocGia = Convert.ToInt32(row["MaDocGia"]);
                dg.HoTen = row["HoTen"].ToString();
                danhSach.Add(dg);
            }

            return danhSach;
        }

        public int ThemPhieuMuon(PhieuMuonDTO pm)
        {
            SqlConnection conn = DataProvider.MoKetNoi();

            string query = @"INSERT INTO PhieuMuon (MaDocGia, NgayMuon, NgayHenTra, TinhTrang)
                             VALUES (@MaDocGia, @NgayMuon, @NgayHenTra, @TinhTrang);
                             SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = {
                new SqlParameter("@MaDocGia",   pm.MaDocGia),
                new SqlParameter("@NgayMuon",   pm.NgayMuon),
                new SqlParameter("@NgayHenTra", pm.NgayHenTra),
                new SqlParameter("@TinhTrang",  pm.TinhTrang)
            };

            object result = DataProvider.TruyVanLayMotGiaTri(query, conn, parameters);
            DataProvider.DongKetNoi(conn);

            if (result != null && result != DBNull.Value)
                return Convert.ToInt32(result);

            return -1;
        }

        public bool SuaPhieuMuon(PhieuMuonDTO pm)
        {
            SqlConnection conn = DataProvider.MoKetNoi();

            string query = @"UPDATE PhieuMuon
                             SET MaDocGia   = @MaDocGia,
                                 NgayMuon   = @NgayMuon,
                                 NgayHenTra = @NgayHenTra,
                                 TinhTrang  = @TinhTrang
                             WHERE MaPhieu = @MaPhieu";

            SqlParameter[] parameters = {
                new SqlParameter("@MaPhieu",    pm.MaPhieu),
                new SqlParameter("@MaDocGia",   pm.MaDocGia),
                new SqlParameter("@NgayMuon",   pm.NgayMuon),
                new SqlParameter("@NgayHenTra", pm.NgayHenTra),
                new SqlParameter("@TinhTrang",  pm.TinhTrang)
            };

            bool kq = DataProvider.TruyVanKhongLayDuLieuCoThamSo(query, conn, parameters);
            DataProvider.DongKetNoi(conn);
            return kq;
        }

        public bool XoaPhieuMuon(int maPhieu)
        {
            SqlConnection conn = DataProvider.MoKetNoi();

            string queryChiTiet = "DELETE FROM ChiTietPhieuMuon WHERE MaPhieu = @MaPhieu";
            SqlParameter[] paramsChiTiet = {
                new SqlParameter("@MaPhieu", maPhieu)
            };
            DataProvider.TruyVanKhongLayDuLieuCoThamSo(queryChiTiet, conn, paramsChiTiet);

            string query = "DELETE FROM PhieuMuon WHERE MaPhieu = @MaPhieu";
            SqlParameter[] parameters = {
                new SqlParameter("@MaPhieu", maPhieu)
            };
            bool kq = DataProvider.TruyVanKhongLayDuLieuCoThamSo(query, conn, parameters);
            DataProvider.DongKetNoi(conn);
            return kq;
        }
    }
}
