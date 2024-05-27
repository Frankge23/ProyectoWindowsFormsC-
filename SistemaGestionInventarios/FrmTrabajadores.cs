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
    public partial class FrmTrabajadores : Form
    {
        private BL_Trabajadores trabajadorBL;
        public FrmTrabajadores()
        {
            InitializeComponent();
            trabajadorBL = new BL_Trabajadores();
        }

        private void FrmTrabajadores_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDataGridViewTrabajadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en FrmTrabajadores_Load: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombres.Text) ||
                    string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                    string.IsNullOrWhiteSpace(cmbSexo.Text) ||
                    string.IsNullOrWhiteSpace(txtNumeroDocumento.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de agregar un trabajador.");
                    return;
                }
                Trabajador trabajador = new Trabajador
                {
                    Nombres = txtNombres.Text,
                    Apellidos = txtApellidos.Text,
                    Sexo = cmbSexo.Text,
                    FechaNacimiento = dtpNacimiento.Value,
                    NumeroDocumento = txtNumeroDocumento.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text
                };

                if (trabajadorBL.InsertarTrabajador(trabajador))
                {
                    MessageBox.Show("Trabajador agregado correctamente.");
                    LimpiarCampos();
                    CargarDataGridViewTrabajadores();
                }
                else
                {
                    MessageBox.Show("Error al agregar el trabajador.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el trabajador: " + ex.Message);
            }

        }

        private void btnEliinar_Click(object sender, EventArgs e)
        {
            if (dgvTrabajadores.SelectedRows.Count > 0)
            {
                int idTrabajador = Convert.ToInt32(dgvTrabajadores.SelectedRows[0].Cells["IdTrabajador"].Value);
                if (trabajadorBL.EliminarTrabajador(idTrabajador))
                {
                    MessageBox.Show("Trabajador eliminado correctamente.");
                    CargarDataGridViewTrabajadores();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el trabajador.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un trabajador para eliminar.");
            }
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvTrabajadores.SelectedRows.Count > 0)
            {
                Trabajador trabajador = new Trabajador
                {
                    IdTrabajador = Convert.ToInt32(dgvTrabajadores.SelectedRows[0].Cells["IdTrabajador"].Value),
                    Nombres = txtNombres.Text,
                    Apellidos = txtApellidos.Text,
                    Sexo = cmbSexo.Text,
                    FechaNacimiento = dtpNacimiento.Value,
                    NumeroDocumento = txtNumeroDocumento.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text
                };

                if (trabajadorBL.ActualizarTrabajador(trabajador))
                {
                    MessageBox.Show("Trabajador actualizado correctamente.");
                    LimpiarCampos();
                    CargarDataGridViewTrabajadores();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el trabajador.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un trabajador para editar.");
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvTrabajadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTrabajadores.Rows[e.RowIndex];
                txtNombres.Text = row.Cells["Nombres"].Value.ToString();
                txtApellidos.Text = row.Cells["Apellidos"].Value.ToString();
                cmbSexo.Text = row.Cells["Sexo"].Value.ToString();
                dtpNacimiento.Value = Convert.ToDateTime(row.Cells["FechaNacimiento"].Value);
                txtNumeroDocumento.Text = row.Cells["NumeroDocumento"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
            }

        }
        private void CargarDataGridViewTrabajadores()
        {
            try
            {
                if (trabajadorBL == null)
                {
                    throw new NullReferenceException("trabajadorBL no ha sido inicializado.");
                }

                DataTable dtTrabajadores = trabajadorBL.ObtenerTrabajadores();

                if (dtTrabajadores == null)
                {
                    throw new NullReferenceException("El DataTable obtenido es nulo.");
                }

                if (dtTrabajadores.Columns.Count > 0)
                {

                    dgvTrabajadores.DataSource = dtTrabajadores;

                    foreach (DataGridViewColumn column in dgvTrabajadores.Columns)
                    {
                        column.Visible = true;
                    }

                    dgvTrabajadores.Columns["IdTrabajador"].HeaderText = "ID Trabajador";
                    dgvTrabajadores.Columns["IdTrabajador"].Visible = false; 
                    dgvTrabajadores.Columns["Nombres"].HeaderText = "Nombres";
                    dgvTrabajadores.Columns["Apellidos"].HeaderText = "Apellidos";
                    dgvTrabajadores.Columns["Sexo"].HeaderText = "Sexo";
                    dgvTrabajadores.Columns["FechaNacimiento"].HeaderText = "Fecha de Nacimiento";
                    dgvTrabajadores.Columns["NumeroDocumento"].HeaderText = "Número de Documento";
                    dgvTrabajadores.Columns["Direccion"].HeaderText = "Dirección";
                    dgvTrabajadores.Columns["Telefono"].HeaderText = "Teléfono";
                }
                else
                {
                    MessageBox.Show("No se encontraron trabajadores en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los trabajadores: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void LimpiarCampos()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            cmbSexo.SelectedIndex = -1;
            dtpNacimiento.Value = DateTime.Now;
            txtNumeroDocumento.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
        }
    }
}
