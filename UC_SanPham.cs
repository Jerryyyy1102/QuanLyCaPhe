using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_CaPhe.DataAccess.Model;
using QL_CaPhe.DataAccess.Control;

namespace QL_CaPhe.UsersControl
{
    public partial class UC_SanPham : UserControl
    {
        DataColumn[] key = new DataColumn[1];
        Control_SanPham sp = new Control_SanPham();
        Control_NhaCungCap ctr_NCC = new Control_NhaCungCap();
        Control_LoaiSanPham ctrl_LoaiSP = new Control_LoaiSanPham();
        Control_SanPham ctrl_HinhSP = new Control_SanPham();

        string table = "SanPham";
        public UC_SanPham()
        {
            InitializeComponent();
            cbo_TenLoai_Load();
            cbo_MaNCC_Load();
            Load_SP_MaLoai();
            AddHeader();
            DTG_Load();
            Databingding(sp.Ds.Tables[table]);

            //Load_SP_MaLoai(); 

        }
        public void Reset_Load()
        {
            cbo_TenLoai_Load();
            cbo_MaNCC_Load();
            AddHeader();
            DTG_Load();
            
            Databingding(sp.Ds.Tables[table]);
        }

        public void AddHeader()
        {
            dGriVi_SanPham.Columns.Clear();
            dGriVi_SanPham.Columns.Add("MaSP", "Mã Sản Phẩm");
            dGriVi_SanPham.Columns[0].DataPropertyName = "MaSP";
            dGriVi_SanPham.Columns.Add("TenSP", "Tên Sản Phẩm");
            dGriVi_SanPham.Columns[1].DataPropertyName = "TenSP";
            dGriVi_SanPham.Columns.Add("MoTaSP", "Mô tả Sản Phẩm");
            dGriVi_SanPham.Columns[2].DataPropertyName = "MoTaSP";
            dGriVi_SanPham.Columns.Add("SoLuong", "Số lượng");
            dGriVi_SanPham.Columns[3].DataPropertyName = "SoLuong";
            dGriVi_SanPham.Columns.Add("HinhAnh", "Hình Ảnh");
            dGriVi_SanPham.Columns[4].DataPropertyName = "HinhAnh";
            dGriVi_SanPham.Columns.Add("Gia", "Giá Sản Phẩm");
            dGriVi_SanPham.Columns[5].DataPropertyName = "Gia";
            dGriVi_SanPham.Columns.Add("MaLoai", "Loại Sản Phẩm");
            dGriVi_SanPham.Columns[6].DataPropertyName = "MaLoai";
            dGriVi_SanPham.Columns.Add("MaNCC", "Nhà cung cấp");
            dGriVi_SanPham.Columns[7].DataPropertyName = "MaNCC";
  


            dGriVi_SanPham.Columns[4].Visible = false;






        }
        public void Databingding(DataTable pDT)
        {
            txt_MaSP.DataBindings.Clear();
            lb_TenSP.DataBindings.Clear();
            txt_MoTaSP.DataBindings.Clear();
            txt_SoLuongSP.DataBindings.Clear();
            txt_GiaSP.DataBindings.Clear();
            txt_LoaiSP.DataBindings.Clear();
            Pic_SP.DataBindings.Clear();

            txt_MaSP.DataBindings.Add("Text", pDT, "MaSP");
            lb_TenSP.DataBindings.Add("Text", pDT, "TenSP");
            txt_MoTaSP.DataBindings.Add("Text", pDT, "MoTaSP");
            txt_SoLuongSP.DataBindings.Add("Text", pDT, "SoLuong");
            txt_GiaSP.DataBindings.Add("Text", pDT, "Gia");
            txt_LoaiSP.DataBindings.Add("Text", pDT, "MaLoai");
            Pic_SP.DataBindings.Add("Text", pDT, "HinhAnh");

        }

        public void DTG_Load()
        {
            DataTable dtsp = sp.select(table);
            dGriVi_SanPham.DataSource = dtsp;
            key[0] = dtsp.Columns[0];
            dtsp.PrimaryKey = key;
        }
      

        public void cbo_TenLoai_Load()
        {
            DataTable dt = ctrl_LoaiSP.select("LoaiSanPham");
            cbo_LoaiSP.DataSource = dt;
            cbo_LoaiSP.DisplayMember = "TenLoai";
            cbo_LoaiSP.ValueMember = "MaLoai";
        }
        public void cbo_MaNCC_Load()
        {
            DataTable dt = ctr_NCC.select("NhaCungCap");
            cbo_NCC.DataSource = dt;
            cbo_NCC.DisplayMember = "MaNCC";
            cbo_NCC.ValueMember = "MaNCC";
        }

        void pic(string name)
        {
            Pic_SP.ImageLocation = @"C:\Users\duyng\OneDrive\Desktop\FINAL\QuanLyCaPhe_Nhom4_.NET\QuanLyCaPhe_Nhom4_.NET\QuanLyCaPhe_Nhom4_.NET\QL_CaPhe\QL_CaPhe\Image\SanPham\" + name;
            Pic_SP.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void Load_SP_MaLoai()
        {
            DataTable dt = ctrl_LoaiSP.truyvan("SanPham", "LoaiSanPham", "MaLoai", cbo_LoaiSP.SelectedValue.ToString());
            dGriVi_SanPham.DataSource = dt;
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;

        }

        private void dGriVi_SanPham_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = dGriVi_SanPham[4, e.RowIndex];
            pic(cell.Value.ToString());
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = dGriVi_SanPham.Rows[e.RowIndex];

            //    txt_MaSP.Text = row.Cells[0].Value.ToString();
            //    lb_TenSP.Text = row.Cells[1].Value.ToString();
            //    txt_MoTaSP.Text = row.Cells[2].Value.ToString();
            //    txt_SoLuongSP.Text = row.Cells[3].Value.ToString();
            //    txt_GiaSP.Text = row.Cells[5].Value.ToString();
            //    txt_LoaiSP.Text = row.Cells[6].Value.ToString();
            //    cbo_NCC.Text = row.Cells[7].Value.ToString();


            //}


        }

        private void btn_ThemSP_Click(object sender, EventArgs e)
        {
            try
            {
                Model_SanPham newsp = new Model_SanPham();
                newsp.MaSP = txt_MaSP.Text;
                newsp.TenSP = lb_TenSP.Text;
                newsp.MotaSP = txt_MoTaSP.Text;
                newsp.SoLuong = Convert.ToInt32(txt_SoLuongSP.Text);
                newsp.GiaSP = Convert.ToInt32(txt_GiaSP.Text);
                newsp.MaNCC = cbo_NCC.SelectedValue.ToString();
                newsp.MaLoai = cbo_LoaiSP.SelectedValue.ToString();
                
                if (sp.check_Trungma(newsp.MaSP, table) == 1)
                {
                    MessageBox.Show("Trùng mã");
                }
                sp.insert(newsp, table);
                MessageBox.Show("Thành công");
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void btn_XoaSP_Click(object sender, EventArgs e)
        {
            try
            {
                sp.delete("SanPham", txt_MaSP.Text);
                MessageBox.Show("Thành công");
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void btn_SuaSP_Click(object sender, EventArgs e)
        {
            try
            {
                Model_SanPham newsp = new Model_SanPham();
                newsp.MaSP = txt_MaSP.Text;
                newsp.TenSP = lb_TenSP.Text;
                newsp.MotaSP = txt_MoTaSP.Text;
                newsp.SoLuong = int.Parse(txt_SoLuongSP.Text);
                newsp.GiaSP = int.Parse(txt_GiaSP.Text);

                DataRow dr = sp.edit(table,newsp);
                MessageBox.Show("Sửa thông tin thành công");
            }
            catch
            {
                MessageBox.Show("Sửa thông tin thất bại");
            }
        }


        private void btn_TimKiemSP_Click(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "TENSP", "*" + txt_TimKiemSP.Text + "*");
            (dGriVi_SanPham.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            Reset_Load();
        }

        private void cbo_LoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_SP_MaLoai();
        }



        private void btn_LuuSP_Click(object sender, EventArgs e)
        {
            
        }



    }
}
