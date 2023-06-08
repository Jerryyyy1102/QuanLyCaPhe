using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CaPhe.DataAccess.Model
{
    class Model_SanPham
    {
        private string maSP, tenSP, motaSP, hinhAnh, maLoai, tenLoai, maNCC;

        public string TenLoai
        {
            get { return tenLoai; }
            set { tenLoai = value; }
        }

        public string MaLoai
        {
            get { return maLoai; }
            set { maLoai = value; }
        }

        public string MaNCC
        {
            get { return maNCC; }
            set { maNCC = value; }
        }

        public string HinhAnh
        {
            get { return hinhAnh; }
            set { hinhAnh = value; }
        }

        public string MotaSP
        {
            get { return motaSP; }
            set { motaSP = value; }
        }

        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }

        public string MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }
        private int soLuong, giaSP;

        public int GiaSP
        {
            get { return giaSP; }
            set { giaSP = value; }
        }

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public Model_SanPham(string maSP, string tenSP, string motaSP, string hinhAnh, int soLuong, int giaSP, string maLoai, string maNCC, string tenLoai)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.motaSP = motaSP;
            this.hinhAnh = hinhAnh;
            this.soLuong = soLuong;
            this.giaSP = giaSP;
            this.maLoai = maLoai;
            this.maNCC = maNCC;
            this.tenLoai = tenLoai;
        }
        public Model_SanPham()
        { }
    }
}
