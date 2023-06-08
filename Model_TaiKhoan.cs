using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CaPhe.DataAccess.Model
{
    class Model_TaiKhoan
    {
        string maTK, tenTK, matKhau, ngayTao, maNV;

        public string TenTK
        {
            get { return tenTK; }
            set { tenTK = value; }
        }

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string NgayTao
        {
            get { return ngayTao; }
            set { ngayTao = value; }
        }

        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }

        public string MaTK
        {
            get { return maTK; }
            set { maTK = value; }
        }
        public Model_TaiKhoan(string maTK,string tenTK,string matKhau,string ngayTao,string maNV)
        {
            this.maTK = maTK;
            this.tenTK = tenTK;
            this.matKhau = matKhau;
            this.ngayTao = ngayTao;
            this.maNV = maNV;
        }
        public Model_TaiKhoan()
        {

        }

    }
}
