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
    public class TaiKhoan_DAO
    {
        public static TaiKhoan_DTO KiemTraDangNhap(string user, string pass)
        {
            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @user AND MatKhau = @pass";
            SqlConnection conn = DataProvider.MoKetNoi();
            SqlParameter[] param = {
                new SqlParameter("@user", user),
                new SqlParameter("@pass", pass)
            };

            DataTable dt = DataProvider.TruyVanLayDuLieuCoThamSo(query, conn, param);
            DataProvider.DongKetNoi(conn);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new TaiKhoan_DTO
                {
                    TenDangNhap = dr["TenDangNhap"].ToString(),
                    HoTen = dr["HoTen"].ToString(),
                    Quyen = dr["Quyen"].ToString()
                };
            }
            return null;
        }
    }
}
