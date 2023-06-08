using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CaPhe.DataAccess.Model
{
    class Model_KhuyenMai
    {
        string maVouncher, ngayBD, ngayKT;

        public string NgayKT
        {
            get { return ngayKT; }
            set { ngayKT = value; }
        }

        public string NgayBD
        {
            get { return ngayBD; }
            set { ngayBD = value; }
        }

        public string MaVouncher
        {
            get { return maVouncher; }
            set { maVouncher = value; }
        }
        int giaTriToiThieu, khuyenMaiToiDa, soLuotSD;

        public int SoLuotSD
        {
            get { return soLuotSD; }
            set { soLuotSD = value; }
        }

        public int KhuyenMaiToiDa
        {
            get { return khuyenMaiToiDa; }
            set { khuyenMaiToiDa = value; }
        }

        public int GiaTriToiThieu
        {
            get { return giaTriToiThieu; }
            set { giaTriToiThieu = value; }
        }
        public Model_KhuyenMai(string maVouncher,string ngayBD,string ngayKT,int giaTriToiThieu,int khuyenMaiToiDa,int soLuotSD)
        {
            this.maVouncher = maVouncher;
            this.ngayBD = ngayBD;
            this.ngayKT = ngayKT;
            this.giaTriToiThieu = giaTriToiThieu;
            this.khuyenMaiToiDa = khuyenMaiToiDa;
            this.soLuotSD = soLuotSD;
        }
        public Model_KhuyenMai()
        {

        }

    }
}
