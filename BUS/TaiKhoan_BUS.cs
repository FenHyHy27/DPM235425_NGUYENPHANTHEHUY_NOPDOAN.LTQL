using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TaiKhoan_BUS
    {
        public static TaiKhoan_DTO DangNhap(string user, string pass)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass)) return null;
            return TaiKhoan_DAO.KiemTraDangNhap(user, pass);
        }
    }
}
