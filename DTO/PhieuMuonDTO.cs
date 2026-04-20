using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuMuonDTO
    {
        public int MaPhieu { get; set; }
        public int MaDocGia { get; set; }
        public string TenDocGia { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayHenTra { get; set; }
        public string TinhTrang { get; set; }

        public PhieuMuonDTO()
        {
        }

        public PhieuMuonDTO(int maPhieu, int maDocGia, string tenDocGia,
                            DateTime ngayMuon, DateTime ngayHenTra, string tinhTrang)
        {
            this.MaPhieu = maPhieu;
            this.MaDocGia = maDocGia;
            this.TenDocGia = tenDocGia;
            this.NgayMuon = ngayMuon;
            this.NgayHenTra = ngayHenTra;
            this.TinhTrang = tinhTrang;
        }
    }
}
