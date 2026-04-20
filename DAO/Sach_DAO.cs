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
    public class Sach_DAO
    {
        public static List<Sach_DTO> LayDanhSach()
        {
            try
            {
                SqlConnection conn = DataProvider.MoKetNoi();
                string query = @"SELECT s.MaSach, s.TenSach, s.TacGia, s.MaTheLoai, tl.TenTheLoai, s.SoLuong, s.NamXuatBan 
                         FROM Sach s 
                         JOIN TheLoai tl ON s.MaTheLoai = tl.MaTheLoai";

                DataTable dt = DataProvider.TruyVanLayDuLieu(query, conn);
                DataProvider.DongKetNoi(conn);

                List<Sach_DTO> lst = new List<Sach_DTO>();
                foreach (DataRow row in dt.Rows)
                {
                    lst.Add(new Sach_DTO
                    {
                        MaSach = int.Parse(row["MaSach"].ToString()),
                        TenSach = row["TenSach"].ToString(),
                        TacGia = row["TacGia"].ToString(),
                        MaTheLoai = int.Parse(row["MaTheLoai"].ToString()),
                        TenTheLoai = row["TenTheLoai"].ToString(),
                        SoLuong = int.Parse(row["SoLuong"].ToString()),
                        NamXuatBan = int.Parse(row["NamXuatBan"].ToString())
                    });
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Them(Sach_DTO s)
        {
            string sql = "INSERT INTO Sach(TenSach, TacGia, MaTheLoai, SoLuong, NamXuatBan) " +
                         "VALUES(@TenSach, @TacGia, @MaTheLoai, @SoLuong, @NamXuatBan)";

            SqlConnection conn = DataProvider.MoKetNoi();
            SqlParameter[] parameters = {
                new SqlParameter("@TenSach", s.TenSach),
                new SqlParameter("@TacGia", s.TacGia),
                new SqlParameter("@MaTheLoai", s.MaTheLoai),
                new SqlParameter("@SoLuong", s.SoLuong),
                new SqlParameter("@NamXuatBan", s.NamXuatBan)
            };

            bool kq = DataProvider.TruyVanKhongLayDuLieuCoThamSo(sql, conn, parameters);
            DataProvider.DongKetNoi(conn);
            return kq;
        }

        public static bool Sua(Sach_DTO s)
        {
            string sql = "UPDATE Sach SET TenSach=@TenSach, TacGia=@TacGia, " +
                         "MaTheLoai=@MaTheLoai, SoLuong=@SoLuong, NamXuatBan=@NamXuatBan " +
                         "WHERE MaSach=@MaSach";

            SqlConnection conn = DataProvider.MoKetNoi();
            SqlParameter[] parameters = {
                new SqlParameter("@MaSach", s.MaSach),
                new SqlParameter("@TenSach", s.TenSach),
                new SqlParameter("@TacGia", s.TacGia),
                new SqlParameter("@MaTheLoai", s.MaTheLoai),
                new SqlParameter("@SoLuong", s.SoLuong),
                new SqlParameter("@NamXuatBan", s.NamXuatBan)
            };

            bool kq = DataProvider.TruyVanKhongLayDuLieuCoThamSo(sql, conn, parameters);
            DataProvider.DongKetNoi(conn);
            return kq;
        }

        public static bool Xoa(int maSach)
        {
            string sql = "DELETE FROM Sach WHERE MaSach=@MaSach";

            SqlConnection conn = DataProvider.MoKetNoi();
            SqlParameter[] parameters = {
                new SqlParameter("@MaSach", maSach)
            };

            bool kq = DataProvider.TruyVanKhongLayDuLieuCoThamSo(sql, conn, parameters);
            DataProvider.DongKetNoi(conn);
            return kq;
        }

        public static bool CapNhatSoLuong(int maSach, int soLuongThayDoi)
        {
            string sql = "UPDATE Sach SET SoLuong = SoLuong + @SoLuongThayDoi WHERE MaSach = @MaSach";

            SqlConnection conn = DataAccessLayer.DataProvider.MoKetNoi();
            System.Data.SqlClient.SqlParameter[] parameters = {
            new System.Data.SqlClient.SqlParameter("@SoLuongThayDoi", soLuongThayDoi),
            new System.Data.SqlClient.SqlParameter("@MaSach", maSach)
            };

            bool kq = DataAccessLayer.DataProvider.TruyVanKhongLayDuLieuCoThamSo(sql, conn, parameters);
            DataAccessLayer.DataProvider.DongKetNoi(conn);
            return kq;
        }

        public static DataTable LayDataTableSach()
        {
            SqlConnection conn = DataAccessLayer.DataProvider.MoKetNoi();
            DataTable dt = DataAccessLayer.DataProvider.TruyVanLayDuLieu("SELECT MaSach, TenSach, TacGia, SoLuong FROM Sach", conn);
            DataAccessLayer.DataProvider.DongKetNoi(conn);
            return dt;
        }
    }
}
