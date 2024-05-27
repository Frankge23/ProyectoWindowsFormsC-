using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionInventarios
{
    public partial class FrmReportes : Form
    {
        CapaAccesoDatos.RepConsulta.DAL_Kardex capa = new CapaAccesoDatos.RepConsulta.DAL_Kardex();
        CapaAccesoDatos.RepConsulta.DAL_DetalleIngreso capa1 = new CapaAccesoDatos.RepConsulta.DAL_DetalleIngreso();
        CapaAccesoDatos.RepConsulta.DAL_DetalleVenta capa2 = new CapaAccesoDatos.RepConsulta.DAL_DetalleVenta();

        String inicio = "";
        String fin = "";

        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            asignarFecha();
        }

        private void asignarFecha() 
        {

            DateTime fechaInicio = dtpInicio.Value;
            DateTime fechaFin = dtpFin.Value;

            inicio = fechaInicio.ToString("yyyy-MM-dd");
            fin = fechaFin.ToString("yyyy-MM-dd");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void bttReports_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex != null)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        using (Reportes.GUI.Visor f = new Reportes.GUI.Visor())
                        {
                            using (Reportes.REP.RepKardex rep = new Reportes.REP.RepKardex())
                            {
                                DataTable datos = capa.Kardex(inicio, fin);
                                f.GenerarReporte(rep, datos, inicio, fin);
                                f.ShowDialog();
                            }

                        }
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        using (Reportes.GUI.Visor f = new Reportes.GUI.Visor())
                        {
                            using (Reportes.REP.RepDetIngreso rep = new Reportes.REP.RepDetIngreso())
                            {
                                DataTable datos = capa1.DetalleIngreso(inicio, fin);
                                f.GenerarReporte(rep, datos, inicio,fin);
                                f.ShowDialog();
                            }

                        }
                    }
                    if (comboBox1.SelectedIndex == 2)
                    {
                        using (Reportes.GUI.Visor f = new Reportes.GUI.Visor())
                        {
                            using (Reportes.REP.RepDetVenta rep = new Reportes.REP.RepDetVenta())
                            {
                                DataTable datos = capa2.DetalleVenta(inicio, fin);
                                f.GenerarReporte(rep, datos, inicio,fin);
                                f.ShowDialog();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            asignarFecha();
        }

        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {
            asignarFecha();
        }
    }
}