using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DangKyTiemChung.DAL
{
    public class GoiTiemDB
    {
        
        public SqlDataAdapter LayDS_GT()
        {
            ConnectionDB db = new ConnectionDB();
            db.connectSql();
            string sql = "Select * from GOITIEMCHUNG";
            SqlCommand com = new SqlCommand(sql, db.sqlCon);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            return da;
        }
    }
}
