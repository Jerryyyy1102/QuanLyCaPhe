using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CaPhe.DataAccess.Model
{
    class Model_ChiTietPN
    {
        private string maPN, maSP;

        public string MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }

        public string MaPN
        {
            get { return maPN; }
            set { maPN = value; }
        }
        private int soLuong, giaNhap, thanhTien;

        public int ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }

        public int GiaNhap
        {
            get { return giaNhap; }
            set { giaNhap = value; }
        }

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        public Model_ChiTietPN(string maPN,string maSP,int soLuong,int giaNhap,int thanhTien)
        {
            this.maPN = maPN;
            this.maSP = maSP;
            this.soLuong = soLuong;
            this.giaNhap = giaNhap;
            this.thanhTien = thanhTien;
        }
        public Model_ChiTietPN()
        {

        }
    }
}
