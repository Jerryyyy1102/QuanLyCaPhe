using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CaPhe.DataAccess.Model
{
    class Model_ChucVu
    {
        private string maCV, tenCV, moTa;

        public string MoTa
        {
            get { return moTa; }
            set { moTa = value; }
        }

        public string TenCV
        {
            get { return tenCV; }
            set { tenCV = value; }
        }

        public string MaCV
        {
            get { return maCV; }
            set { maCV = value; }
        }
        public Model_ChucVu(string maCV,string tenCV,string moTa)
        {
            this.maCV = maCV;
            this.tenCV = tenCV;
            this.moTa = moTa;
        }
        public Model_ChucVu()
        {

        }
    }
}
