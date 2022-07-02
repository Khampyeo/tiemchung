using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DangKyTiemChung.DAL;

namespace DangKyTiemChung.BLL
{
    public class GoiTiem
    {
        public String _magoi;
        public String _tengoi;
        public int _giatien;
        public GoiTiem(String magoi, String tengoi, int giatien)
        {
            _magoi = magoi;
            _tengoi = tengoi;
            _giatien = giatien;
        }
        public static SqlDataAdapter LayDS_GT()
        {
            GoiTiemDB db = new GoiTiemDB();
            SqlDataAdapter da = db.LayDS_GT();
            return da;
        }
        public static bool CheckExist(List<GoiTiem> listgt, GoiTiem gt)
        {
            foreach (var item in listgt)
            {
                if (gt._magoi == item._magoi)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
