using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class TheLoaiDAO
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True";

        public List<TheLoaiDTO> LayDanhSachTheLoai()
        {
            List<TheLoaiDTO> danhSach = new List<TheLoaiDTO>();

            // Khởi tạo kết nối
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); // Mở kết nối

                
                string query = "SELECT MaTheLoai, TenTheLoai FROM TheLoai";
                SqlCommand cmd = new SqlCommand(query, conn);

                
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    TheLoaiDTO tl = new TheLoaiDTO();
                    tl.MaTheLoai = Convert.ToInt32(reader["MaTheLoai"]);
                    tl.TenTheLoai = reader["TenTheLoai"].ToString();

                    
                    danhSach.Add(tl);
                }
            }
            return danhSach; 
        }
    }
}
