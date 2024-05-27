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
    public partial class FrmDetalleVentas : Form
    {
        public FrmDetalleVentas()
        {
            InitializeComponent();
        }

        private void FrmDetalleVentas_Load(object sender, EventArgs e)
        {
            CargarDetallesVentas();
            dgvDetalleVentas.Columns["IdDetalleVenta"].Visible = false;
            dgvDetalleVentas.Columns["IdVenta"].Visible = false;
            dgvDetalleVentas.Columns["IdDetalleIngreso"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtCantidad.Text, out int cantidad) &&
                    decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta))
                {
                    DetalleVenta detalleVenta = new DetalleVenta
                    {
                        Cantidad = cantidad,
                        PrecioVenta = precioVenta,
                        Descuento = string.IsNullOrWhiteSpace(txtDescuento.Text) ? 0 : decimal.Parse(txtDescuento.Text)
                    };

                    BL_DetalleVentas blDetalleVentas = new BL_DetalleVentas();
                    bool resultado = blDetalleVentas.InsertarDetalleVenta(detalleVenta);

                    if (resultado)
                    {
                        MessageBox.Show("Detalle de venta agregado correctamente.");
                        LimpiarCampos();
                        CargarDetallesVentas();
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar el detalle de venta.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese valores válidos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalleVentas.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este detalle de venta?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idDetalleVenta = int.Parse(dgvDetalleVentas.CurrentRow.Cells["IdDetalleVenta"].Value.ToString());

                        BL_DetalleVentas blDetalleVentas = new BL_DetalleVentas();
                        bool resultado = blDetalleVentas.EliminarDetalleVenta(idDetalleVenta);

                        if (resultado)
                        {
                            MessageBox.Show("Detalle de venta eliminado correctamente.");
                            CargarDetallesVentas();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el detalle de venta.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un detalle de venta para eliminar.");
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDetalleVentas.CurrentRow != null)
            {
                try
                {
                    DetalleVenta detalleVenta = new DetalleVenta
                    {
                        IdDetalleVenta = int.Parse(dgvDetalleVentas.CurrentRow.Cells["IdDetalleVenta"].Value.ToString()),
                        Cantidad = int.Parse(txtCantidad.Text),
                        PrecioVenta = decimal.Parse(txtPrecioVenta.Text),
                        Descuento = string.IsNullOrWhiteSpace(txtDescuento.Text) ? 0 : decimal.Parse(txtDescuento.Text)
                    };

                    BL_DetalleVentas blDetalleVentas = new BL_DetalleVentas();
                    bool resultado = blDetalleVentas.ActualizarDetalleVenta(detalleVenta);

                    if (resultado)
                    {
                        MessageBox.Show("Detalle de venta actualizado correctamente.");
                        LimpiarCampos();
                        CargarDetallesVentas();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el detalle de venta.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}");
                }
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtCantidad.Clear();
            txtPrecioVenta.Clear();
            txtDescuento.Clear();
        }

        private void CargarDetallesVentas()
        {
            BL_DetalleVentas blDetalleVentas = new BL_DetalleVentas();
            List<DetalleVenta> detallesVentas = blDetalleVentas.ObtenerDetallesVentas();
            dgvDetalleVentas.DataSource = detallesVentas;
        }


        private void dgvDetalleVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDetalleVentas.Rows[e.RowIndex];

                txtCantidad.Text = row.Cells["Cantidad"].Value.ToString();
                txtPrecioVenta.Text = row.Cells["PrecioVenta"].Value.ToString();
                txtDescuento.Text = row.Cells["Descuento"].Value.ToString();
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta) &&
        int.TryParse(txtCantidad.Text, out int cantidad))
            {
                decimal descuento = CalcularDescuento(precioVenta, cantidad);
                // Mostrar el descuento en el TextBox
                txtDescuento.Text = descuento.ToString();
            }

        }

        private decimal CalcularDescuento(decimal precioVenta, int cantidad)
        {
            decimal descuento = precioVenta * cantidad * 0.1m; 
            return descuento;
        }
    }
}
