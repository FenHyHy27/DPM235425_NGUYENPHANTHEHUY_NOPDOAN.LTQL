using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DocGia_BUS
    {
        public static List<DocGia_DTO> LayDanhSach()
            => DocGia_DAO.LayDanhSach();

        public static bool Them(DocGia_DTO dg)
        {
            if (string.IsNullOrWhiteSpace(dg.HoTen))
                return false;
            return DocGia_DAO.Them(dg);
        }

        public static bool Sua(DocGia_DTO dg)
        {
            if (string.IsNullOrWhiteSpace(dg.HoTen)) return false;
            return DocGia_DAO.Sua(dg);
        }

        public static bool Xoa(int ma) => DocGia_DAO.Xoa(ma);

        public static List<DocGia_DTO> TimKiemDocGia(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return DocGia_DAO.LayDanhSach();
            return DocGia_DAO.TimKiem(tuKhoa);
        }
    }
}
