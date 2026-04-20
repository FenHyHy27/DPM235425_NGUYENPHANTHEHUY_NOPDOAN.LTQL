using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TheLoai_BUS
    {
        public static List<TheLoai_DTO> LayDanhSach()
        {
            return TheLoai_DAO.LayDanhSach();
        }
    }
}
