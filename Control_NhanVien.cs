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
    class Control_NhanVien
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
            da.Fill(ds,table);
            dt = ds.Tables[table];
            return dt;
        }
        public DataTable truyvan(string table1,string table2,string key,string where)
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
     
        public int check_Key(string ma,string table)
        {
            DataRow drCheck = ds.Tables[table].Rows.Find(ma);
            if(drCheck!=null)
            {
                return 1;
            }
            return 0;
        }

        public bool Check_FK(string tb1, string tb2,string ma)
        {
            dt = truyvan(tb1, tb2,"MaNV", ma);
            int dr = dt.Rows.Count;
            return (dr != 0);
        }
        public void insert(Model_NhanVien nv,string table)
        {
            
            DataRow dr = ds.Tables[table].NewRow();
            dr[0] = nv.MaNV;
            dr[1] = nv.TenNV;
            dr[2] = nv.GioiTinh;
            dr[3] = nv.CMND1;
            dr[4] = nv.NgaySinh;
            dr[5] = nv.SDT1;
            dr[6] = nv.Email;
            dr[7] = nv.DiaChi;
            dr[8] = nv.NgayVaoLam;
            dr[9] = nv.MaCV;
            dr[10] = nv.Hinhanh;
            ds.Tables[table].Rows.Add(dr);
            cB = new SqlCommandBuilder(da);
            da.Update(ds, table);
        }

        public bool delete(string table,string ma)
        {
            if (Check_FK(table, "HOADON", ma))
                return false;
            if (Check_FK(table, "TAIKHOAN", ma))
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
        public DataRow edit(string table,Model_NhanVien nv)
        {
            DataRow dr = ds.Tables[table].Rows.Find(nv.MaNV);
            if(dr!=null)
            {
                dr[1] = nv.TenNV;
                dr[2] = nv.GioiTinh;
                dr[3] = nv.CMND1;
                dr[4] = nv.NgaySinh.ToString("dd/MM/yyyy", null);
                dr[5] = nv.SDT1;
                dr[6] = nv.Email;
                dr[7] = nv.DiaChi;
                dr[8] = nv.NgayVaoLam.ToString("dd/MM/yyyy",null);
                dr[9] = nv.MaCV;
                cB = new SqlCommandBuilder(da);
                da.Update(ds, table);
            }
            return dr;
            
        }
    }
}
