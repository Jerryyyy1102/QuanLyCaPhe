using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_CaPhe.DataAccess.Control;
namespace QL_CaPhe.DataAccess.Model
{
    class Model_CTHoaDon
    {
        public string MaHD { get; set; }
        public string MaSP { get; set; }
        public int SoLuong { get; set; }
        public int ThanhTien { get; set; }
        public int DonGia { get; set; }
        public Model_CTHoaDon() { }
        public Model_CTHoaDon(string maHD, string maSP, int soLuong, int thanhTien, int donGia)
        {
            this.MaHD = maHD;
            this.MaSP = maHD;
            this.SoLuong = soLuong;
            this.ThanhTien = thanhTien;
            this.DonGia = donGia;
        }
    }
}
