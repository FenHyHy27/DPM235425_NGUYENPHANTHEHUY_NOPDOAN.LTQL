using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietPhieuMuon_BUS
    {
        public static List<ChiTietPhieuMuon_DTO> LayDanhSachTheoMaPhieu(int maPhieu)
        {
            return ChiTietPhieuMuon_DAO.LayDanhSachTheoMaPhieu(maPhieu);
        }

        public static bool Them(ChiTietPhieuMuon_DTO ct)
        {
            return ChiTietPhieuMuon_DAO.Them(ct);
        }

        public static bool Xoa(int maPhieu, int maSach)
        {
            return ChiTietPhieuMuon_DAO.Xoa(maPhieu, maSach);
        }

        public static bool CapNhatTraSach(int maPhieu, int maSach, DateTime ngayTra, decimal tienPhat)
        {
            return ChiTietPhieuMuon_DAO.CapNhatTraSach(maPhieu, maSach, ngayTra, tienPhat);
        }
    }
}
