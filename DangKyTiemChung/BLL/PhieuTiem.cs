using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using DangKyTiemChung.DAL;
namespace DangKyTiemChung.BLL
{
    public  class PhieuTiem
    {
        public String _makh;
        public String _mapt;
        public List<GoiTiem> _goitiem;
        public List<VacXin> _vacxin;
        public DateTime _thoigiantiem;
        public PhieuTiem(String makh, String mapt, List<GoiTiem> goitiem, List<VacXin>  vacxin, DateTime thoigiantiem)
        {
            _makh = makh;
            _mapt = mapt;
            _goitiem = goitiem;
            _vacxin = vacxin;
            _thoigiantiem = thoigiantiem;
            
        }
        public static SqlDataAdapter LayTT_PT(string makh)
        {
            PhieuTiemDB db = new PhieuTiemDB();
            SqlDataAdapter da = db.LayThongTin(makh);
            return da;
        }
        public static bool ThemPT(PhieuTiem pt)
        {
            PhieuTiemDB db = new PhieuTiemDB();
            return db.Them(pt);
        }
        public static int CountPT()
        {
            PhieuTiemDB db = new PhieuTiemDB();
            return db.CountPT();
        }
        public static bool ThemCT_VX(PhieuTiem pt,int index)
        {
            PhieuTiemDB db = new PhieuTiemDB();
            return db.ThemCT_VX(pt,index);
        }
        public static bool ThemCT_GT(PhieuTiem pt, int index)
        {
            PhieuTiemDB db = new PhieuTiemDB();
            return db.ThemCT_GT(pt,index);
        }
    }
}
