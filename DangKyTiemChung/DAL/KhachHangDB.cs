using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DangKyTiemChung.BLL;

namespace DangKyTiemChung.DAL
{
    public class KhachHangDB
    {       
        public SqlDataAdapter LayDS_KH()
        {
            ConnectionDB db = new ConnectionDB();
            db.connectSql();
            string sql = "Select MaKH,HoTen,DienThoai from KHACH_HANG";
            SqlCommand com = new SqlCommand(sql, db.sqlCon);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            return da;
        }      
        public KhachHang LayThongTinKH(String makh)
        {
            ConnectionDB db = new ConnectionDB();
            db.connectSql();
            KhachHang kh = new KhachHang();
            string sql = "Select MAKH,HOTEN,GIOITINH,DIENTHOAI,DiaChi,NGSINH from KHACH_HANG where MaKH = @makh";          
            SqlCommand com = new SqlCommand(sql, db.sqlCon);
            com.Parameters.AddWithValue("@makh", makh);
            com.CommandType = CommandType.Text;
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            kh._makh = reader.GetString(0);
            kh._hoten = reader.GetString(1);
            kh._gioitinh = reader.GetString(2);
            kh._sdt = reader.GetString(3);
            kh._diachi = reader.GetString(4);
            kh._ngaysinh = reader.GetDateTime(5);
            return kh;           
        }
        public bool Them(KhachHang kh)
        {
            ConnectionDB db = new ConnectionDB();
            db.connectSql();
            string sql = "INSERT INTO KHACH_HANG VALUES (@makh,@hoten,@gioitinh,@ngaysinh,@dienthoai,@diachi)";
            SqlCommand com = new SqlCommand(sql, db.sqlCon);
            com.Parameters.AddWithValue("@makh", kh._makh);
            com.Parameters.AddWithValue("@hoten", kh._hoten);
            com.Parameters.AddWithValue("@gioitinh", kh._gioitinh);
            com.Parameters.AddWithValue("@ngaysinh", kh._ngaysinh);
            com.Parameters.AddWithValue("@dienthoai", kh._sdt);
            com.Parameters.AddWithValue("@diachi", kh._diachi);
            com.CommandType = CommandType.Text;
            int rowCount = com.ExecuteNonQuery();
            if (rowCount > 0)
                return true; 
            return false;
        }
        public int CountKH()
        {
            ConnectionDB db = new ConnectionDB();
            db.connectSql();
            int count = 0;
            string sql = "Select count(*) from KHACH_HANG";
            SqlCommand com = new SqlCommand(sql, db.sqlCon);
            com.CommandType = CommandType.Text;
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            count = reader.GetInt32(0);
            return count+200;
        }
        public SqlDataAdapter TraCuuKH(string info)
        {
            ConnectionDB db = new ConnectionDB();
            db.connectSql();
            string sql = "Select MaKH,HoTen,DienThoai from KHACH_HANG where MaKH like '%"+info+ "%' or DienThoai like '%" + info + "%' or HoTen like '%" + info + "%' ";
            SqlCommand com = new SqlCommand(sql, db.sqlCon);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            return da;
        }
    }
}
    