using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DangKyTiemChung.DAL
{
    public class VacXinDB
    {
        public SqlDataAdapter LayDS_VX()
        {
            ConnectionDB db = new ConnectionDB();
            db.connectSql();
            string sql = "Select * from VACXIN";
            SqlCommand com = new SqlCommand(sql, db.sqlCon);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            return da;
        }
    }
}
