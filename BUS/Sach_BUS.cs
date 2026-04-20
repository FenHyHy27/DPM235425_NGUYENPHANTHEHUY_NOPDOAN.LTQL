using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BUS
{
    public class Sach_BUS
    {
        public static List<Sach_DTO> LayDanhSach()
            => Sach_DAO.LayDanhSach();

        public static bool Them(Sach_DTO s)
        {
            if (string.IsNullOrWhiteSpace(s.TenSach)) return false;
            return Sach_DAO.Them(s);
        }

        public static bool Sua(Sach_DTO s) => Sach_DAO.Sua(s);
        public static bool Xoa(int ma) => Sach_DAO.Xoa(ma);

        public static bool CapNhatSoLuong(int maSach, int soLuongThayDoi)
        {
            return Sach_DAO.CapNhatSoLuong(maSach, soLuongThayDoi);
        }

        public static System.Data.DataTable LayDataTableSach()
        {
            return Sach_DAO.LayDataTableSach();
        }
    }
}
