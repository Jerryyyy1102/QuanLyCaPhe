using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_CaPhe.DataAccess.Control;
using QL_CaPhe.UsersControl;

namespace QL_CaPhe.Presentation
{
    public partial class fr_KetNoiSQL : Form
    {
        UC_SanPham sp = new UC_SanPham();
        UC_NhanVien nv = new UC_NhanVien();
        public fr_KetNoiSQL()
        {
            InitializeComponent();
        }
    
        private void btn_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_KetNoi_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            try
            {
                ConSQL db = new ConSQL();
                if(txt_TenServer.Text.Trim().Length==0 && txt_TenCSDL.Text.Trim().Length==0)
                {
                    MessageBox.Show("Không được để trống");

                }
                else
                {
                    
                    txt_TenCSDL.Text = db.dbName;
                    txt_TenServer.Text = db.svrName;
                    con = db.ConnectDB();
                    con.Open();
                    MessageBox.Show("Kết nối thành công");
                    con.Close();
                    fr_DangNhap dn = new fr_DangNhap();
                    this.Hide();
                    dn.ShowDialog();
                    this.Show();
                    
                    

                }
            }
            catch(Exception)
            {
                MessageBox.Show("Kết nối thất bại");
            }
            
        }
    }
}
