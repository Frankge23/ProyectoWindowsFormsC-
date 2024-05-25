using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaLogicaNegocios;
using static CapaEntidades.ClaseEntidades;


namespace SistemaGestionInventarios
{
    public partial class FrmArticulos : Form
    {
        private BL_Articulos bl_Articulos = new BL_Articulos();
        public FrmArticulos()
        {
            InitializeComponent();
            CargarCategoriasEnComboBox();
            ActualizarDgvArticulos();
            dgvArticulos.CellClick += new DataGridViewCellEventHandler(dgvArticulos_CellContentClick); 
        }
        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FrmCategorias frm = new FrmCategorias();
            frm.Show();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevoArticulo = new Articulo
                {
                    Codigo = txtCodigoVentas.Text,
                    Nombre = txtNombreArticulo.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = Convert.ToDecimal(txtPrecio.Text),
                    IdCategoria = ((Categoria)cmbTipoCategorias.SelectedItem).IdCategoria
                };



                if (bl_Articulos.InsertarArticulo(nuevoArticulo))
                {
                    MessageBox.Show("Artículo agregado con éxito");
                    LimpiarFormulario();
                    ActualizarDgvArticulos();
                }
                else
                {
                    MessageBox.Show("Error al agregar el artículo");
                }
            }

            catch (FormatException ex)
            {
                MostrarError("Error de formato: " + ex.Message);
            }
            catch (Exception ex)
            {
                MostrarError("Error al agregar el artículo: " + ex.Message);
            }
        }
        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.SelectedRows.Count > 0)
            {
                int idArticulo = Convert.ToInt32(dgvArticulos.SelectedRows[0].Cells["IdArticulo"].Value);

                if (bl_Articulos.EliminarArticulo(idArticulo))
                {
                    MessageBox.Show("Artículo eliminado con éxito");
                    ActualizarDgvArticulos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el artículo");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un artículo para eliminar");
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.SelectedRows.Count > 0)
            {
                int idArticulo = Convert.ToInt32(dgvArticulos.SelectedRows[0].Cells["IdArticulo"].Value);

                //lógica para actualizar el artículo con el idArticulo.
                Articulo articuloActualizado = new Articulo
                {
                    IdArticulo = idArticulo,
                    Codigo = txtCodigoVentas.Text,
                    Nombre = txtNombreArticulo.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = Convert.ToDecimal(txtPrecio.Text),
                    IdCategoria = Convert.ToInt32(cmbTipoCategorias.SelectedValue)
                };

                if (bl_Articulos.ActualizarArticulo(articuloActualizado))
                {
                    MessageBox.Show("Artículo actualizado con éxito");
                    ActualizarDgvArticulos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el artículo");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un artículo para editar");
            }

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
        private void CargarCategoriasEnComboBox()
        {
            List<Categoria> categorias = bl_Articulos.ObtenerCategorias();
            cmbTipoCategorias.DataSource = categorias;
            cmbTipoCategorias.DisplayMember = "TipoCategoria";
            cmbTipoCategorias.ValueMember = "IdCategoria";
        }
        private void ActualizarDgvArticulos()
        {
            try
            {
                List<Articulo> articulos = bl_Articulos.ObtenerArticulos();
                dgvArticulos.DataSource = articulos;

                // Ajustar las columnas
                if (dgvArticulos.Columns["IdCategoria"] != null)
                {
                    dgvArticulos.Columns["IdCategoria"].Visible = false; 
                }

                if (dgvArticulos.Columns["TipoCategoria"] == null)
                {
                    dgvArticulos.Columns.Add("TipoCategoria", "Categoría");
                }


                foreach (DataGridViewColumn column in dgvArticulos.Columns)
                {
                    if (column.Name == "TipoCategoria")
                    {
                        column.HeaderText = "Categoría";
                        column.DisplayIndex = 5; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la lista de artículos: " + ex.Message);
            }
        }
        private void LimpiarFormulario()
        {
            txtCodigoVentas.Text = "";
            txtNombreArticulo.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            cmbTipoCategorias.SelectedIndex = -1;
        }
        public List<Categoria> ObtenerCategorias()
        {
            try
            {
                return bl_Articulos.ObtenerCategorias();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las categorías: " + ex.Message);
            }
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvArticulos.Rows[e.RowIndex];
                txtCodigoVentas.Text = row.Cells["Codigo"].Value.ToString();
                txtNombreArticulo.Text = row.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value.ToString();
                cmbTipoCategorias.SelectedValue = row.Cells["TipoCategoria"].Value;
            }
        }
    }
}
