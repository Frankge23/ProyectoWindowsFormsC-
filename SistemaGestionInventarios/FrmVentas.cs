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
    public partial class FrmVentas : Form
    {
        private BL_Ventas blVentas = new BL_Ventas();
        private Venta ventaSeleccionada;
        public FrmVentas()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes();
            frm.Show();
        }
        
        private void btnEliinar_Click(object sender, EventArgs e)
        {
            if (ventaSeleccionada != null)
            {
                if (MessageBox.Show("¿Está seguro de que desea eliminar esta venta?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (blVentas.EliminarVenta(ventaSeleccionada.IdVenta))
                    {

                        CargarVentas();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una venta para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ventaSeleccionada != null)
            {

                ventaSeleccionada.FechaVenta = dateTimePickerFechaVenta.Value;
                ventaSeleccionada.TipoComprobante = comboBoxComprobante.SelectedItem.ToString();
                ventaSeleccionada.Serie = txtSerie.Text;
                ventaSeleccionada.Correlativo = txtCorrelativo.Text;
                ventaSeleccionada.PrecioTotal = decimal.Parse(txtPrecioTotal.Text);


                if (blVentas.ActualizarVenta(ventaSeleccionada))
                {

                    LimpiarControles();

                    CargarVentas();
                }
                else
                {
                    MessageBox.Show("Error al editar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una venta para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();

        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < dgvVentas.Rows.Count)
            {
                DataGridViewRow fila = dgvVentas.Rows[e.RowIndex];


                if (fila.Cells["IdVenta"].Value != null)
                {

                    if (int.TryParse(fila.Cells["IdVenta"].Value.ToString(), out int idVenta))
                    {

                        ventaSeleccionada = blVentas.ObtenerVenta(idVenta);


                        if (ventaSeleccionada != null)
                        {
                            dateTimePickerFechaVenta.Value = ventaSeleccionada.FechaVenta;
                            comboBoxComprobante.SelectedItem = ventaSeleccionada.TipoComprobante;
                            txtSerie.Text = ventaSeleccionada.Serie;
                            txtCorrelativo.Text = ventaSeleccionada.Correlativo;
                            txtPrecioTotal.Text = ventaSeleccionada.PrecioTotal.ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo encontrar la venta seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El valor de la celda 'IdVenta' no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El valor de la celda 'IdVenta' está vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CargarVentas()
        {
            dgvVentas.DataSource = blVentas.ObtenerVentas();
            dgvVentas.Columns["IdVenta"].Visible = false;
            dgvVentas.Columns["IdCliente"].Visible = false;
            dgvVentas.Columns["IdTrabajador"].Visible = false;
        }


        private void LimpiarControles()
        {

            dateTimePickerFechaVenta.Value = DateTime.Now;
            comboBoxComprobante.SelectedIndex = -1;
            txtSerie.Clear();
            txtCorrelativo.Clear();
            txtPrecioTotal.Clear();
            ventaSeleccionada = null;
        }    
       private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmDetalleVentas frm = new FrmDetalleVentas();
            frm.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Crear una nueva venta con los datos de los controles
            Venta nuevaVenta = new Venta
            {
                FechaVenta = dateTimePickerFechaVenta.Value,
                TipoComprobante = comboBoxComprobante.SelectedItem.ToString(),
                Serie = txtSerie.Text,
                Correlativo = txtCorrelativo.Text,
                PrecioTotal = decimal.Parse(txtPrecioTotal.Text)
            };


            if (blVentas.InsertarVenta(nuevaVenta))
            {

                LimpiarControles();

                CargarVentas();
            }
            else
            {
                MessageBox.Show("Error al agregar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
