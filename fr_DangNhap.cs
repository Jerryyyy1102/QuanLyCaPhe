using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using QL_CaPhe.DataAccess.Control;
using QL_CaPhe.DataAccess.Model;
using QL_CaPhe.Presentation;
namespace QL_CaPhe
{
    public partial class fr_DangNhap : Form
    {
        ConSQL connect = new ConSQL();
        public fr_DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Model_TaiKhoan tk = new Model_TaiKhoan();
            fr_DangNhap dn = new fr_DangNhap();
            string matkhau = txtMatKhau.Text;
            tk.TenTK = txtTaiKhoan.Text;
            tk.MatKhau = txtMatKhau.Text;
            fr_QuanLyCuaHang ad = new fr_QuanLyCuaHang();
            fr_QuanLyBanHang bh = new fr_QuanLyBanHang();
            try
            {
                string str = "select * from TaiKhoan,NhanVien where TenTk='" + tk.TenTK + "' and MatKhau='" + tk.MatKhau + "' and TaiKhoan.MaNV=NhanVien.MaNV and MaChucVu LIKE '%QL%'";
                SqlDataAdapter da = new SqlDataAdapter(str, connect.ConnectDB());
                DataTable dt = new DataTable();
                da.Fill(dt);
                string str2 = "select * from TaiKhoan,NhanVien where TenTk='" + tk.TenTK + "' and MatKhau='" + tk.MatKhau + "' and TaiKhoan.MaNV=NhanVien.MaNV and MaChucVu LIKE '%TN%'";
                da = new SqlDataAdapter(str2, connect.ConnectDB());
                DataTable dt2 = new DataTable();
                da.Fill(dt2);
                if (dt.Rows.Count > 0)
                {
                    tk.TenTK = txtTaiKhoan.Text;
                    tk.MatKhau = txtMatKhau.Text;
                    this.Hide();
                    ad.ShowDialog();
                    this.Show();
                }
              
           
                else if (dt2.Rows.Count > 0)
                {
                    tk.TenTK = txtTaiKhoan.Text;
                    tk.MatKhau = txtMatKhau.Text;
                    this.Hide();
                    bh.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTaiKhoan.Clear();
                    txtMatKhau.Clear();
                    this.Hide();
                    dn.ShowDialog();
                    this.Show();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }

        }


    }
}
