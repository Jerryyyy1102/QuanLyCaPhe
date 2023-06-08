using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using QL_CaPhe.DataAccess.Model;
using QL_CaPhe.DataAccess.Control;
using QL_CaPhe.Presentation;
using QL_CaPhe.UsersControl;
namespace QL_CaPhe.Presentation
{
    public partial class fr_CTHoaDon : Form
    {


        #region Biến toàn cục
        DataColumn[] key = new DataColumn[1];
        Control_CTHoaDon hd = new Control_CTHoaDon();
        Control_CTHoaDon ctr_CTHD = new Control_CTHoaDon();
        public fr_CTHoaDon()
        {
            InitializeComponent();
        }

        string tb_CTHD = "ChiTietHoaDon";
        #endregion

        #region Load Datagridview
        public void AddHeaderCTHoaDon()
        {
            DGV_CTHD.Columns.Clear();
            DGV_CTHD.Columns.Add("MaHD", "Mã hóa đơn");
            DGV_CTHD.Columns[0].DataPropertyName = "MaHD";
            DGV_CTHD.Columns.Add("MaSP", "Mã sản phẩm");
            DGV_CTHD.Columns[1].DataPropertyName = "MaSP";
            DGV_CTHD.Columns.Add("SoLuong", "Số lượng");
            DGV_CTHD.Columns[2].DataPropertyName = "SoLuong";
            DGV_CTHD.Columns.Add("ThanhTien", "Thành tiền");
            DGV_CTHD.Columns[3].DataPropertyName = "ThanhTien";
        }
        public void DatabindingCTHD(DataTable pDT)
        {
            txt_MaHD_CTHD.DataBindings.Clear();
            txt_MaSP_CTHD.DataBindings.Clear();
            txt_SoLuong_CHTD.DataBindings.Clear();
            txt_ThanhTien_CTHD.DataBindings.Clear();

            txt_MaHD_CTHD.DataBindings.Add("Text", pDT, "MaHD");
            txt_MaSP_CTHD.DataBindings.Add("Text", pDT, "MaSP");
            txt_SoLuong_CHTD.DataBindings.Add("Text", pDT, "SoLuong");
            txt_ThanhTien_CTHD.DataBindings.Add("Text", pDT, "ThanhTien");
           

        }
        private void DGV_CTHD_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGV_CTHD.Rows[e.RowIndex];
                txt_MaHD_CTHD.Text = row.Cells[0].Value.ToString();
                txt_MaSP_CTHD.Text = row.Cells[1].Value.ToString();
                txt_SoLuong_CHTD.Text = row.Cells[2].Value.ToString();
                txt_ThanhTien_CTHD.Text = row.Cells[3].Value.ToString();
            }
        }
        void load_dataGV_DSCTHD()
        {
            DataTable dthd = hd.select(tb_CTHD);
            DGV_CTHD.DataSource = dthd;
            key[0] = dthd.Columns[0];

        }
        void load_AllCTHD()
        {
            AddHeaderCTHoaDon();
            load_dataGV_DSCTHD();
            DatabindingCTHD(hd.Ds.Tables[tb_CTHD]);
        }
        public void Reset_Load()
        {
            AddHeaderCTHoaDon();
            load_dataGV_DSCTHD();
            DatabindingCTHD(hd.Ds.Tables[tb_CTHD]);
        }
        #endregion        

        #region form Load, Thêm, xóa, sửa 
        private void btn_Thoat_CTHD_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fr_CTHoaDon_Load(object sender, EventArgs e)
        {
            load_AllCTHD();
        }

        #endregion

        private void btn_Them_CTHD_Click(object sender, EventArgs e)
        {
            try
            {
                Model_CTHoaDon newcthd = new Model_CTHoaDon();
                newcthd.MaHD = txt_MaHD_CTHD.Text;
                newcthd.MaSP = txt_MaSP_CTHD.Text;
                newcthd.SoLuong = Convert.ToInt32(txt_SoLuong_CHTD.Text);
                newcthd.ThanhTien = Convert.ToInt32(txt_ThanhTien_CTHD.Text);
                newcthd.DonGia = Convert.ToInt32(txt_DonGia_CTHD.Text);

                if (hd.check_Trungma(newcthd.MaHD, tb_CTHD) == 1)
                {
                    MessageBox.Show("Trùng mã");
                }
                hd.insert(newcthd, tb_CTHD);
                MessageBox.Show("Thành công");
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void btn_LuuCTHD_Click(object sender, EventArgs e)
        {
            Reset_Load();
        }

        private void btn_XoaCTHD_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0);
                if (r == DialogResult.Yes)
                {
                    if (!hd.delete("ChiTietHoaDon", txt_MaHD_CTHD.Text))
                        MessageBox.Show("Có khóa ngoại !");
                    else
                        MessageBox.Show("Xóa thành công !", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void btn_SuaCTHD_Click(object sender, EventArgs e)
        {
            try
            {
                Model_CTHoaDon edithd = new Model_CTHoaDon();
                edithd.MaHD = txt_MaHD_CTHD.Text;
                edithd.MaSP = txt_MaSP_CTHD.Text;
                edithd.SoLuong = Convert.ToInt32(txt_SoLuong_CHTD.Text);
                edithd.ThanhTien = Convert.ToInt32(txt_ThanhTien_CTHD.Text);
                MessageBox.Show("Thành công");
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

    }
}
