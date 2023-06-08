using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_CaPhe.UsersControl;
using QL_CaPhe.DataAccess.Control;
using QL_CaPhe.DataAccess.Model;
using System.Drawing.Imaging;

namespace QL_CaPhe
{
    public partial class fr_QuanLyCuaHang : Form
    {
       
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        public fr_QuanLyCuaHang()
        {
            InitializeComponent();
            UC_KhuyenMai uc = new UC_KhuyenMai();
            addUserControl(uc);
        }

        private void QuanLyBanHang_Load(object sender, EventArgs e)
        {

        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            UC_SanPham uc = new UC_SanPham();
            
            addUserControl(uc);
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            UC_KhuyenMai uc = new UC_KhuyenMai();
            addUserControl(uc);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            UC_NhanVien uc = new UC_NhanVien();
            addUserControl(uc);
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            UC_HoaDon uc = new UC_HoaDon();
            addUserControl(uc);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            UC_ThongKe uc = new UC_ThongKe();
            addUserControl(uc);
        }

        private void btnNhapXuat_Click(object sender, EventArgs e)
        {
            UC_NhapXuat uc = new UC_NhapXuat();
            addUserControl(uc);
        }
    }
}
