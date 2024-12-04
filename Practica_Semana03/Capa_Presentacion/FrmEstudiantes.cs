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

namespace Capa_Presentacion
{
    public partial class FrmEstudiantes : Form
    {
        public FrmEstudiantes()
        {
            InitializeComponent();
        }
        ClsEstudiante objEstudi = new ClsEstudiante();
        Negocio objne = new Negocio();
        Datos objdatos = new Datos();
        private void pnlId_Paint(object sender, PaintEventArgs e)
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
        private void pnlApellido_Paint(object sender, PaintEventArgs e)
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
        private void pnlDireccion_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Puedes cambiar el color y grosor según desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
        }
        private void ListaGenero()
        {
            Datos objusua = new Datos();
            cbogenero.DataSource = objusua.ListarSexo();
            cbogenero.DisplayMember = "sexo";
            cbogenero.ValueMember = "id";
        }

        private void Limpiar()
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            cbogenero.SelectedIndex = -1;

        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Datos objdatos = new Datos();

            objEstudi.Dni = txtDni.Text;
            objEstudi.Nombre = txtNombre.Text;
            objEstudi.Apellido = txtApellido.Text;
            objEstudi.Correo = txtCorreo.Text;
            objEstudi.Direccion = txtDireccion.Text;
            objEstudi.IdGenero = Convert.ToInt32(cbogenero.SelectedValue);
            objEstudi.Fecha_Registro = dtpFechaRegistro.Value;
            objdatos.InsertarEstudiante(objEstudi);

            MessageBox.Show("Se Agrego Correctamente");
            Limpiar();
        }
        private void FrmEstudiantes_Load(object sender, EventArgs e)
        {
            ListaGenero();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            objEstudi.Dni = txtDni.Text;
            objEstudi.Nombre = txtNombre.Text;
            objEstudi.Apellido = txtApellido.Text;
            objEstudi.Correo = txtCorreo.Text;
            objEstudi.Direccion = txtDireccion.Text;
            objEstudi.IdGenero = Convert.ToInt32(cbogenero.SelectedValue);
            objEstudi.Fecha_Registro = dtpFechaRegistro.Value;
            objdatos.EditaEstudiante(objEstudi);
            Limpiar();
            txtDni.Enabled = true;
            MessageBox.Show("Se Modifico Correctamente");
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            objEstudi.Dni = txtDni.Text;
            objEstudi.Nombre = txtNombre.Text;
            objEstudi.Apellido = txtApellido.Text;
            objEstudi.Correo = txtCorreo.Text;
            objEstudi.Direccion = txtDireccion.Text;
            objEstudi.IdGenero = Convert.ToInt32(cbogenero.SelectedValue);
            objEstudi.Fecha_Registro = dtpFechaRegistro.Value;
            

            dt = objne.BuscarEstudiante(objEstudi);

            if (dt.Rows.Count > 0)
            {
                txtDni.Text = dt.Rows[0][0].ToString();
                txtNombre.Text = dt.Rows[0][1].ToString();
                txtApellido.Text = dt.Rows[0][2].ToString();
                cbogenero.SelectedValue = Convert.ToInt32(dt.Rows[0][3].ToString());
                txtCorreo.Text = dt.Rows[0][4].ToString();
                txtDireccion.Text = dt.Rows[0][5].ToString();
                dtpFechaRegistro.Value = Convert.ToDateTime(dt.Rows[0][6].ToString());


                txtDni.Enabled = false;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                btnAgregar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Libro no Registrado");
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Datos objdatos = new Datos();
            objEstudi.Dni = txtDni.Text;
            objdatos.EliminarEstudiante(objEstudi);

            MessageBox.Show("Se Elimino Correctamente");
            Limpiar();
            txtDni.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnAgregar.Enabled = true;
        }
    }
}
