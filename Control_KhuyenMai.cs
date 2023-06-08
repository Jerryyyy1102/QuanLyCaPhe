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
    class Control_KhuyenMai
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
        public DataTable timkiem(string table,string name,string value)
        {
            ds = new DataSet();
            string str = "select * from " + table + " where " + name + " ='" + value + "'";
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
            str += " and " + table1 + '.' + key + "= " + where + "'";
            SqlCommand cmd = new SqlCommand(str, connect.ConnectDB());
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, table1);
            dt = ds.Tables[table1];
            return dt;
        }
        public int check_Key(string ma, string table)
        {
            DataRow drCheck = ds.Tables[table].Rows.Find(ma);
            if (drCheck != null)
            {
                return 1;
            }
            return 0;
        }
        public void insert(Model_KhuyenMai km, string table)
        {
            DataRow dr = ds.Tables[table].NewRow();
            dr[0] = km.MaVouncher;
            dr[1] = km.NgayBD;
            dr[2] = km.NgayKT;
            dr[3] = km.GiaTriToiThieu;
            dr[4] = km.KhuyenMaiToiDa;
            dr[5] = km.SoLuotSD;
         
            ds.Tables[table].Rows.Add(dr);
            cB = new SqlCommandBuilder(da);
            da.Update(ds, table);
        }

        public void delete(string table, string ma)
        {
            DataRow dr = ds.Tables[table].Rows.Find(ma);
            if (dr != null)
            {
                dr.Delete();
            }
            cB = new SqlCommandBuilder(da);
            da.Update(ds, table);
        }
        public void edit( string ma, string ngayBD,string ngayKT,string giatritoithieu,string khuyenmaitoida,string soluotSD)
        {
            DataRow dr = ds.Tables["Vouncher"].Rows.Find(ma);
            if (dr != null)
            {
             
                dr["NgayBD"] = ngayBD;
                dr["NgayKT"] = ngayKT;
                dr["GiaTriToiThieu"] = giatritoithieu;
                dr["KhuyenMaiToiDa"] = khuyenmaitoida;
                dr["SoLuotSD"] = soluotSD;
      
            }
            SqlCommandBuilder cB = new SqlCommandBuilder(da);
            da.Update(ds, "Vouncher");
        }

    }
}
