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
    class Control_HoaDon
    {
        #region Thuộc tính
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
        #endregion


        #region Truy vấn
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
        public int check_Trungma(string ma, string table)
        {
            DataRow drCheck = ds.Tables[table].Rows.Find(ma);
            if (drCheck != null)
            {
                return 1;
            }
            return 0;
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
            str += table1 + "." + key + "= " + table2 + "." + key + "";
            SqlCommand cmd = new SqlCommand(str, connect.ConnectDB());
            da = new SqlDataAdapter(cmd);
            string theobang = table1 + "_" + table2;
            da.Fill(ds, theobang);
            dt = ds.Tables[theobang];
            return dt;

        }
        #endregion


        #region Thêm,xóa,sửa
        public void insert(Model_HoaDon hd, string table)
        {
            DataRow dr = ds.Tables[table].NewRow();
            dr[0] = hd.MaHD;
            dr[1] = hd.NgayLap;
            dr[2] = hd.HinhThuc;
            dr[3] = hd.TienGiam;
            dr[4] = hd.TongTien;
            dr[5] = hd.MaNV;
            dr[6] = hd.MaKH;
            dr[7] = hd.MaVouncher;
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
        public void edit(string table, string ma, Model_HoaDon hd)
        {
            DataRow dr = ds.Tables[table].Rows.Find(ma);
            if (dr != null)
            {
                dr["HinhThuc"] = hd.HinhThuc;
                dr["NgayLap"] = hd.NgayLap;
                dr["TienGiam"] = hd.TienGiam;
                dr["TongTien"] = hd.TongTien;
                dr["MaNV"] = hd.MaNV;
                dr["MaKH"] = hd.MaKH;
                dr["MaVouncher"] = hd.MaVouncher;

            }
            cB = new SqlCommandBuilder(da);
            da.Update(ds, table);
        }
        #endregion
    }
}
