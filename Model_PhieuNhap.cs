using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CaPhe.DataAccess.Model
{
    class Model_PhieuNhap
    {
        private string maPN, ghiChu, maNCC, maChucVu;

        public string MaChucVu
        {
            get { return maChucVu; }
            set { maChucVu = value; }
        }

        public string MaNCC
        {
            get { return maNCC; }
            set { maNCC = value; }
        }

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }

        public string MaPN
        {
            get { return maPN; }
            set { maPN = value; }
        }
        private int tienNhap;

        public int TienNhap
        {
            get { return tienNhap; }
            set { tienNhap = value; }
        }
        public Model_PhieuNhap(string maPN,string ghiChu, string maNCC,string maChucVu,int tienNhap)
        {
            this.maPN = maPN;
            this.ghiChu = ghiChu;
            this.maNCC = maNCC;
            this.maChucVu = maChucVu;
            this.tienNhap = tienNhap;
        }
        public Model_PhieuNhap()
        {

        }
    }
}
