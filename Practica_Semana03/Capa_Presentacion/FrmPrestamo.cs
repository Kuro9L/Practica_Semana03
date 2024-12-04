using Capa_Datos;
using Capa_Entidades;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FrmPrestamo : Form
    {
        public FrmPrestamo()
        {
            InitializeComponent();
        }
        ClsPrestamo objprestamo = new ClsPrestamo();
        ClsEstudiante objEstudi = new ClsEstudiante();
        Negocio objne = new Negocio();
        Datos objdatos = new Datos();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pnlisbn_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Puedes cambiar el color y grosor según desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Puedes cambiar el color y grosor según desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
        }
        private void pnlDni_Paint(object sender, PaintEventArgs e)
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
        private void TipoPrestamo()
        {
            Datos objusua = new Datos();
            cboTipoPrestamo.DataSource = objusua.TipoPrestamo();
            cboTipoPrestamo.DisplayMember = "tipo_prestamo";
            cboTipoPrestamo.ValueMember = "id";
        }

        private void Limpiar()
        {
            txtId.Clear();
            txtidlibro.Clear();
            txtIsbn.Clear();
            cboTipoPrestamo.SelectedIndex = -1;
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtCorreo.Clear();
            dtpFechaDevolucion.Value = DateTime.Now;
            dtpFechaPrestamo.Value = DateTime.Now;

        }

        private void btnBuscarPrestamo_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                // Si txtDni está vacío y está habilitado, muestra el mensaje
                if (txtId.Enabled)
                {
                    MessageBox.Show("Por favor, ingrese el Id del Prestamo.");
                    return; // Detiene la ejecución si txtDni está vacío y habilitado
                }
                else
                {
                    // Si txtDni está vacío y deshabilitado, habilítalo
                    txtId.Enabled = true;
                }
            }
            else
            {
                DataTable dt = new DataTable();
                objprestamo.IdPrestamo = Convert.ToInt32(txtId.Text);
                objprestamo.DniEstudiante = txtDni.Text;
                objprestamo.Isbn = txtIsbn.Text;
                int idLibro;
                if (int.TryParse(txtidlibro.Text, out idLibro))
                {
                    objprestamo.IdLibro = idLibro;
                }
                objprestamo.FechaPrestamo = dtpFechaPrestamo.Value;
                objprestamo.FechaDevolucion = dtpFechaDevolucion.Value;
                objprestamo.TipoPrestamo = Convert.ToInt32(cboTipoPrestamo.SelectedValue);
                objprestamo.Nombre = txtNombre.Text;
                objprestamo.Apellido = txtApellido.Text;
                objprestamo.Correo = txtCorreo.Text;
                objprestamo.Direccion = txtDireccion.Text;

                dt = objne.BuscarPrestamo(objprestamo);

                if (dt.Rows.Count > 0)
                {
                    txtId.Text = dt.Rows[0]["id"].ToString();
                    txtDni.Text = dt.Rows[0]["dni_estudiante"].ToString();
                    txtidlibro.Text = dt.Rows[0]["libro_id"].ToString();
                    txtIsbn.Text = dt.Rows[0]["isbn"].ToString();
                    cboTipoPrestamo.SelectedValue = Convert.ToInt32(dt.Rows[0]["tipo_prestamo"].ToString());
                    dtpFechaPrestamo.Value = Convert.ToDateTime(dt.Rows[0]["fecha_emision"].ToString());
                    dtpFechaDevolucion.Value = Convert.ToDateTime(dt.Rows[0]["fecha_devolucion"].ToString());
                    txtNombre.Text = dt.Rows[0]["nombre"].ToString();
                    txtApellido.Text = dt.Rows[0]["apellido"].ToString();
                    txtCorreo.Text = dt.Rows[0]["correo"].ToString();
                    txtDireccion.Text = dt.Rows[0]["direccion"].ToString();

                    txtId.Enabled = false;
                    txtNombre.Enabled = false;
                    txtApellido.Enabled = false;
                    txtCorreo.Enabled = false;
                    txtDireccion.Enabled = false;
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnAgregar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Libro no Registrado");
                }
            }
        }
        private void FrmPrestamo_Load(object sender, EventArgs e)
        {
            TipoPrestamo();
            dtpFechaDevolucion.Value = DateTime.Now;
            dtpFechaPrestamo.Value = DateTime.Now;
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Datos objdatos = new Datos();

            objprestamo.IdPrestamo = Convert.ToInt32(txtId.Text);
            objprestamo.IdLibro = Convert.ToInt32(txtidlibro.Text);
            objprestamo.Isbn = txtIsbn.Text;
            objprestamo.TipoPrestamo = Convert.ToInt32(cboTipoPrestamo.SelectedValue);
            objprestamo.FechaPrestamo = dtpFechaPrestamo.Value;
            objprestamo.FechaDevolucion = dtpFechaDevolucion.Value;
            objprestamo.DniEstudiante = txtDni.Text;
            objdatos.InsertarPrestamo(objprestamo);
            MessageBox.Show("Se Agrego Correctamente");
            Limpiar();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Puedes cambiar el color y grosor según desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
        }

        private void btnBuscarDni_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                // Si txtDni está vacío y está habilitado, muestra el mensaje
                if (txtDni.Enabled)
                {
                    MessageBox.Show("Por favor, ingrese el DNI del Estudiante.");
                    return; // Detiene la ejecución si txtDni está vacío y habilitado
                }
                else
                {
                    // Si txtDni está vacío y deshabilitado, habilítalo
                    txtDni.Enabled = true;
                }
            }
            else
            {
                DataTable dt = new DataTable();
                objEstudi.Dni = txtDni.Text;
                objEstudi.Nombre = txtNombre.Text;
                objEstudi.Apellido = txtApellido.Text;
                objEstudi.Correo = txtCorreo.Text;
                objEstudi.Direccion = txtDireccion.Text;

                // Asignar solo los campos que deseas para este formulario
                // No toques los campos que no quieres usar en este formulario
                dt = objne.BuscarEstudiantePrestamo(objEstudi);

                if (dt.Rows.Count > 0)
                {
                    // Asigna solo los campos que necesitas
                    txtDni.Text = dt.Rows[0]["dni"].ToString();
                    txtNombre.Text = dt.Rows[0]["nombre"].ToString();
                    txtApellido.Text = dt.Rows[0]["apellido"].ToString();
                    txtCorreo.Text = dt.Rows[0]["correo"].ToString();
                    txtDireccion.Text = dt.Rows[0]["direccion"].ToString();

                    txtDni.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Estudiante no encontrado");
                }
            }
        }
    }
}
