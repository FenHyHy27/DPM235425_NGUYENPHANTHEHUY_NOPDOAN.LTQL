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
    public class DocGia_DAO
    {
        public static List<DocGia_DTO> LayDanhSach()
        {
            SqlConnection conn = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(
                "SELECT * FROM dbo.DocGia", conn);
            DataProvider.DongKetNoi(conn);

            List<DocGia_DTO> lst = new List<DocGia_DTO>();
            foreach (DataRow row in dt.Rows)
            {
                lst.Add(new DocGia_DTO
                {
                    MaDocGia = int.Parse(row["MaDocGia"].ToString()),
                    HoTen = row["HoTen"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    NgayLapThe = row["NgayLapThe"] == DBNull.Value
                                  ? DateTime.Today
                                  : DateTime.Parse(row["NgayLapThe"].ToString())
                });
            }
            return lst;
        }

        public static DocGia_DTO TimTheoMa(int ma)
        {
            SqlConnection conn = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(
                string.Format("SELECT * FROM dbo.DocGia WHERE MaDocGia={0}", ma), conn);
            DataProvider.DongKetNoi(conn);

            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            return new DocGia_DTO
            {
                MaDocGia = int.Parse(row["MaDocGia"].ToString()),
                HoTen = row["HoTen"].ToString(),
                SoDienThoai = row["SoDienThoai"].ToString(),
                DiaChi = row["DiaChi"].ToString(),
                NgayLapThe = DateTime.Parse(row["NgayLapThe"].ToString())
            };
        }

        public static bool Them(DocGia_DTO dg)
        {
            string query = "INSERT INTO DocGia (HoTen, SoDienThoai, DiaChi, NgayLapThe) VALUES (@HoTen, @SoDienThoai, @DiaChi, @NgayLapThe)";

            SqlConnection conn = DataProvider.MoKetNoi();

            System.Data.SqlClient.SqlParameter[] param = {
                new System.Data.SqlClient.SqlParameter("@HoTen", dg.HoTen),
                new System.Data.SqlClient.SqlParameter("@SoDienThoai", dg.SoDienThoai),
                new System.Data.SqlClient.SqlParameter("@DiaChi", dg.DiaChi),
                new System.Data.SqlClient.SqlParameter("@NgayLapThe", dg.NgayLapThe.Date)
            };

            bool kq = DataProvider.TruyVanKhongLayDuLieuCoThamSo(query, conn, param);
            DataProvider.DongKetNoi(conn);
            return kq;
        }

        public static bool Sua(DocGia_DTO dg)
        {
            string sql = "UPDATE dbo.DocGia SET HoTen=@HoTen, SoDienThoai=@SoDienThoai, " +
                         "DiaChi=@DiaChi, NgayLapThe=@NgayLapThe WHERE MaDocGia=@MaDocGia";

            SqlConnection conn = DataProvider.MoKetNoi();
            SqlParameter[] parameters = {
                new SqlParameter("@MaDocGia", dg.MaDocGia),
                new SqlParameter("@HoTen", dg.HoTen),
                new SqlParameter("@SoDienThoai", dg.SoDienThoai),
                new SqlParameter("@DiaChi", dg.DiaChi),
                new SqlParameter("@NgayLapThe", dg.NgayLapThe.Date)
            };

            bool kq = DataProvider.TruyVanKhongLayDuLieuCoThamSo(sql, conn, parameters);
            DataProvider.DongKetNoi(conn);
            return kq;
        }

        public static bool Xoa(int ma)
        {
            string sql = "DELETE FROM dbo.DocGia WHERE MaDocGia=@MaDocGia";

            SqlConnection conn = DataProvider.MoKetNoi();
            SqlParameter[] parameters = {
                new SqlParameter("@MaDocGia", ma)
            };

            bool kq = DataProvider.TruyVanKhongLayDuLieuCoThamSo(sql, conn, parameters);
            DataProvider.DongKetNoi(conn);
            return kq;
        }

        public static List<DocGia_DTO> TimKiem(string tuKhoa)
        {
            string query =
                "SELECT * FROM dbo.DocGia " +
                "WHERE HoTen LIKE @TuKhoa " +
                "   OR SoDienThoai LIKE @TuKhoa " +
                "   OR DiaChi LIKE @TuKhoa";

            SqlParameter[] parameters = {
        new SqlParameter("@TuKhoa", "%" + tuKhoa + "%")
    };

            SqlConnection conn = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieuCoThamSo(query, conn, parameters);
            DataProvider.DongKetNoi(conn);

            List<DocGia_DTO> lst = new List<DocGia_DTO>();
            foreach (DataRow row in dt.Rows)
            {
                lst.Add(new DocGia_DTO
                {
                    MaDocGia = int.Parse(row["MaDocGia"].ToString()),
                    HoTen = row["HoTen"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    NgayLapThe = row["NgayLapThe"] == DBNull.Value
                                    ? DateTime.Today
                                    : DateTime.Parse(row["NgayLapThe"].ToString())
                });
            }
            return lst;
        }
    }
}
