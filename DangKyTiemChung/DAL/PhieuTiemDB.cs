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
    public class PhieuTiemDB
    {      
        public SqlDataAdapter LayThongTin(string makh)
        {
            ConnectionDB db = new ConnectionDB();
            db.connectSql();
            string sql = "Select * from PHIEUDANGKYTIEMCHUNG where makh = @makh";
            SqlCommand com = new SqlCommand(sql, db.sqlCon);
            com.Parameters.AddWithValue("@makh", makh);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            return da;
        }
        public bool Them(PhieuTiem pt)
        {
            ConnectionDB db = new ConnectionDB();
            db.connectSql();
            string sql = "INSERT INTO PHIEUDANGKYTIEMCHUNG VALUES (@mapt,@makh,0,0,@thoigiantiem)";
            SqlCommand com = new SqlCommand(sql, db.sqlCon);
            com.Parameters.AddWithValue("@makh", pt._makh);
            com.Parameters.AddWithValue("@mapt", pt._mapt);
            com.Parameters.AddWithValue("@thoigiantiem", pt._thoigiantiem);
            com.CommandType = CommandType.Text;
            int rowCount = com.ExecuteNonQuery();
            if (rowCount > 0)
                return true;
            return false;
        }
        public bool ThemCT_VX(PhieuTiem pt, int index)
        {
            ConnectionDB db = new ConnectionDB();
            db.connectSql();
            string sql = "INSERT INTO CT_DANGKI_VACXIN VALUES (@mapt,@mavx)";
            SqlCommand com = new SqlCommand(sql, db.sqlCon);
            com.Parameters.AddWithValue("@mapt", pt._mapt);
            com.Parameters.AddWithValue("@mavx", pt._vacxin[index]._mavx);
            com.CommandType = CommandType.Text;
            int rowCount = com.ExecuteNonQuery();
            if (rowCount > 0)
                return true;
            return false;
        }
        public bool ThemCT_GT(PhieuTiem pt, int index)
        {
            ConnectionDB db = new ConnectionDB();
            db.connectSql();
            string sql = "INSERT INTO CT_DANGKI_GOITIEM VALUES (@mapt,@magtc)";
            SqlCommand com = new SqlCommand(sql, db.sqlCon);
            com.Parameters.AddWithValue("@mapt", pt._mapt);
            com.Parameters.AddWithValue("@magtc", pt._goitiem[index]._magoi);
            com.CommandType = CommandType.Text;
            int rowCount = com.ExecuteNonQuery();
            if (rowCount > 0)
                return true;
            return false;
        }
        public int CountPT()
        {
            int count = 0;
            ConnectionDB db = new ConnectionDB();
            db.connectSql();
            string sql = "Select count(*) from PHIEUDANGKYTIEMCHUNG";
            SqlCommand com = new SqlCommand(sql, db.sqlCon);
            com.CommandType = CommandType.Text;
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            count = reader.GetInt32(0);
            return count + 200;
        }
    }
}
