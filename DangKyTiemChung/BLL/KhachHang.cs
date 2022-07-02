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
    public class KhachHang
    {
        public String _makh;
        public String _hoten;
        public string _gioitinh;
        public String _diachi;
        public DateTime _ngaysinh;
        public String _sdt;

        public KhachHang()
        {

        }
        public KhachHang(String makh, String hoten, String gioitinh,DateTime ngaysinh, String diachi, String sdt)
        {

            _makh = makh;
            _hoten = hoten;
            _gioitinh = gioitinh;
            _diachi = diachi;
            _ngaysinh = ngaysinh;
            _sdt = sdt;
        }
        public static bool ThemKH(KhachHang kh)
        {
            KhachHangDB db = new KhachHangDB();
            return db.Them(kh);
        }
        public static int CountKH()
        {
            KhachHangDB db = new KhachHangDB();
            return db.CountKH();
        }
        public static KhachHang LayTT_KH(String makh)
        {
            KhachHangDB db = new KhachHangDB();
            KhachHang kh = db.LayThongTinKH(makh);
            return kh;
        }
        public static SqlDataAdapter LayDS_KH()
        {
            KhachHangDB db = new KhachHangDB();
            SqlDataAdapter da = db.LayDS_KH();
            return da;
        }
        public static SqlDataAdapter TraCuuKH(string info)
        {
            KhachHangDB db = new KhachHangDB();
            SqlDataAdapter da = db.TraCuuKH(info);
            return da;
        }
    }
}
