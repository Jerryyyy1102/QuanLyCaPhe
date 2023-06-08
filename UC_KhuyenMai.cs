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
namespace QL_CaPhe.UsersControl
{
    public partial class UC_KhuyenMai : UserControl
    {
        DataColumn[] key = new DataColumn[1];
        Control_KhuyenMai km = new Control_KhuyenMai();
        ConSQL connect = new ConSQL();

        string table = "Vouncher";
        public UC_KhuyenMai()
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
            dGriVi_KM.Columns.Clear();
            dGriVi_KM.Columns.Add("MaVouncher", "Mã Khuyến Mãi");
            dGriVi_KM.Columns[0].DataPropertyName = "MaVouncher";
            dGriVi_KM.Columns.Add("NgayBD", "Ngày Bắt Đầu");
            dGriVi_KM.Columns[1].DataPropertyName = "NgayBD";
            dGriVi_KM.Columns.Add("NgayKT", "Ngày Kết Thúc");
            dGriVi_KM.Columns[2].DataPropertyName = "NgayKT";
            dGriVi_KM.Columns.Add("GiaTriToiThieu", "Giá Trị Tối Thiểu");
            dGriVi_KM.Columns[3].DataPropertyName = "GiaTriToiThieu";
            dGriVi_KM.Columns.Add("KhuyenMaiToiDa", "Khuyến Mãi Tối Đa");
            dGriVi_KM.Columns[4].DataPropertyName = "KhuyenMaiToiDa";
            dGriVi_KM.Columns.Add("SoLuotSD", "Số Lượt Sử Dụng");
            dGriVi_KM.Columns[5].DataPropertyName = "SoLuotSD";



        }
        public void Databinding(DataTable pDT)
        {
           
         
          
            txt_GiaTriToiThieu.DataBindings.Clear();
            txt_KMTDa.DataBindings.Clear();
            txt_MaKM.DataBindings.Clear();
            txt_NgayBatDau.DataBindings.Clear();
            txt_NgayKetThuc.DataBindings.Clear();
            txt_SoLuotDungKM.DataBindings.Clear();

            txt_GiaTriToiThieu.DataBindings.Add("Text", pDT, "GiaTriToiThieu");
            txt_KMTDa.DataBindings.Add("Text", pDT, "KhuyenMaiToiDa");
            txt_MaKM.DataBindings.Add("Text", pDT, "MaVouncher");
            txt_NgayBatDau.DataBindings.Add("Text", pDT, "NgayBD");
            txt_NgayKetThuc.DataBindings.Add("Text", pDT, "NgayKT");
            txt_SoLuotDungKM.DataBindings.Add("Text", pDT, "SoLuotSD");
     

        }
        public void DTG_Load()
        {
            DataTable dtnv = km.select(table);
            dGriVi_KM.DataSource = dtnv;
            key[0] = dtnv.Columns[0];
            dtnv.PrimaryKey = key;
        }

       

        private void UC_KhuyenMai_Load(object sender, EventArgs e)
        {
            AddHeader();
            DTG_Load();
            Databinding(km.Ds.Tables[table]);
            
        }

        private void dGriVi_KM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGriVi_KM.Rows[e.RowIndex];
                txt_MaKM.Text = row.Cells[0].Value.ToString();
                txt_NgayBatDau.Text = row.Cells[1].Value.ToString();
                txt_NgayKetThuc.Text = row.Cells[2].Value.ToString();
                txt_GiaTriToiThieu.Text = row.Cells[3].Value.ToString();
         
                txt_KMTDa.Text = row.Cells[4].Value.ToString();

                txt_SoLuotDungKM.Text = row.Cells[5].Value.ToString();


            }
        }

       

       

      

       

        private void btn_XoaKM_Click_1(object sender, EventArgs e)
        {
            try
            {
                km.delete("Vouncher", txt_MaKM.Text);
                MessageBox.Show("Thành công");
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void btn_ThemKM_Click_1(object sender, EventArgs e)
        {
            try
            {
                Model_KhuyenMai newkm = new Model_KhuyenMai();
                newkm.MaVouncher = txt_MaKM.Text;
                newkm.NgayBD = txt_NgayBatDau.Text;
                newkm.NgayKT = txt_NgayKetThuc.Text;
                newkm.GiaTriToiThieu = int.Parse(txt_GiaTriToiThieu.Text);
                newkm.KhuyenMaiToiDa = int.Parse(txt_KMTDa.Text);
                newkm.SoLuotSD = int.Parse(txt_SoLuotDungKM.Text);

                if (km.check_Key(newkm.MaVouncher, table) == 1)
                {
                    MessageBox.Show("Trùng mã");
                }
                km.insert(newkm, table);
                MessageBox.Show("Thành công");
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void btn_SuaKM_Click_1(object sender, EventArgs e)
        {
            try
            {
                string ma = txt_MaKM.Text;
                string ngaybd = txt_NgayBatDau.Text;
                string ngaykt = txt_NgayKetThuc.Text;
                string giatritt = txt_GiaTriToiThieu.Text;
                string KMTD = txt_KMTDa.Text;
                string soluotdungKM = txt_SoLuotDungKM.Text;
                Model_KhuyenMai editkm = new Model_KhuyenMai(txt_MaKM.Text, txt_NgayBatDau.Text, txt_NgayKetThuc.Text, int.Parse(txt_GiaTriToiThieu.Text), int.Parse(txt_KMTDa.Text), int.Parse(txt_SoLuotDungKM.Text));
                km.edit( ma,ngaybd,ngaykt,giatritt,KMTD,soluotdungKM);
                MessageBox.Show("Thành công");
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

      

        private void btn_TimKiemKM_Click_1(object sender, EventArgs e)
        {
            DataTable dt = km.timkiem("Vouncher", "MaVouncher",txt_TimKiemKM.Text);
            dGriVi_KM.DataSource = dt;
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            Reset_Load();
        }

        private void Reset_Load()
        {
            AddHeader();
            DTG_Load();
            Databinding(km.Ds.Tables[table]);
        }






    }
}