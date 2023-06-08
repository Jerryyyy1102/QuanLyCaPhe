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
using System.Runtime.InteropServices;
using System.Data.SqlClient;
namespace QL_CaPhe.UsersControl
{
    public partial class UC_NhapXuat : UserControl
    {
        DataColumn[] key = new DataColumn[1];
        Control_PhieuNhap pn = new Control_PhieuNhap();
        Control_PhieuNhap ncc = new Control_PhieuNhap();
        Control_ChiTietPN ctpn = new Control_ChiTietPN();
        Control_SanPham sp = new Control_SanPham();
        Control_ChucVu cv = new Control_ChucVu();
        ConSQL connect = new ConSQL();
        string table1 = "PhieuNhap";
        string table2 = "CTPhieuNhap";
        public UC_NhapXuat()
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

        void AddHeader()
        {
            DGV_PhieuNhap.Columns.Clear();

            DGV_PhieuNhap.Columns.Add("MaPN", "Mã Phiếu Nhập");
            DGV_PhieuNhap.Columns[0].DataPropertyName = "MaPN";
            DGV_PhieuNhap.Columns.Add("TienNhap", "Tiền Nhập");
            DGV_PhieuNhap.Columns[1].DataPropertyName = "TienNhap";
            DGV_PhieuNhap.Columns.Add("GhiChu", "Ghi Chú");
            DGV_PhieuNhap.Columns[2].DataPropertyName = "GhiChu";
            DGV_PhieuNhap.Columns.Add("MaNCC", "Mã Nhà Cung Cấp");
            DGV_PhieuNhap.Columns[3].DataPropertyName = "MaNCC";
            DGV_PhieuNhap.Columns.Add("MaChucVu", "Mã Chức Vụ");
            DGV_PhieuNhap.Columns[4].DataPropertyName = "MaChucVu";

            DGV_CTPhieuNhap.Columns.Clear();

            DGV_CTPhieuNhap.Columns.Add("MaPN", "Mã Phiếu Nhập");
            DGV_CTPhieuNhap.Columns[0].DataPropertyName = "MaPN";
            DGV_CTPhieuNhap.Columns.Add("MaSP", "Mã Sản Phẩm");
            DGV_CTPhieuNhap.Columns[1].DataPropertyName = "MaSp";
            DGV_CTPhieuNhap.Columns.Add("SoLuong", "Số Lượng");
            DGV_CTPhieuNhap.Columns[2].DataPropertyName = "SoLuong";
            DGV_CTPhieuNhap.Columns.Add("GiaNhap", "Giá Nhập");
            DGV_CTPhieuNhap.Columns[3].DataPropertyName = "GiaNhap";
            DGV_CTPhieuNhap.Columns.Add("ThanhTien", "Thành Tiền");
            DGV_CTPhieuNhap.Columns[4].DataPropertyName = "ThanhTien";

        }

        public void Databinding(DataTable pDT)
        {







            cbo_MaPN.DataBindings.Clear();
            cbo_MaSP.DataBindings.Clear();
            txt_SoLuong.DataBindings.Clear();
            txt_GiaNhap.DataBindings.Clear();
            txt_ThanhTien.DataBindings.Clear();


            cbo_MaPN.DataBindings.Add("Text", pDT, "MaPN");
            cbo_MaSP.DataBindings.Add("Text", pDT, "MaSP");
            txt_SoLuong.DataBindings.Add("Text", pDT, "SoLuong");
            txt_GiaNhap.DataBindings.Add("Text", pDT, "GiaNhap");
            txt_ThanhTien.DataBindings.Add("Text", pDT, "ThanhTien");


        }
        public void Databinding2(DataTable pDT)
        {
            txt_MaPhieuNhap_PN.DataBindings.Clear();
            txt_TienNhap.DataBindings.Clear();
            txt_GhiChu.DataBindings.Clear();
            cbo_MaCV.DataBindings.Clear();
            cbo_NhaCungCap.DataBindings.Clear();



            txt_MaPhieuNhap_PN.DataBindings.Add("Text", pDT, "MaPN");
            txt_TienNhap.DataBindings.Add("Text", pDT, "TienNhap");
            txt_GhiChu.DataBindings.Add("Text", pDT, "GhiChu");
            cbo_NhaCungCap.DataBindings.Add("Text", pDT, "MaNCC");
            cbo_MaCV.DataBindings.Add("Text", pDT, "MaChucVu");





        }

        public void DTG_PhieuNhap_Load()
        {

            DataTable dtpn = pn.select("PhieuNhap");

            DGV_PhieuNhap.DataSource = dtpn;
            Databinding2(dtpn);
            key[0] = dtpn.Columns[0];
            dtpn.PrimaryKey = key;
        }
        public void DTG_CTPhieuNhap_Load()
        {

            DataTable dtctpn = ctpn.select("CTPhieuNhap");

            DGV_CTPhieuNhap.DataSource = dtctpn;
            Databinding(dtctpn);
            key[0] = dtctpn.Columns[0];
            dtctpn.PrimaryKey = key;
        }


        private void UC_NhapXuat_Load(object sender, EventArgs e)
        {
            AddHeader();

            DTG_PhieuNhap_Load();
            DTG_CTPhieuNhap_Load();


            cbo_NCC_Load();
            cbo_MaCV_Load();
            cbo_MaSP_Load();
            cbo_MaPN_Load();

        }
        public void cbo_NCC_Load()
        {
            DataTable dt = ncc.select("PhieuNhap");
            cbo_NhaCungCap.DataSource = dt;
            cbo_NhaCungCap.DisplayMember = "MaNCC";
            cbo_NhaCungCap.ValueMember = "MaNCC";
        }
        public void cbo_MaCV_Load()
        {
            DataTable dt = cv.select("ChucVu");
            cbo_MaCV.DataSource = dt;
            cbo_MaCV.DisplayMember = "MaChucVu";
            cbo_MaCV.ValueMember = "MaChucVu";
        }
        public void cbo_MaSP_Load()
        {
            DataTable dt = sp.select("SanPham");
            cbo_MaSP.DataSource = dt;
            cbo_MaSP.DisplayMember = "MaSP";
            cbo_MaSP.ValueMember = "MaSP";
        }
        public void cbo_MaPN_Load()
        {
            DataTable dt = ctpn.select("PhieuNhap");
            cbo_MaPN.DataSource = dt;
            cbo_MaPN.DisplayMember = "MaPN";
            cbo_MaPN.ValueMember = "MaPN";
        }
        public void Load_PN_NCC()
        {
            DataTable dt = ncc.truyvan("PhieuNhap", "NhaCungCap", "MaNCC", cbo_NhaCungCap.SelectedValue.ToString());
            DGV_PhieuNhap.DataSource = dt;
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
        }
        private void DGV_PhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = DGV_CTPhieuNhap.Rows[e.RowIndex];
            txt_MaPhieuNhap_PN.Text = row.Cells[0].Value.ToString();
            txt_TienNhap.Text = row.Cells[1].Value.ToString();
            txt_GhiChu.Text = row.Cells[2].Value.ToString();
            cbo_NhaCungCap.SelectedItem = row.Cells[3].Value.ToString();
            cbo_MaCV.SelectedItem = row.Cells[4].Value.ToString();

        }

        private void cbo_NhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DGV_CTPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = DGV_CTPhieuNhap.Rows[e.RowIndex];
            cbo_MaPN.SelectedItem = row.Cells[0].Value.ToString();
            cbo_MaSP.SelectedItem = row.Cells[1].Value.ToString();
            txt_SoLuong.Text = row.Cells[2].Value.ToString();
            txt_GiaNhap.Text = row.Cells[3].Value.ToString();

            txt_ThanhTien.Text = row.Cells[4].Value.ToString();

        }

        private void btn_Them_PN_Click(object sender, EventArgs e)
        {
            try
            {
                Model_PhieuNhap newpn = new Model_PhieuNhap();
                newpn.MaPN = txt_MaPhieuNhap_PN.Text;
                newpn.TienNhap = int.Parse(txt_TienNhap.Text);
                newpn.GhiChu = txt_GhiChu.Text;
                newpn.MaNCC = cbo_NhaCungCap.SelectedValue.ToString();
                newpn.MaChucVu = cbo_MaCV.SelectedValue.ToString();


                if (pn.check_Key(newpn.MaPN, table1) == 1)
                {
                    MessageBox.Show("Trùng mã");
                }
                pn.insert(newpn, table1);
                MessageBox.Show("Thành công");
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void cbo_NhaCungCap_SelectedValueChanged(object sender, EventArgs e)
        {
            Load_PN_NCC();
        }

        private void btn_Them_CTPN_Click(object sender, EventArgs e)
        {
            try
            {
                Model_ChiTietPN newctpn = new Model_ChiTietPN();
                newctpn.MaPN = cbo_MaPN.SelectedValue.ToString();
                newctpn.MaSP = cbo_MaSP.SelectedValue.ToString();
                newctpn.SoLuong = int.Parse(txt_SoLuong.Text);
                newctpn.GiaNhap = int.Parse(txt_GiaNhap.Text);
                newctpn.ThanhTien = int.Parse(txt_ThanhTien.Text);

                ctpn.insert(newctpn, "CTPhieuNhap");
                MessageBox.Show("Thành công");
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void btn_Xoa_PN_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sql = new SqlConnection("Data Source=YOONA\\SQLEXPRESS;Initial Catalog=Qly_CaPhe;Integrated Security=True");
                string deleteString, deleteString2;
                deleteString = "delete CTPhieuNhap Where MaPN='" + txt_MaPhieuNhap_PN.Text + "'";
                deleteString2 = "delete PhieuNhap Where MaPN='" + txt_MaPhieuNhap_PN.Text + "'";



                sql.Open();

                SqlCommand cmd = new SqlCommand(deleteString, sql);
                SqlCommand cmd2 = new SqlCommand(deleteString2, sql);
                cmd.CommandType = CommandType.Text;
                cmd2.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                sql.Close();



                MessageBox.Show("Thành cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void btn_TimKiem_PN_Click(object sender, EventArgs e)
        {
            DataTable dt = pn.timkiem("PhieuNhap", "MaPN", txt_TimKiem_PN.Text);
            DGV_PhieuNhap.DataSource = dt;
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
        }

        private void btn_Xoa_CTPN_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sql = new SqlConnection(@"Data Source=YOONA\SQLEXPRESS;Initial Catalog=Qly_CaPhe;Integrated Security=True");
                string deleteString;
                deleteString = "delete CTPhieuNhap Where MaPN='" + cbo_MaPN.SelectedValue.ToString() + "' and MaSP='" + cbo_MaSP.SelectedValue.ToString() + "'";




                sql.Open();

                SqlCommand cmd = new SqlCommand(deleteString, sql);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                sql.Close();



                MessageBox.Show("Thành cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void btn_TimKiem_CTPN_Click(object sender, EventArgs e)
        {
            DataTable dt = ctpn.timkiem("CTPhieuNhap", "MaPN", txt_TimKiem_CTPN.Text);
            DGV_CTPhieuNhap.DataSource = dt;
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
        }
        private void Reset_Load()
        {
            AddHeader();
            DTG_CTPhieuNhap_Load();
            Databinding(ctpn.Ds.Tables[table2]);
        }
        private void Reset_Load2()
        {
            AddHeader();
            DTG_PhieuNhap_Load();
            Databinding2(pn.Ds.Tables[table1]);
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            Reset_Load();
        }

        private void buttonRounded1_Click(object sender, EventArgs e)
        {
            Reset_Load2();
        }

    }
}
