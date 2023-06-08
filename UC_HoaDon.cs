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
using System.Data.SqlClient;
using QL_CaPhe.DataAccess.Model;
using QL_CaPhe.DataAccess.Control;
using QL_CaPhe.Presentation;
namespace QL_CaPhe.UsersControl
{
    public partial class UC_HoaDon : UserControl
    {
        #region Biến toàn cục
        DataColumn[] key = new DataColumn[1];
        Control_HoaDon hd = new Control_HoaDon();
        Control_HoaDon ctr_HD = new Control_HoaDon();
        public UC_HoaDon()
        {
            InitializeComponent();
        }
        string tb_HD = "HoaDon";
        #endregion

        #region Data của bảng hóa đơn

        #region Load Datagridview
        public void AddHeaderHoaDon()
        {
            DGV_HoaDon.Columns.Clear();
            DGV_HoaDon.Columns.Add("MaHD", "Mã hóa đơn");
            DGV_HoaDon.Columns[0].DataPropertyName = "MaHD";
            DGV_HoaDon.Columns.Add("NgayLap", "Ngày lập");
            DGV_HoaDon.Columns[1].DataPropertyName = "NgayLap";
            DGV_HoaDon.Columns.Add("HinhThuc", "Hình thức");
            DGV_HoaDon.Columns[2].DataPropertyName = "HinhThuc";
            DGV_HoaDon.Columns.Add("TienGiam", "Tiền giảm");
            DGV_HoaDon.Columns[3].DataPropertyName = "TienGiam";
            DGV_HoaDon.Columns.Add("TongTien", "Tổng tiền");
            DGV_HoaDon.Columns[4].DataPropertyName = "TongTien";
            DGV_HoaDon.Columns.Add("MaNV", "Mã nhân viên");
            DGV_HoaDon.Columns[5].DataPropertyName = "MaNV";
            DGV_HoaDon.Columns.Add("MaKH", "Mã khách hàng");
            DGV_HoaDon.Columns[6].DataPropertyName = "MaKH";
            DGV_HoaDon.Columns.Add("MaVouncher", "Mã Vouncher");
            DGV_HoaDon.Columns[7].DataPropertyName = "MaVouncher";
        }
        
        public void DatabindingHD(DataTable pDT)
        {
            txt_HinhThuc_HD.DataBindings.Clear();
            txt_MaHoaDon_HD.DataBindings.Clear();
            cb_KH_HD.DataBindings.Clear();
            cb_NhanVien_HD.DataBindings.Clear();
            txt_MaVouncher_HD.DataBindings.Clear();
            txt_NgayLap_HD.DataBindings.Clear();
            txt_TienGiam_HD.DataBindings.Clear();
            txt_TongTien_HD.DataBindings.Clear();

            txt_HinhThuc_HD.DataBindings.Add("Text", pDT, "HinhThuc");
            txt_MaHoaDon_HD.DataBindings.Add("Text", pDT, "MaHD");
            cb_KH_HD.DataBindings.Add("Text", pDT, "MaKH");
            cb_NhanVien_HD.DataBindings.Add("Text", pDT, "MaNV");
            txt_MaVouncher_HD.DataBindings.Add("Text", pDT, "MaVouncher");
            txt_NgayLap_HD.DataBindings.Add("Text", pDT, "NgayLap");
            txt_TienGiam_HD.DataBindings.Add("Text", pDT, "TienGiam");
            txt_TongTien_HD.DataBindings.Add("Text", pDT, "TongTien");

        }
        private void DGV_HoaDon_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGV_HoaDon.Rows[e.RowIndex];
                txt_MaHoaDon_HD.Text = row.Cells[0].Value.ToString();
                txt_NgayLap_HD.Text = row.Cells[1].Value.ToString();
                txt_HinhThuc_HD.Text = row.Cells[2].Value.ToString();
                txt_TienGiam_HD.Text = row.Cells[3].Value.ToString();
                txt_TongTien_HD.Text = row.Cells[4].Value.ToString();
                cb_NhanVien_HD.Text = row.Cells[5].Value.ToString();
                cb_KH_HD.Text = row.Cells[6].Value.ToString();
                txt_MaVouncher_HD.Text = row.Cells[7].Value.ToString();
            }
        }
        void load_dataGV_DSHD()
        {
            DataTable dthd = hd.select(tb_HD);
            DGV_HoaDon.DataSource = dthd;
            key[0] = dthd.Columns[0];
            dthd.PrimaryKey = key;
        }
        void load_AllHD()
        {
            AddHeaderHoaDon();
            load_dataGV_DSHD();
            DatabindingHD(hd.Ds.Tables[tb_HD]);
        }
        public void Reset_Load()
        {
            AddHeaderHoaDon();
            load_dataGV_DSHD();
            DatabindingHD(hd.Ds.Tables[tb_HD]);
        }
        #endregion

        #region Load Combobox
        void load_cbBoxMaNV()
        {
            DataTable dt = hd.select("NhanVien");
            cb_NhanVien_HD.DataSource = dt;
            cb_NhanVien_HD.DisplayMember = "MaNV";
            cb_NhanVien_HD.ValueMember = "MaNV";

        }
        void load_cbBoxMaKH()
        {
            DataTable dt = hd.select("KhachHang");
            cb_KH_HD.DataSource = dt;
            cb_KH_HD.DisplayMember = "MaKH";
            cb_KH_HD.ValueMember = "MaKH";
        }
        #endregion

        #region Load From, Thêm, xóa sửa
        private void UC_HoaDon_Load(object sender, EventArgs e)
        {
            load_cbBoxMaNV();
            load_cbBoxMaKH();
            load_AllHD();
        }     
        private void btn_Them_HD_Click(object sender, EventArgs e)
        {
            try
            {
                Model_HoaDon newhd = new Model_HoaDon();
                newhd.MaHD = txt_MaHoaDon_HD.Text;
                newhd.NgayLap = txt_NgayLap_HD.Text;
                newhd.HinhThuc = txt_HinhThuc_HD.Text;
                newhd.TienGiam = Convert.ToInt32(txt_TienGiam_HD.Text);
                newhd.TongTien = Convert.ToInt32(txt_TongTien_HD.Text);
                newhd.MaNV = cb_NhanVien_HD.Text;
                newhd.MaKH = cb_KH_HD.Text;
                newhd.MaVouncher = txt_MaVouncher_HD.Text;
                if (hd.check_Trungma(newhd.MaHD, tb_HD) == 1)
                {
                    MessageBox.Show("Trùng mã");
                }
                hd.insert(newhd, tb_HD);
                MessageBox.Show("Thành công");
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }
        private void btn_Luu_HD_Click(object sender, EventArgs e)
        {
            Reset_Load();
        }
        private void btn_Xoa_HD_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sql = new SqlConnection(@"Data Source=YOONA\SQLEXPRESS;Initial Catalog=Qly_CaPhe;Integrated Security=True");
                string deleteString;
                deleteString = "delete HoaDon Where MaHD= '" + txt_MaHoaDon_HD.Text + "'";




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
        private void btn_Sua_HD_Click(object sender, EventArgs e)
        {
            try
            {
                Model_HoaDon edithd = new Model_HoaDon();
                edithd.MaHD = txt_MaHoaDon_HD.Text;
                edithd.NgayLap = txt_NgayLap_HD.Text;
                edithd.HinhThuc = txt_HinhThuc_HD.Text;
                edithd.TienGiam = Convert.ToInt32(txt_TienGiam_HD.Text);
                edithd.TongTien = Convert.ToInt32(txt_TongTien_HD.Text);
                edithd.MaNV = cb_NhanVien_HD.Text;
                edithd.MaKH = cb_KH_HD.Text;
                edithd.MaVouncher = txt_MaVouncher_HD.Text;
                MessageBox.Show("Thành công");
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }
        #endregion

        private void btn_CTHD_Click(object sender, EventArgs e)
        {
            fr_CTHoaDon fr = new fr_CTHoaDon();
            fr.ShowDialog();
        }
        #endregion

        private void btn_TimKiemHD_Click(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "MaKH", "*" + txt_TimKiemHD.Text + "*");
            (DGV_HoaDon.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }     
    }
}
