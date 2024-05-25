using CapaLogicaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CapaEntidades.ClaseEntidades;

namespace SistemaGestionInventarios
{
    public partial class FrmProveedor : Form
    {
        private BL_Proveedores blProveedores;
        private int idProveedorSeleccionado;

        public FrmProveedor()
        {
            InitializeComponent();
            blProveedores = new BL_Proveedores();
            idProveedorSeleccionado = -1;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            blProveedores.CrearProveedor(
                txtNombreProveedor.Text,
                cmbSectorComercial.Text,
                cmbTipoDocumento.Text,
                txtNumeroDocumento.Text,
                txtDireccion.Text,
                txtTelefono.Text
            );
            LimpiarCampos();
            CargarProveedores();

        }

        private void btnEliinar_Click(object sender, EventArgs e)
        {
            if (idProveedorSeleccionado != -1)
            {
                blProveedores.EliminarProveedor(idProveedorSeleccionado);
                LimpiarCampos();
                CargarProveedores();
                idProveedorSeleccionado = -1;
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para eliminar.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idProveedorSeleccionado != -1)
            {
                blProveedores.ActualizarProveedor(
                    idProveedorSeleccionado,
                    txtNombreProveedor.Text,
                    cmbSectorComercial.Text,
                    cmbTipoDocumento.Text,
                    txtNumeroDocumento.Text,
                    txtDireccion.Text,
                    txtTelefono.Text
                );
                LimpiarCampos();
                CargarProveedores();
                idProveedorSeleccionado = -1;
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para editar.");
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();


        }

        private void dgvProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProveedor.Rows[e.RowIndex];
                idProveedorSeleccionado = Convert.ToInt32(row.Cells["IdProveedor"].Value);
                txtNombreProveedor.Text = row.Cells["NombreProveedor"].Value.ToString();
                cmbSectorComercial.Text = row.Cells["SectorComercial"].Value.ToString();
                cmbTipoDocumento.Text = row.Cells["TipoDocumento"].Value.ToString();
                txtNumeroDocumento.Text = row.Cells["NumeroDocumento"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
            }

        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }
        private void LimpiarCampos()
        {
            txtNombreProveedor.Clear();
            cmbSectorComercial.SelectedIndex = -1;
            cmbTipoDocumento.SelectedIndex = -1;
            txtNumeroDocumento.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            idProveedorSeleccionado = -1;
        }

        private void CargarProveedores()
        {
            List<Proveedor> proveedores = blProveedores.ObtenerProveedores();
            dgvProveedor.DataSource = proveedores;
        }
    }
}
