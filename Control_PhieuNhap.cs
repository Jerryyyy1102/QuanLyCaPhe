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
    class Control_PhieuNhap
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
        public DataTable timkiem(string table, string name, string value)
        {
            ds = new DataSet();
            string str = "select * from " + table + " where " + name + " ='" + value + "'";
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
        public DataTable truyvan(string table1, string table2, string key, string ma)
        {
            ds = new DataSet();
            string selectstr = "select * from " + table1 + ", " + table2 + " Where ";
            selectstr += table1 + "." + key + " = " + table2 + "." + key + " and " + table1 + "." + key + " = '" + ma + "'";
            da = new SqlDataAdapter(selectstr, connect.ConnectDB());
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
        public void insert(Model_PhieuNhap pn, string table)
        {
            DataRow dr = ds.Tables[table].NewRow();
            dr[0] = pn.MaPN;
            dr[1] = pn.TienNhap;
            dr[2] = pn.GhiChu;
            dr[3] = pn.MaNCC;
            dr[4] = pn.MaChucVu;
            

            ds.Tables[table].Rows.Add(dr);
            cB = new SqlCommandBuilder(da);
            da.Update(ds, table);
        }

        public bool delete(string table, string ma)
        {
            if (Check_FK(table, "CTPhieuNhap", ma))
                return false;
            DataRow dr = ds.Tables[table].Rows.Find(ma);
            if (dr != null)
            {
                dr.Delete();

            }
            cB = new SqlCommandBuilder(da);

            da.Update(ds, table);
            return true;

        }
        
        public void edit(string table,string ma,Model_PhieuNhap pn)
        {
            DataRow dr = ds.Tables[table].Rows.Find(ma);
            if (dr != null)
            {

                dr["TienNhap"] = pn.TienNhap;
                dr["GhiChu"] = pn.GhiChu;
                dr["MaNCC"] = pn.MaNCC;
                dr["MaChucVu"] = pn.MaChucVu;
               

            }
            SqlCommandBuilder cB = new SqlCommandBuilder(da);
            da.Update(ds, "Vouncher");
        }
        public DataTable select_cboNCC(string table1,string table2,string id)
        {
            ds = new DataSet();
            string str = "select * from  " + table1 +","+table2+" where "+table1+".MaNCC="+table2+".MaNCC and"+table1+".MaNCC='"+id+"'";
      
            SqlCommand cmd = new SqlCommand(str, connect.ConnectDB());
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, table1);
            dt = ds.Tables[table1];
            return dt;
        }
        public bool Check_FK(string tb1, string tb2, string ma)
        {
            dt = truyvan(tb1, tb2, "MaPN", ma);
            int dr = dt.Rows.Count;
            return (dr != 0);
        }
    }
}
