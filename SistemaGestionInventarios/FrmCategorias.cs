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
using MetroFramework.Forms;
using static CapaEntidades.ClaseEntidades;


namespace SistemaGestionInventarios
{
    public partial class FrmCategorias : Form
    {
        private BL_Categorias bl_Categorias = new BL_Categorias();

        public FrmCategorias()
        {
            InitializeComponent();
            ActualizarDgvCategorias();
            CargarCategoriasEnComboBox();
            dgvCategorias.CellClick += new DataGridViewCellEventHandler(dgvCategorias_CellContentClick);
        }

       
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Categoria nuevaCategoria = new Categoria
            {
                TipoCategoria = cmbTipoCategorias.Text,
                Nombre = txtNombreCategoria.Text,
                Descripcion = txtDescripcion.Text
            };

            if (bl_Categorias.InsertarCategoria(nuevaCategoria))
            {
                MessageBox.Show("Categoría agregada con éxito");
                LimpiarFormulario();
                ActualizarDgvCategorias();
            }
            else
            {
                MessageBox.Show("Error al agregar la categoría");
            }

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idCategoria = Convert.ToInt32(dgvCategorias.CurrentRow.Cells[0].Value);

            if (bl_Categorias.EliminarCategoria(idCategoria))
            {
                MessageBox.Show("Categoría eliminada con éxito");
                ActualizarDgvCategorias();
            }
            else
            {
                MessageBox.Show("Error al eliminar la categoría");
            }

        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Categoria categoriaActualizada = new Categoria
            {
                IdCategoria = Convert.ToInt32(dgvCategorias.CurrentRow.Cells[0].Value),
                TipoCategoria = cmbTipoCategorias.Text,
                Nombre = txtNombreCategoria.Text,
                Descripcion = txtDescripcion.Text
            };

            if (bl_Categorias.ActualizarCategoria(categoriaActualizada))
            {
                MessageBox.Show("Categoría actualizada con éxito");
                LimpiarFormulario();
                ActualizarDgvCategorias();
            }
            else
            {
                MessageBox.Show("Error al actualizar la categoría");
            }


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();

        }

        private void CargarCategoriasEnComboBox()
        {
            List<Categoria> categorias = bl_Categorias.ObtenerCategorias();

            cmbTipoCategorias.DataSource = categorias;
            cmbTipoCategorias.DisplayMember = "TipoCategoria";
            cmbTipoCategorias.ValueMember = "IdCategoria";
        }


        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Categoria categoriaSeleccionada = bl_Categorias.ObtenerCategoria(Convert.ToInt32(dgvCategorias.CurrentRow.Cells[0].Value));

            cmbTipoCategorias.Text = categoriaSeleccionada.TipoCategoria;
            txtNombreCategoria.Text = categoriaSeleccionada.Nombre;
            txtDescripcion.Text = categoriaSeleccionada.Descripcion;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvCategorias.Rows[e.RowIndex];
                cmbTipoCategorias.Text = row.Cells["TipoCategoria"].Value.ToString();
                txtNombreCategoria.Text = row.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
            }
        }

        private void LimpiarFormulario()
        {
            cmbTipoCategorias.Text = "";
            txtNombreCategoria.Text = "";
            txtDescripcion.Text = "";
        }

        private void ActualizarDgvCategorias()
        {
            dgvCategorias.DataSource = bl_Categorias.ObtenerCategorias();

        }

        
    }
}
