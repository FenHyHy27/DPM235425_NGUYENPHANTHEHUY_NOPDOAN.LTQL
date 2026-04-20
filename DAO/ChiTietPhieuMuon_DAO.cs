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
    public class ChiTietPhieuMuon_DAO
    {
        public static List<ChiTietPhieuMuon_DTO> LayDanhSachTheoMaPhieu(int maPhieu)
        {
            List<ChiTietPhieuMuon_DTO> lst = new List<ChiTietPhieuMuon_DTO>();

            string query = @"SELECT ct.MaPhieu, ct.MaSach, s.TenSach, ct.NgayTraThucTe, ct.TienPhat 
                             FROM ChiTietPhieuMuon ct 
                             JOIN Sach s ON ct.MaSach = s.MaSach 
                             WHERE ct.MaPhieu = @MaPhieu";

            SqlConnection conn = DataProvider.MoKetNoi();
            SqlParameter[] param = { new SqlParameter("@MaPhieu", maPhieu) };
            DataTable dt = DataProvider.TruyVanLayDuLieuCoThamSo(query, conn, param);
            DataProvider.DongKetNoi(conn);

            foreach (DataRow row in dt.Rows)
            {
                ChiTietPhieuMuon_DTO ct = new ChiTietPhieuMuon_DTO();
                ct.MaPhieu = Convert.ToInt32(row["MaPhieu"]);
                ct.MaSach = Convert.ToInt32(row["MaSach"]);
                ct.TenSach = row["TenSach"].ToString();

                if (row["NgayTraThucTe"] != DBNull.Value)
                    ct.NgayTraThucTe = Convert.ToDateTime(row["NgayTraThucTe"]);
                else
                    ct.NgayTraThucTe = null;

                ct.TienPhat = Convert.ToDecimal(row["TienPhat"]);
                lst.Add(ct);
            }
            return lst;
        }

        public static bool Them(ChiTietPhieuMuon_DTO ct)
        {
            string query = "INSERT INTO ChiTietPhieuMuon (MaPhieu, MaSach, TienPhat) VALUES (@MaPhieu, @MaSach, 0)";
            SqlConnection conn = DataProvider.MoKetNoi();
            SqlParameter[] param = {
                new SqlParameter("@MaPhieu", ct.MaPhieu),
                new SqlParameter("@MaSach", ct.MaSach)
            };

            bool kq = DataProvider.TruyVanKhongLayDuLieuCoThamSo(query, conn, param);
            DataProvider.DongKetNoi(conn);
            return kq;
        }

        public static bool Xoa(int maPhieu, int maSach)
        {
            string query = "DELETE FROM ChiTietPhieuMuon WHERE MaPhieu = @MaPhieu AND MaSach = @MaSach";
            SqlConnection conn = DataProvider.MoKetNoi();
            SqlParameter[] param = {
                new SqlParameter("@MaPhieu", maPhieu),
                new SqlParameter("@MaSach", maSach)
            };

            bool kq = DataProvider.TruyVanKhongLayDuLieuCoThamSo(query, conn, param);
            DataProvider.DongKetNoi(conn);
            return kq;
        }

        public static bool CapNhatTraSach(int maPhieu, int maSach, DateTime ngayTra, decimal tienPhat)
        {
            string query = "UPDATE ChiTietPhieuMuon SET NgayTraThucTe = @NgayTra, TienPhat = @TienPhat WHERE MaPhieu = @MaPhieu AND MaSach = @MaSach";

            SqlConnection conn = DataAccessLayer.DataProvider.MoKetNoi();
            System.Data.SqlClient.SqlParameter[] param = {
            new System.Data.SqlClient.SqlParameter("@MaPhieu", maPhieu),
            new System.Data.SqlClient.SqlParameter("@MaSach", maSach),
            new System.Data.SqlClient.SqlParameter("@NgayTra", ngayTra.Date),
            new System.Data.SqlClient.SqlParameter("@TienPhat", tienPhat)
            };

            bool kq = DataAccessLayer.DataProvider.TruyVanKhongLayDuLieuCoThamSo(query, conn, param);
            DataAccessLayer.DataProvider.DongKetNoi(conn);
            return kq;
        }
    }
}
