using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DangKyTiemChung.DAL
{
    class TaiKhoan
    {
        public static string GetRole(string tk, string mk)
        {
            ConnectionDB db = new ConnectionDB();
            db.connectSql();
            string sql = "Select loai from TAIKHOAN where taikhoan = @tk and matkhau = @mk";
            SqlCommand com = new SqlCommand(sql, db.sqlCon);
            com.Parameters.AddWithValue("@tk", tk);
            com.Parameters.AddWithValue("@mk", mk);
            com.CommandType = CommandType.Text;
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                return reader.GetString(0);
            }
            return null;
        }
        public static string GetRoleNhanVien(string tk, string mk)
        {
            ConnectionDB db = new ConnectionDB();
            db.connectSql();
            string sql = "Select nv.VITRI from TAIKHOAN tk,NHAN_VIEN nv where tk.taikhoan = @tk and tk.matkhau = @mk and tk.id = nv.MANV";
            SqlCommand com = new SqlCommand(sql, db.sqlCon);
            com.Parameters.AddWithValue("@tk", tk);
            com.Parameters.AddWithValue("@mk", mk);
            com.CommandType = CommandType.Text;
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                return reader.GetString(0);
            }
            return null;
        }
    }
}
