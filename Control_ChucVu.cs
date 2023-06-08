using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_CaPhe.DataAccess.Model;
using System.Data;
using System.Data.SqlClient;
namespace QL_CaPhe.DataAccess.Control
{
    class Control_ChucVu
    {
        ConSQL connect = new ConSQL();
        DataSet ds;
        SqlDataAdapter da;
        DataTable dt;
        SqlCommandBuilder cB;
        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }


        public DataTable select(string table)
        {
            ds = new DataSet();
            string str = "select * from " + table;
            SqlCommand cmd = new SqlCommand(str, connect.ConnectDB());
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, table);
            dt = ds.Tables[table];
            return dt;
        }
        public DataTable truyvan(string table1, string table2, string key)
        {
            ds = new DataSet();
            string selectstr = "select * from " + table1 + ", " + table2 + " Where ";
            selectstr += table1 + "." + key + " = " + table2 + "." + key;
            da = new SqlDataAdapter(selectstr, connect.ConnectDB());
            da.Fill(ds, table1);
            return ds.Tables[table1];
        }
    }
}
