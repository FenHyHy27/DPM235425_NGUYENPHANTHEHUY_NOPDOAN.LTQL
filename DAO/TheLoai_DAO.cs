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
    public class TheLoai_DAO
    {
        public static List<TheLoai_DTO> LayDanhSach()
        {
            List<TheLoai_DTO> lst = new List<TheLoai_DTO>();
            SqlConnection conn = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu("SELECT * FROM TheLoai", conn);
            DataProvider.DongKetNoi(conn);

            foreach (DataRow row in dt.Rows)
            {
                lst.Add(new TheLoai_DTO
                {
                    MaTheLoai = int.Parse(row["MaTheLoai"].ToString()),
                    TenTheLoai = row["TenTheLoai"].ToString()
                });
            }
            return lst;
        }
    }
}
