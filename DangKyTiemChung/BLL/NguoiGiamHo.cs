using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DangKyTiemChung.DAL;
namespace DangKyTiemChung.BLL
{
    public class NguoiGiamHo
    {
        public String _makh;
        public String _hoten;
        public String _mqh;
        public String _sdt;
        public NguoiGiamHo(String makh, String hoten, String mqh, String sdt)
        {
            _makh = makh;
            _hoten = hoten;
            _mqh = mqh;
            _sdt = sdt;
        }
        public static bool CheckNGH(String makh)
        {
            NguoiGiamHoDB ngh = new NguoiGiamHoDB();
            return ngh.CheckNGH(makh);
        }
        public static NguoiGiamHo LayTT_NGH(string makh)
        {
            NguoiGiamHoDB db = new NguoiGiamHoDB();
            return db.LayThongTinNGH(makh);
        }
        public static bool ThemNGH(NguoiGiamHo ngh)
        {
            NguoiGiamHoDB db = new NguoiGiamHoDB();
            return db.Them(ngh);
        }
    }
}
