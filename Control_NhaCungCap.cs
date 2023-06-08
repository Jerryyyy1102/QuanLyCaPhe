using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CaPhe.DataAccess.Control
{
    class Control_NhaCungCap
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
        public DataTable truyvan(string table1, string table2, string key, string where)
        {
            ds = new DataSet();
            string str = "select * from " + table1 + "," + table2 + " where ";
            str += table1 + "." + key + "= " + table2 + "." + key + "";
            str += " and " + table1 + '.' + key + "= '" + where + "'";
            SqlCommand cmd = new SqlCommand(str, connect.ConnectDB());
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, table1);
            dt = ds.Tables[table1];
            return dt;
        }
        public DataTable truyvan(string table1, string table2, string key)
        {
            ds = new DataSet();
            string str = "select * from " + table1 + "," + table2 + " where ";
            str += table1 + "." + key + "= " + table2 + "." + key + "";
            SqlCommand cmd = new SqlCommand(str, connect.ConnectDB());
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, table1);
            dt = ds.Tables[table1];
            return dt;
        }

        public int check_Trungma(string ma, string table)
        {
            DataRow drCheck = ds.Tables[table].Rows.Find(ma);
            if (drCheck != null)
            {
                return 1;
            }
            return 0;
        }
    }
}
