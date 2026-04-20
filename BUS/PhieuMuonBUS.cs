using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class PhieuMuonBUS
    {
        private PhieuMuonDAO phieuMuonDAO = new PhieuMuonDAO();

        public List<PhieuMuonDTO> LayDanhSachPhieuMuon()
        {
            return phieuMuonDAO.LayDanhSachPhieuMuon();
        }

        public List<PhieuMuonDTO> TimKiemPhieuMuon(string tuKhoa)
        {
            return phieuMuonDAO.TimKiemPhieuMuon(tuKhoa);
        }

        public int TimMaDocGiaTheoTen(string tenDocGia)
        {
            return phieuMuonDAO.TimMaDocGiaTheoTen(tenDocGia);
        }
        public List<DocGia_DTO> LayDanhSachDocGia()
        {
            return phieuMuonDAO.LayDanhSachDocGia();
        }

        public bool ThemPhieuMuon(PhieuMuonDTO pm, out string thongBao)
        {
            if (pm.NgayMuon.Date < DateTime.Today)
            {
                thongBao = "Ngày lập phiếu không được nằm trong quá khứ!";
                return false;
            }
            if (pm.MaDocGia <= 0)
            {
                thongBao = "Tên độc giả không hợp lệ hoặc không tồn tại trong hệ thống!";
                return false;
            }
            if (pm.NgayHenTra <= pm.NgayMuon)
            {
                thongBao = "Ngày hẹn trả phải sau ngày mượn!";
                return false;
            }

            int maPhieu = phieuMuonDAO.ThemPhieuMuon(pm);
            if (maPhieu > 0)
            {
                thongBao = "Thêm phiếu mượn thành công!";
                return true;
            }
            thongBao = "Thêm phiếu mượn thất bại!";
            return false;
        }

        public bool SuaPhieuMuon(PhieuMuonDTO pm, out string thongBao)
        {
            if (pm.MaDocGia <= 0)
            {
                thongBao = "Tên độc giả không hợp lệ hoặc không tồn tại trong hệ thống!";
                return false;
            }
            if (pm.NgayHenTra <= pm.NgayMuon)
            {
                thongBao = "Ngày hẹn trả phải sau ngày mượn!";
                return false;
            }

            bool kq = phieuMuonDAO.SuaPhieuMuon(pm);
            thongBao = kq ? "Cập nhật thành công!" : "Cập nhật thất bại!";
            return kq;
        }

        public bool XoaPhieuMuon(int maPhieu, out string thongBao)
        {
            bool kq = phieuMuonDAO.XoaPhieuMuon(maPhieu);
            thongBao = kq ? "Xóa phiếu mượn thành công!" : "Xóa phiếu mượn thất bại!";
            return kq;
        }
    }
}
