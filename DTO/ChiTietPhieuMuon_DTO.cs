using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPhieuMuon_DTO
    {
        public int MaPhieu { get; set; }
        public int MaSach { get; set; }

       
        public string TenSach { get; set; }

        public DateTime? NgayTraThucTe { get; set; }

        public decimal TienPhat { get; set; }
    }
}
