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
using static System.Windows.Forms.MonthCalendar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic;

namespace Capa_Presentacion
{
    public partial class FrmLibros : Form
    {
        public FrmLibros()
        {
            InitializeComponent();
        }

        ClsLibros objlibro = new ClsLibros();
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
        private void pnlTitulo_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Puedes cambiar el color y grosor según desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
        }
        private void pnlNumPaginas_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Puedes cambiar el color y grosor según desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
        }
        private void pnlAutor_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Puedes cambiar el color y grosor según desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
        }
        private void pnlDescripcion_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Puedes cambiar el color y grosor según desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
        }

        private void ListaIdioma()
        {
            Datos objusua = new Datos();
            cboIdioma.DataSource = objusua.ListaIdioma();
            cboIdioma.DisplayMember = "idioma";
            cboIdioma.ValueMember = "id";
        }
        private void ListarProveedor()
        {
            Datos objusua = new Datos();
            cboProveedor.DataSource = objusua.ListarProveedor();
            cboProveedor.DisplayMember = "Nombre";
            cboProveedor.ValueMember = "id";
        }
        private void ListarGenero()
        {
            Datos objusua = new Datos();
            cboGenero.DataSource = objusua.ListarGenero();
            cboGenero.DisplayMember = "nombre_genero";
            cboGenero.ValueMember = "id";
        }
        private void FrmLibros_Load(object sender, EventArgs e)
        {
            ListaIdioma();
            ListarProveedor();
            ListarGenero();
        }

        private void Limpiar()
        {
            txtId.Clear();
            txtTitulo.Clear();
            txtNumPaginas.Clear();
            cboIdioma.SelectedIndex = -1;
            txtAutor.Clear();
            cboGenero.SelectedIndex = -1;
            cboProveedor.SelectedIndex = -1;
            txtAñoPubli.Clear();
            txtDescripcion.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Datos objdatos = new Datos();

            objlibro.IdLibro = Convert.ToInt32(txtId.Text);
            objlibro.Titulo = txtTitulo.Text;
            objlibro.Paginas = txtNumPaginas.Text;
            objlibro.IdIdioma = Convert.ToInt32(cboIdioma.SelectedValue);
            objlibro.Autor = txtAutor.Text;
            objlibro.IdGenero = Convert.ToInt32(cboGenero.SelectedValue);
            objlibro.IdProveedor = Convert.ToInt32(cboProveedor.SelectedValue);
            objlibro.AñoPublicacion = txtAñoPubli.Text;
            objlibro.Descripcion = txtDescripcion.Text;
            objdatos.InsertarLibro(objlibro);

            MessageBox.Show("Se Agrego Correctamente");
            Limpiar();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            objlibro.IdLibro = Convert.ToInt32(txtId.Text);
            objlibro.Titulo = txtTitulo.Text;
            objlibro.Paginas = txtNumPaginas.Text;
            objlibro.IdIdioma = Convert.ToInt32(cboIdioma.SelectedValue);
            objlibro.Autor = txtAutor.Text;
            objlibro.IdGenero = Convert.ToInt32(cboGenero.SelectedValue);
            objlibro.IdProveedor = Convert.ToInt32(cboProveedor.SelectedValue);
            objlibro.AñoPublicacion = txtAñoPubli.Text;
            objlibro.Descripcion = txtDescripcion.Text;

            dt = objne.BuscarLibro(objlibro);

            if (dt.Rows.Count > 0)
            {
                txtId.Text = dt.Rows[0][0].ToString();
                txtTitulo.Text = dt.Rows[0][1].ToString();
                txtNumPaginas.Text = dt.Rows[0][2].ToString();
                cboIdioma.SelectedValue = Convert.ToInt32(dt.Rows[0][3].ToString());
                txtAutor.Text = dt.Rows[0][4].ToString();
                cboGenero.SelectedValue = Convert.ToInt32(dt.Rows[0][5].ToString());
                cboProveedor.SelectedValue = Convert.ToInt32(dt.Rows[0][6].ToString());
                txtAñoPubli.Text = dt.Rows[0][7].ToString();
                txtDescripcion.Text = dt.Rows[0][8].ToString();

                txtId.Enabled = false;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                btnAgregar.Enabled = false;
            }else
            {
                MessageBox.Show("Libro no Registrado");
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            objlibro.IdLibro = Convert.ToInt32(txtId.Text);
            objlibro.Titulo = txtTitulo.Text;
            objlibro.Paginas = txtNumPaginas.Text;
            objlibro.IdIdioma = Convert.ToInt32(cboIdioma.SelectedValue);
            objlibro.Autor = txtAutor.Text;
            objlibro.IdGenero = Convert.ToInt32(cboGenero.SelectedValue);
            objlibro.IdProveedor = Convert.ToInt32(cboProveedor.SelectedValue);
            objlibro.AñoPublicacion = txtAñoPubli.Text;
            objlibro.Descripcion = txtDescripcion.Text;
            objdatos.EditaLibro(objlibro);
            Limpiar();
            txtId.Enabled = true;
            MessageBox.Show("Se Modifico Correctamente");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Datos objdatos = new Datos();
            objlibro.IdLibro = Convert.ToInt32(txtId.Text);
            objdatos.EliminarLibro(objlibro);

            MessageBox.Show("Se Elimino Correctamente");
            Limpiar();
            txtId.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnAgregar.Enabled = true;
        }

        private void btnAgregarCopias_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Por favor, busca un libro primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Preguntar la cantidad de copias a agregar
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "¿Cuántas copias desea agregar?",
                "Agregar Copias",
                "1",
                -1,
                -1);

            if (int.TryParse(input, out int cantidadCopias) && cantidadCopias > 0)
            {
                // Crear instancia del formulario secundario
                FrmAgregarCopias frmAgregarCopias = new FrmAgregarCopias();

                // Pasar el Id del libro y la cantidad de copias al formulario
                frmAgregarCopias.IdLibro = Convert.ToInt32(txtId.Text);
                frmAgregarCopias.TituloLibro = txtTitulo.Text;
                frmAgregarCopias.CantidadCopias = cantidadCopias;

                // Mostrar el formulario como modal
                frmAgregarCopias.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un número válido mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
