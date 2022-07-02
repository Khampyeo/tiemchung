using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DangKyTiemChung.DAL
{
    class ConnectionDB
    {
        public  String strCon = "Data Source=KHAM\\SQLEXPRESS;Initial Catalog=TIEMNGUA;Integrated Security=True";
        public  SqlConnection sqlCon = null;
        public  bool connectSql()
        {
            try
            {
                if (sqlCon == null)
                    sqlCon = new SqlConnection(strCon);
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
