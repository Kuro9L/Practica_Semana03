using Capa_Datos;
using Capa_Entidades;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;

namespace Capa_Presentacion
{
    public partial class FrmProveedor : Form
    {
        
        public FrmProveedor()
        {
            InitializeComponent();
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }
        ClsProveedor objprov = new ClsProveedor();
        Negocio objne = new Negocio();
        Datos objdatos = new Datos();

        private void plnId_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Puedes cambiar el color y grosor según desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
        }

        private void pnlNombre_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Puedes cambiar el color y grosor según desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
        }

        private void pnlCorreo_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Puedes cambiar el color y grosor según desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
        }

        private void pnlTelefono_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Puedes cambiar el color y grosor según desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            objprov.IdProveedor = Convert.ToInt32(txtId.Text);
            objprov.Nombre = txtNombre.Text;
            objprov.Correo = txtCorreo.Text;
            objprov.Telefono = txtTelefono.Text;
            objprov.Ubicacion = txtUbicacion.Text;

            dt = objne.BuscarProveedor(objprov);
            if (dt.Rows.Count > 0)
            {
                txtId.Text = dt.Rows[0][0].ToString();
                txtNombre.Text = dt.Rows[0][1].ToString();
                txtCorreo.Text = dt.Rows[0][2].ToString();
                txtTelefono.Text = dt.Rows[0][3].ToString();
                txtUbicacion.Text = dt.Rows[0][4].ToString();
                txtId.Enabled = false;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                btnAgregar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Libro no Registrado");
            }

            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            objprov.IdProveedor = Convert.ToInt32(txtId.Text);
            objprov.Nombre = txtNombre.Text;
            objprov.Correo = txtCorreo.Text;
            objprov.Telefono = txtTelefono.Text;
            objprov.Ubicacion = txtUbicacion.Text;
            objdatos.EditaProveedor(objprov);
            Limpiar();
            txtId.Enabled = true;
            MessageBox.Show("Se Modifico Correctamente");


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Datos objdatos = new Datos();
            objprov.IdProveedor = Convert.ToInt32(txtId.Text);
            objdatos.EliminarProveedor(objprov);

            MessageBox.Show("Se Elimino Correctamente");
            Limpiar();
            txtId.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnAgregar.Enabled = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Datos objdatos = new Datos();
                objprov.IdProveedor = Convert.ToInt32(txtId.Text);
                objprov.Nombre = txtNombre.Text;
                objprov.Correo = txtCorreo.Text;
                objprov.Telefono = txtTelefono.Text;
                objprov.Ubicacion = txtUbicacion.Text;
                objdatos.InsertarProveedor(objprov);
                MessageBox.Show("Se Agrego Correctamente");
        }

        private void pnlUbicacion_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Puedes cambiar el color y grosor según desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
        }

        private void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtUbicacion.Clear();
        }
    }
}
