using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CaPhe.DataAccess.Model
{
    class Model_NhanVien
    {
        string maNV, tenNV, gioiTinh, CMND,  SDT, email, diaChi,  maCV, hinhanh;
        DateTime ngayVaoLam, ngaySinh;

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

        public DateTime NgayVaoLam
        {
            get { return ngayVaoLam; }
            set { ngayVaoLam = value; }
        }

        public string Hinhanh
        {
            get { return hinhanh; }
            set { hinhanh = value; }
        }

        public string MaCV
        {
            get { return maCV; }
            set { maCV = value; }
        }

       

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string SDT1
        {
            get { return SDT; }
            set { SDT = value; }
        }

        

        public string CMND1
        {
            get { return CMND; }
            set { CMND = value; }
        }

        public string GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }

        public string TenNV
        {
            get { return tenNV; }
            set { tenNV = value; }
        }

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
        public Model_NhanVien()
        {

        }
        public Model_NhanVien(string maNV,string tenNV,string gioiTinh,string CMND,DateTime ngaySinh,string SDT, string email,string diaChi,DateTime ngayVaoLam,string maCV,string hinhanh)
        {
            this.maNV=maNV;
            this.tenNV=tenNV;
            this.gioiTinh=gioiTinh;
            this.CMND=CMND;
            this.SDT=SDT;
            this.email=email;
            this.diaChi=diaChi;
            this.ngaySinh=ngaySinh;
            this.NgayVaoLam = NgayVaoLam;
            this.maCV=maCV;
            this.hinhanh = hinhanh;
            
        }

    }
}
