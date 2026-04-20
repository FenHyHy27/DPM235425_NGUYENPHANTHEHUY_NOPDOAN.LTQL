using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    class DataProvider
    {
        public static SqlConnection MoKetNoi()
        {
            string s = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";
            SqlConnection KetNoi = new SqlConnection(s);
            KetNoi.Open();
            return KetNoi;
        }

        public static DataTable TruyVanLayDuLieu(string sTruyVan, SqlConnection KetNoi)
        {
            SqlDataAdapter da = new SqlDataAdapter(sTruyVan, KetNoi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static bool TruyVanKhongLayDuLieu(string sTruyVan, SqlConnection KetNoi)
        {
            try
            {
                SqlCommand cm = new SqlCommand(sTruyVan, KetNoi);
                cm.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }

        public static void DongKetNoi(SqlConnection KetNoi)
        {
            if (KetNoi != null && KetNoi.State == ConnectionState.Open)
            {
                KetNoi.Close();
            }
        }
        public static DataTable TruyVanLayDuLieuCoThamSo(string query, SqlConnection conn, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddRange(parameters);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
      
        public static bool TruyVanKhongLayDuLieuCoThamSo(string query, SqlConnection conn, SqlParameter[] parameters)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static object TruyVanLayMotGiaTri(string query, SqlConnection conn, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteScalar();
        }
    }
}