using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_CaPhe.CrystalReport;
using CrystalDecisions.Shared;

namespace QL_CaPhe.UsersControl
{
    public partial class UC_ThongKe : UserControl
    {
        public UC_ThongKe()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            CrystalReport_DoanhThu rpt = new CrystalReport_DoanhThu();

            ParameterValues Ngay1 = new ParameterValues();
            ParameterValues Ngay2 = new ParameterValues();

            ParameterDiscreteValue disNgay1 = new ParameterDiscreteValue();
            ParameterDiscreteValue disNgay2 = new ParameterDiscreteValue();

            disNgay1.Value = dtp_TuNgay.Value;
            disNgay2.Value = dtp_DenNgay.Value;
            Ngay1.Add(disNgay1);
            Ngay2.Add(disNgay2);

            rpt.DataDefinition.ParameterFields[0].ApplyCurrentValues(Ngay1);
            rpt.DataDefinition.ParameterFields[1].ApplyCurrentValues(Ngay2);

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();

        }
    }
}
