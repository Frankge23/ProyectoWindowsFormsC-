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
    public partial class FrmDetalleIngresos : Form
    {
        private BL_DetalleIngresos blDetalleIngresos = new BL_DetalleIngresos();
        public FrmDetalleIngresos()
        {
            InitializeComponent();           
        }

        private void FrmDetalleIngresos_Load(object sender, EventArgs e)
        {
            CargarDetallesIngresos();
            dgvDetallesIngresos.Columns["IdDetalleIngreso"].Visible = false;
            dgvDetallesIngresos.Columns["IdIngreso"].Visible = false;
            dgvDetallesIngresos.Columns["IdArticulo"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var detalleIngreso = new DetalleIngreso
                {
                    PrecioCompra = decimal.Parse(txtPrecioCompra.Text),
                    StockInicial = int.Parse(txtStockInicial.Text),
                    StockActual = int.Parse(txtStockActual.Text),
                    Descuento = decimal.Parse(txtDescuento.Text)
                };

                if (blDetalleIngresos.InsertarDetalleIngreso(detalleIngreso))
                {
                    MessageBox.Show("Detalle de ingreso agregado correctamente");
                    LimpiarFormulario();
                    CargarDetallesIngresos();
                }
                else
                {
                    MessageBox.Show("Error al agregar el detalle de ingreso");
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.");
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idDetalleIngreso = ObtenerIdDetalleIngreso();

            if (idDetalleIngreso > 0)
            {
                try
                {
                    if (blDetalleIngresos.EliminarDetalleIngreso(idDetalleIngreso))
                    {
                        MessageBox.Show("Detalle de ingreso eliminado correctamente");
                        LimpiarFormulario();
                        CargarDetallesIngresos();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el detalle de ingreso. Verifique si el ID es correcto y existe.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al intentar eliminar el detalle de ingreso: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No se pudo obtener un ID de detalle de ingreso válido.");
            }
        }

        private int ObtenerIdDetalleIngreso()
        {
            if (dgvDetallesIngresos.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dgvDetallesIngresos.SelectedRows[0].Cells["IdDetalleIngreso"].Value);
            }

            return 0;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                int idDetalleIngreso = ObtenerIdDetalleIngreso();

                if (idDetalleIngreso > 0)
                {
                    var detalleIngreso = new DetalleIngreso
                    {
                        IdDetalleIngreso = idDetalleIngreso,
                        PrecioCompra = decimal.Parse(txtPrecioCompra.Text),
                        StockInicial = int.Parse(txtStockInicial.Text),
                        StockActual = int.Parse(txtStockActual.Text),
                        Descuento = decimal.Parse(txtDescuento.Text)
                    };

                    if (blDetalleIngresos.ActualizarDetalleIngreso(detalleIngreso))
                    {
                        MessageBox.Show("Detalle de ingreso actualizado correctamente");
                        LimpiarFormulario();
                        CargarDetallesIngresos();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el detalle de ingreso");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un detalle de ingreso válido para editar.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void dgvDetallesIngresos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDetallesIngresos.Rows[e.RowIndex];
                txtPrecioCompra.Text = row.Cells["PrecioCompra"].Value.ToString();
                txtStockInicial.Text = row.Cells["StockInicial"].Value.ToString();
                txtStockActual.Text = row.Cells["StockActual"].Value.ToString();
                txtDescuento.Text = row.Cells["Descuento"].Value.ToString();
            }
        }

        private bool ValidarCampos()
        {
            return !string.IsNullOrWhiteSpace(txtPrecioCompra.Text) && txtPrecioCompra.Text != DBNull.Value.ToString() &&
                   !string.IsNullOrWhiteSpace(txtStockInicial.Text) && txtStockInicial.Text != DBNull.Value.ToString() &&
                   !string.IsNullOrWhiteSpace(txtStockActual.Text) && txtStockActual.Text != DBNull.Value.ToString() &&
                   !string.IsNullOrWhiteSpace(txtDescuento.Text) && txtDescuento.Text != DBNull.Value.ToString();
        }

        private void txtDescuentos_TextChanged(object sender, EventArgs e)
        {

            if (decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra) &&
                int.TryParse(txtStockInicial.Text, out int stockInicial) &&
                int.TryParse(txtStockActual.Text, out int stockActual))
            {
                decimal descuento = CalcularDescuento(precioCompra, stockInicial, stockActual);
                // Mostrar el descuento en el TextBox
                txtDescuento.Text = descuento.ToString();
            }

        }

        private decimal CalcularDescuento(decimal precioCompra, int stockInicial, int stockActual)
        {          
            decimal descuento = precioCompra * 0.1m; 
            return descuento;
        }

        private void LimpiarFormulario()
        {
            txtPrecioCompra.Text = "";
            txtStockInicial.Text = "";
            txtStockActual.Text = "";
            txtDescuento.Text = "";
        }

        private void CargarDetallesIngresos()
        {
            dgvDetallesIngresos.DataSource = blDetalleIngresos.ObtenerDetallesIngresos();
        }

    }
}
