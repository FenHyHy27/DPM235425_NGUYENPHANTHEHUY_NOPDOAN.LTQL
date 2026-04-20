using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HeThong_DAO
    {
        public static bool SaoLuuDuLieu(string duongDanLuu)
        {
            string query = $"BACKUP DATABASE QuanLyThuVien TO DISK = '{duongDanLuu}'";

            SqlConnection conn = DataProvider.MoKetNoi();
            bool ketQua = DataProvider.TruyVanKhongLayDuLieu(query, conn);
            DataProvider.DongKetNoi(conn);

            return ketQua;
        }

        public static bool PhucHoiDuLieu(string duongDanFile)
        {
            
            string connectionStringMaster = @"Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

            string query = $@"
            ALTER DATABASE QuanLyThuVien SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            RESTORE DATABASE QuanLyThuVien FROM DISK = '{duongDanFile}' WITH REPLACE;
            ALTER DATABASE QuanLyThuVien SET MULTI_USER;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionStringMaster))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
