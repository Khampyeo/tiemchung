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
    public class VacXin
    {
        public String _mavx;
        public String _tenvx;
        public  int _giatien;
        public VacXin(String mavx, String tenvx, int giatien)
        {
            _mavx = mavx;
            _tenvx = tenvx;
            _giatien = giatien;
        }
        public static SqlDataAdapter LayDS_VX()
        {
            VacXinDB db = new VacXinDB();
            SqlDataAdapter da = db.LayDS_VX();
            return da;
        }
        public static bool CheckExist(List<VacXin> listvx, VacXin vx)
        {
            foreach(var item in listvx)
            {
                if(vx._mavx == item._mavx)
                {
                    return true;
                }
            }
            return false;
        }       
    }
}
