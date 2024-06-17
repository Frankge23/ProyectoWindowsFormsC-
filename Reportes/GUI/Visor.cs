using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes.GUI
{
    public partial class Visor : Form
    {
        private ReportClass oReporteActual;
        public Visor()
        {
            InitializeComponent();
        }
        public void GenerarReporte(ReportClass oReporte, DataTable datos, string inicial, string hasta)
        {
            oReporteActual = oReporte;
            oReporte.SetDataSource(datos);
            oReporte.SetParameterValue("Inicial", inicial);
            oReporte.SetParameterValue("hasta", hasta);
        }
        private void crvVisor_Load(object sender, EventArgs e)
        {
            crvVisor.ReportSource = oReporteActual;
        }
    }
}
