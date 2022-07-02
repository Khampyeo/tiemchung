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
    public class NguoiGiamHoDB
    {
        
        public  bool CheckNGH(String makh)
        {
            ConnectionDB db = new ConnectionDB();
            db.connectSql();
            string sql = "Select * from NGUOIGIAMHO where MaKH = @makh";
            SqlCommand com = new SqlCommand(sql, db.sqlCon);
            com.Parameters.AddWithValue("@makh", makh);
            com.CommandType = CommandType.Text;
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
                return true;
            else return false;
        }
        public NguoiGiamHo LayThongTinNGH(string makh)
        {
            ConnectionDB db = new ConnectionDB();
            db.connectSql();
            string sql = "Select * from NGUOIGIAMHO where MaKH = @makh";
            SqlCommand com = new SqlCommand(sql, db.sqlCon);
            com.Parameters.AddWithValue("@makh", makh);
            com.CommandType = CommandType.Text;
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            NguoiGiamHo ngh = new NguoiGiamHo(makh,reader.GetString(1), reader.GetString(3), reader.GetString(2));
            return ngh;
        }
        public bool Them(NguoiGiamHo ngh)
        {
            ConnectionDB db = new ConnectionDB();
            db.connectSql();
            string sql = "INSERT INTO NGUOIGIAMHO VALUES (@makh,@hoten,@sdt,@mqh)";
            SqlCommand com = new SqlCommand(sql, db.sqlCon);
            com.Parameters.AddWithValue("@makh", ngh._makh);
            com.Parameters.AddWithValue("@hoten", ngh._hoten);
            com.Parameters.AddWithValue("@sdt", ngh._sdt);
            com.Parameters.AddWithValue("@mqh", ngh._mqh);
            com.CommandType = CommandType.Text;
            int rowCount = com.ExecuteNonQuery();
            if (rowCount > 0)
                return true;
            return false;
        }
    }
}
