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
using QL_CaPhe.DataAccess.Control;
using QL_CaPhe.DataAccess.Model;

namespace QL_CaPhe.UsersControl
{
    public partial class UC_NhanVien : UserControl
    {
        DataColumn[] key = new DataColumn[1];
        Control_NhanVien nv = new Control_NhanVien();
        string table = "NhanVien";
        public UC_NhanVien()
        {
            InitializeComponent();

            
        }
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }


        #region Load datagridview
        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            AddHeader();
            DTG_Load();
            Databinding(nv.Ds.Tables[table]);
        }
        void AddHeader()
        {
            dGriVi_NhanVien.Columns.Clear();
            dGriVi_NhanVien.Columns.Add("MaNV", "Mã Nhân Viên");
            dGriVi_NhanVien.Columns[0].DataPropertyName = "MaNV";
            dGriVi_NhanVien.Columns.Add("TenNV", "Tên Nhân Viên");
            dGriVi_NhanVien.Columns[1].DataPropertyName = "TenNV";
            dGriVi_NhanVien.Columns.Add("GioiTinh", "Gioi Tính");
            dGriVi_NhanVien.Columns[2].DataPropertyName = "GioiTinh";
            dGriVi_NhanVien.Columns.Add("CMND1", "CMND");
            dGriVi_NhanVien.Columns[3].DataPropertyName = "CMND";
            dGriVi_NhanVien.Columns.Add("NgaySinh", "Ngày Sinh");
            dGriVi_NhanVien.Columns[4].DataPropertyName = "NgaySinh";
            dGriVi_NhanVien.Columns.Add("SDT1", "SDT");
            dGriVi_NhanVien.Columns[5].DataPropertyName = "SDT";
            dGriVi_NhanVien.Columns.Add("Email", "Email");
            dGriVi_NhanVien.Columns[6].DataPropertyName = "Email";
            dGriVi_NhanVien.Columns.Add("DiaChi", "Địa Chỉ");
            dGriVi_NhanVien.Columns[7].DataPropertyName = "DiaChi";
            dGriVi_NhanVien.Columns.Add("NgayVaoLam", "Ngày Vào Làm");
            dGriVi_NhanVien.Columns[8].DataPropertyName = "NgayVaoLam";
            dGriVi_NhanVien.Columns.Add("MaCV", "Mã chức vụ");
            dGriVi_NhanVien.Columns[9].DataPropertyName = "MaChucVu";
            dGriVi_NhanVien.Columns.Add("Hinhanh", "Hình ảnh");
            dGriVi_NhanVien.Columns[10].DataPropertyName = "HinhAnh";

        }
        public void Databinding(DataTable pDT)
        {
            txt_CMND.DataBindings.Clear();
            txt_DiaChi.DataBindings.Clear();
            txt_Email.DataBindings.Clear();
            txt_MaNV.DataBindings.Clear();
            txt_NgaySinh.DataBindings.Clear();
            txt_NgayThamGia.DataBindings.Clear();
            txt_SDT.DataBindings.Clear();
            txt_TenNhanVien.DataBindings.Clear();
            btn_ChucVu.DataBindings.Clear();
            GrB_GioiTinh.DataBindings.Clear();


            txt_CMND.DataBindings.Add("Text", pDT, "CMND");
            txt_DiaChi.DataBindings.Add("Text", pDT, "DiaChi");
            txt_Email.DataBindings.Add("Text", pDT, "Email");
            txt_MaNV.DataBindings.Add("Text", pDT, "MaNV");
            txt_NgaySinh.DataBindings.Add("Text", pDT, "NgaySinh");
            txt_NgayThamGia.DataBindings.Add("Text", pDT, "NgayVaoLam");
            txt_SDT.DataBindings.Add("Text", pDT, "SDT");
            txt_TenNhanVien.DataBindings.Add("Text", pDT, "TenNV");
            btn_ChucVu.DataBindings.Add("Text", pDT, "MaChucVu");

        }
        public void DTG_Load()
        {
            DataTable dtnv = nv.select(table);
            dGriVi_NhanVien.DataSource = dtnv;
            key[0] = dtnv.Columns[0];
            dtnv.PrimaryKey = key;
        }

        void pic(string name)
        {

            pB_NV.ImageLocation = @"C:\Onedrive\Share\QuanLyCaPhe_Nhom4_.NET\QuanLyCaPhe_Nhom4_.NET\QuanLyCaPhe_Nhom4_.NET\QL_CaPhe\QL_CaPhe\Image\NhanVien\" + name;
            pB_NV.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void dGriVi_NhanVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //DataGridViewCell cell = dGriVi_NhanVien[10, e.RowIndex];

            //pic(cell.Value.ToString());
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGriVi_NhanVien.Rows[e.RowIndex];
                if (row.Cells[2].Value.ToString() == "Nam")
                    chkb_Nam.Checked = true;
                else
                    chkb_Nam.Checked = false;
                if (row.Cells[2].Value.ToString() == "Nữ")
                    chkb_Nu.Checked = true;
                else
                    chkb_Nu.Checked = false;
                pic(row.Cells[10].Value.ToString());

            }
        }
        #endregion
        #region Thêm,xóa,sửa,reset,lưu
        private void btn_ThemNV_Click(object sender, EventArgs e)
        {
            try
            {
                Model_NhanVien newnv = new Model_NhanVien();
                newnv.MaNV = txt_MaNV.Text;
                if (chkb_Nam.Checked == true && chkb_Nu.Checked == false)
                {
                    newnv.GioiTinh = chkb_Nam.Text;
                }
                else
                {
                    newnv.GioiTinh = chkb_Nu.Text;
                }
                newnv.MaCV = btn_ChucVu.Text;
                newnv.NgaySinh = DateTime.Parse(txt_NgaySinh.Text);
                newnv.TenNV = txt_TenNhanVien.Text;
                newnv.SDT1 = txt_SDT.Text;
                newnv.Email = txt_Email.Text;
                newnv.DiaChi = txt_DiaChi.Text;
                newnv.CMND1 = txt_CMND.Text;
                if (nv.check_Key(newnv.MaNV, table) == 1)
                {
                    MessageBox.Show("Trùng mã");
                }
                nv.insert(newnv, table);
                MessageBox.Show("Thành công");

            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        public void Reset_Load()
        {
            AddHeader();
            DTG_Load();
            Databinding(nv.Ds.Tables[table]);
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            Reset_Load();
        }
        private void btn_XoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0);
                if (r == DialogResult.Yes)
                {
                    if (!nv.delete("NHANVIEN", txt_MaNV.Text))
                        MessageBox.Show("Có khóa ngoại !");
                    else
                        MessageBox.Show("Xóa nhân viên thành công !", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void btn_SuaNV_Click(object sender, EventArgs e)
        {
            try
            {
                Model_NhanVien editnv = new Model_NhanVien();
                editnv.MaNV = txt_MaNV.Text;
                editnv.CMND1=txt_CMND.Text;
                editnv.DiaChi=txt_DiaChi.Text;
                editnv.Email=txt_Email.Text;
                editnv.SDT1=txt_SDT.Text;
                editnv.TenNV=txt_TenNhanVien.Text;
                editnv.MaCV=btn_ChucVu.Text;
                if (chkb_Nam.Checked == true && chkb_Nu.Checked == false)
                {
                   editnv.GioiTinh= chkb_Nam.Text;
                }
                else
                {
                    editnv.GioiTinh=chkb_Nu.Text ;
                }

                DataRow dr=nv.edit("NHANVIEN",  editnv);
                MessageBox.Show("Thành công");
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }
        #endregion

        

       
    }
}