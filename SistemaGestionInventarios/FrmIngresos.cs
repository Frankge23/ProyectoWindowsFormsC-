using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocios;
using static CapaEntidades.ClaseEntidades;

namespace SistemaGestionInventarios
{
    public partial class FrmIngresos : Form
    {
        private BL_Ingresos ingresosBL;
      

        public FrmIngresos()
        {
            InitializeComponent();
            ingresosBL = new BL_Ingresos();
           
            CargarComboBoxProveedores();
            CargarComboBoxTrabajadores();
            CargarDataGridViewIngresos();
        }
       
        private void btnProveedor_Click(object sender, EventArgs e)
        {
            FrmProveedor frm = new FrmProveedor();
            frm.Show();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Ingreso ingreso = new Ingreso
            {
                IdProveedor = (int)cmbProveedor.SelectedValue,
                IdTrabajador = (int)cmbTrabajador.SelectedValue,
                FechaIngreso = dateTimePickerIngresos.Value,
                TipoComprobante = cmbTipoComprobante.Text,
                Serie = txtSerie.Text,
                Correlativo = txtCorrelativo.Text,
                Estado = txtEstado.Text
            };

            if (ingresosBL.InsertarIngreso(ingreso))
            {
                MessageBox.Show("Ingreso agregado correctamente.");
                LimpiarCampos();
                CargarDataGridViewIngresos();
            }
            else
            {
                MessageBox.Show("Error al agregar el ingreso.");
            }

        }     
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvIngresos.SelectedRows.Count > 0)
            {
                int idIngreso = Convert.ToInt32(dgvIngresos.SelectedRows[0].Cells["IdIngreso"].Value);
                if (ingresosBL.EliminarIngreso(idIngreso))
                {
                    MessageBox.Show("Ingreso eliminado correctamente.");
                    CargarDataGridViewIngresos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el ingreso.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un ingreso para eliminar.");
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvIngresos.SelectedRows.Count > 0)
            {
                Ingreso ingreso = new Ingreso
                {
                    IdIngreso = Convert.ToInt32(dgvIngresos.SelectedRows[0].Cells["IdIngreso"].Value),
                    IdProveedor = (int)cmbProveedor.SelectedValue,
                    IdTrabajador = (int)cmbTrabajador.SelectedValue,
                    FechaIngreso = dateTimePickerIngresos.Value,
                    TipoComprobante = cmbTipoComprobante.Text,
                    Serie = txtSerie.Text,
                    Correlativo = txtCorrelativo.Text,
                    Estado = txtEstado.Text
                };

                if (ingresosBL.ActualizarIngreso(ingreso))
                {
                    MessageBox.Show("Ingreso actualizado correctamente.");
                    LimpiarCampos();
                    CargarDataGridViewIngresos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el ingreso.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un ingreso para editar.");
            }

        }
        private void FrmIngresos_Load(object sender, EventArgs e)
        {
            CargarComboBoxProveedores();
            CargarComboBoxTrabajadores();
            CargarIngresos();
        }                
        private void btnDetalleIngresos_Click(object sender, EventArgs e)
        {
            FrmDetalleIngresos frm = new FrmDetalleIngresos();
            frm.Show();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void CargarComboBoxProveedores()
        {
            BL_Proveedores proveedorBL = new BL_Proveedores();

            try
            {
                List<Proveedor> proveedores = proveedorBL.ObtenerProveedores();
                cmbProveedor.DataSource = proveedores;
                cmbProveedor.DisplayMember = "NombreProveedor";
                cmbProveedor.ValueMember = "IdProveedor";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los proveedores: " + ex.Message);
            }

        }

        private void CargarComboBoxTrabajadores()
        {
            // Crear una instancia de la capa de lógica de negocios para los trabajadores
            BL_Trabajadores trabajadorBL = new BL_Trabajadores();

            try
            {

                DataTable dtTrabajadores = trabajadorBL.ObtenerTrabajadores();
                cmbTrabajador.DataSource = dtTrabajadores;
                cmbTrabajador.DisplayMember = "Nombres";
                cmbTrabajador.ValueMember = "IdTrabajador"; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los trabajadores: " + ex.Message);
            }
        }

        private void CargarIngresos()
        {
            
        }

        private void CargarDataGridViewIngresos()
        {
            dgvIngresos.DataSource = ingresosBL.ObtenerIngresos();
        }

        private void LimpiarCampos()
        {
            cmbProveedor.SelectedIndex = -1;
            cmbTrabajador.SelectedIndex = -1;
            dateTimePickerIngresos.Value = DateTime.Now;
            cmbTipoComprobante.SelectedIndex = -1;
            txtSerie.Clear();
            txtCorrelativo.Clear();
            txtEstado.Clear();
        }
        private void dgvIngresos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvIngresos.Rows[e.RowIndex];
                txtSerie.Text = row.Cells["Serie"].Value.ToString();
                txtCorrelativo.Text = row.Cells["Correlativo"].Value.ToString();
                txtEstado.Text = row.Cells["Estado"].Value.ToString();
                cmbProveedor.Text = row.Cells["NombreProveedor"].Value.ToString();
                cmbTrabajador.Text = row.Cells["NombreTrabajador"].Value.ToString();
                dateTimePickerIngresos.Value = Convert.ToDateTime(row.Cells["FechaIngreso"].Value);
                cmbTipoComprobante.Text = row.Cells["TipoComprobante"].Value.ToString();
            }

        }
    }
}
