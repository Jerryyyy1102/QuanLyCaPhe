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
    class Control_ChiTietPN
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
        public DataTable truyvan(string table1, string table2,string table3, string key1,string key2)
        {
            ds = new DataSet();
            string selectstr = "select * from " + table1 + ", " + table2 + ", " + table3 + " Where ";
            selectstr += table1 + "." + key1 + " = " + table2 + "." + key1 + " and " + table1 + "." + key2 + " = " + table3 + "." + key2;
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
        public void insert(Model_ChiTietPN ctpn, string table)
        {
            
            DataRow dr = ds.Tables[table].NewRow();
            
            dr[0] = ctpn.MaSP;
            dr[1] = ctpn.MaPN;
            dr[2] = ctpn.SoLuong;
            dr[3] = ctpn.GiaNhap;
            dr[4] = ctpn.ThanhTien;

            ds.Tables[table].Rows.Add(dr);
            cB = new SqlCommandBuilder(da);
            da.Update(ds, table);
            
        }

        public void delete(string table, string ma,string ma2)
        {
            DataRow dr = ds.Tables[table].Rows.Find(ma);
            if (dr != null)
            {
                dr.Delete();
            }
            cB = new SqlCommandBuilder(da);
            da.Update(ds, table);
        }
        public void edit(string table, string ma, Model_ChiTietPN ctpn)
        {
            DataRow dr = ds.Tables[table].Rows.Find(ma);
            if (dr != null)
            {

     
                dr["SoLuong"] = ctpn.SoLuong;
                dr["GiaNhap"] = ctpn.GiaNhap;
                dr["ThanhTien"] = ctpn.ThanhTien;


            }
            SqlCommandBuilder cB = new SqlCommandBuilder(da);
            da.Update(ds, "CTPhieuNhap");
        }
        public DataTable select_cboMaSP(string table1, string table2, string id)
        {
            ds = new DataSet();
            string str = "select * from  " + table1 + "," + table2 + " where " + table1 + ".MaNCC=" + table2 + ".MaNCC and" + table1 + ".MaNCC='" + id + "'";

            SqlCommand cmd = new SqlCommand(str, connect.ConnectDB());
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, table1);
            dt = ds.Tables[table1];
            return dt;
        }
    }
}