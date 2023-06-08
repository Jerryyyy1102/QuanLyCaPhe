using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CaPhe.DataAccess.Control
{
    class ConSQL
    {
        public string svrName = @"YOONA\SQLEXPRESS";
        public  string dbName = "QLY_CaPhe";

        public SqlConnection ConnectDB()
        {
            SqlConnection conn = new SqlConnection("Data Source =" + svrName + ";Initial Catalog=" + dbName + ";Integrated Security=True");
            return conn;
        }
    }
}
