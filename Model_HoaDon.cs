using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CaPhe.DataAccess.Model
{
    class Model_HoaDon
    {
        public string HinhThuc { get; set; }
        public string MaHD { get; set; }
        public string MaNV { get; set; }
        public string MaVouncher { get; set; }
        public string NgayLap { get; set; }
        public string MaKH { get; set; }
        public int TienGiam { get; set; }
        public int TongTien { get; set; }
        public Model_HoaDon() { }
        public Model_HoaDon(string maHD, string maVouncher, string maKH, string ngayLap, string hinhThuc, string maNV, int tongTien, int tienGiam)
        {
            this.MaHD = maHD;
            this.MaVouncher = maVouncher;
            this.NgayLap = ngayLap;
            this.HinhThuc = hinhThuc;
            this.MaNV = maNV;
            this.TongTien = tongTien;
            this.TienGiam = tienGiam;
            this.MaKH = maKH;
        }
    }
}
