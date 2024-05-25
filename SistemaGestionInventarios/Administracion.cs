using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;


namespace SistemaGestionInventarios
{
    public partial class Administracion : Form
    {
        //Metro
        private int originalWidth;
        private bool isExpanded = true;
        public Administracion()
        {
            InitializeComponent();
          /*this.Theme = MetroFramework.MetroThemeStyle.Light;
            // Cambia el color a plata
            this.Style = MetroFramework.MetroColorStyle.Silver;*/
        }

        private void AbrirFormEnPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }       
        //AbrirFormEnPanel(new FrmArticulos());
        private void btnmenu1_Click(object sender, EventArgs e)
        {
            if (isExpanded)
            {
                // Guarda el tamaño original antes de cambiarlo
                originalWidth = MenuVertical.Width;
                MenuVertical.Width = 55;
                isExpanded = false;
            }
            else
            {
                // Restaura el tamaño original
                MenuVertical.Width = originalWidth;
                isExpanded = true;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Administracion frm = new Administracion();
            frm.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmArticulos());
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmIngresos());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmVentas());
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmTrabajadores());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmCategorias());

        }
    }
}
