using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ThongKe_BUS
    {
        public static int TongSoSach()          => ThongKe_DAO.TongSoSach();
        public static int TongSachDangMuon()    => ThongKe_DAO.TongSachDangMuon();
        public static int TongDocGiaTreHan()    => ThongKe_DAO.TongDocGiaTreHan();

        public static DataTable DanhSachSachDangMuon()   => ThongKe_DAO.DanhSachSachDangMuon();

        public static DataTable DanhSachDocGiaTreHan()   => ThongKe_DAO.DanhSachDocGiaTreHan();
    }
}
