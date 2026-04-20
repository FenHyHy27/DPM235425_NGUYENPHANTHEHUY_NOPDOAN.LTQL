using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HeThong_BUS
    {
        public static bool SaoLuuDuLieu(string duongDanLuu)
        {
            return HeThong_DAO.SaoLuuDuLieu(duongDanLuu);
        }

        public static bool PhucHoiDuLieu(string duongDanFile)
        {
            return HeThong_DAO.PhucHoiDuLieu(duongDanFile);
        }
    }
}
