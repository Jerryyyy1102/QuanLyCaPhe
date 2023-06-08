using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_CaPhe.DataAccess.Model;

namespace QL_CaPhe.DataAccess.Control
{
    class Control_SanPham
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
            string theobang = table1 + "_" + table2;
            da.Fill(ds, theobang);
            dt = ds.Tables[theobang];
            return dt;
        }
        public DataTable truyvan(string table1, string table2, string key)
        {
            ds = new DataSet();
            string str = "select * from " + table1 + "," + table2 + " where ";
            str += table1 + "." + key + "= " + table2 + "." + key ;
            SqlCommand cmd = new SqlCommand(str, connect.ConnectDB());
            da = new SqlDataAdapter(cmd);
            string theobang = table1 + "_" + table2;
            da.Fill(ds, theobang);
            dt = ds.Tables[theobang];
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
        public void insert(Model_SanPham sp, string table)
        {
            DataRow dr = ds.Tables[table].NewRow();
            dr[0] = sp.MaSP;
            dr[1] = sp.TenSP;
            dr[2] = sp.MotaSP;
            dr[3] = sp.SoLuong;
            dr[4] = sp.HinhAnh;
            dr[5] = sp.GiaSP;
            dr[6] = sp.MaLoai;
            dr[7] = sp.MaNCC;
            ds.Tables[table].Rows.Add(dr);
            cB = new SqlCommandBuilder(da);
            da.Update(ds, table);
        }
        public void delete(string table,string ma)
        {
            DataRow dr = ds.Tables[table].Rows.Find(ma);
            if(dr!=null)
            {
                dr.Delete();
            }
            cB = new SqlCommandBuilder(da);

            da.Update(ds, table);
        }
        public DataRow edit(string table,Model_SanPham sp)
        {
            DataRow dr = ds.Tables[table].Rows.Find(sp.MaSP);
            if(dr!=null)
            {
                dr[1] = sp.TenSP;
                dr[2] = sp.MotaSP;
                dr[3] = sp.SoLuong;
                dr[5] = sp.GiaSP;
                cB = new SqlCommandBuilder(da);
                da.Update(ds, table);
            }
            return dr;
        }
        
       
    }
}
