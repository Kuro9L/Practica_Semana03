using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Capa_Entidades;
using Capa_Datos;
using System.Runtime.Remoting;
using Capa_Negocio;

namespace Capa_Presentacion
{
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            

        }
        ClsUsuario objusuario = new ClsUsuario();
        Negocio objne = new Negocio();

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
        private void pnlArea_Paint(object sender, PaintEventArgs e)
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
        private void pnlUsuario_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Puedes cambiar el color y grosor según desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
        }
        private void pnlContraseña_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Puedes cambiar el color y grosor según desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
        }
        private void pnlReContraseña_Paint(object sender, PaintEventArgs e)
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
            // Crear DataTable para recibir los datos
            DataTable dt = new DataTable();
            objusuario.Id_empleado = Convert.ToInt32(txtId.Text);
            objusuario.Id_area = txtArea.Text;
            objusuario.Nombre = txtNombre.Text;
            objusuario.Usuario= txtUsuario.Text;
            objusuario.Contraseña=txtContraseña.Text;
            objusuario.Contraseña = txtReContraseña.Text;
            objusuario.Tipo_usuario = Convert.ToInt32(cboTipoUsuario.SelectedValue);

            // Verificar los datos del usuario en la capa de negocio
            dt = objne.Buscarusuario(objusuario);


            if (dt.Rows.Count > 0)
            {
                txtId.Text= dt.Rows[0][0].ToString();
                txtArea.Text = dt.Rows[0][1].ToString();
                txtNombre.Text = dt.Rows[0][2].ToString();
                txtUsuario.Text = dt.Rows[0][3].ToString();
                txtContraseña.Text = dt.Rows[0][4].ToString();
                txtReContraseña.Text = dt.Rows[0][4].ToString();
                cboTipoUsuario.SelectedValue = Convert.ToInt32(dt.Rows[0][5].ToString());
                txtId.Enabled = false;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                btnAgregar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Usuario No Registrado");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Datos objdatos = new Datos();

            if (txtContraseña.Text != txtReContraseña.Text)
            {
                MessageBox.Show("Las Contraseñas no son Identicas");

            }
            else
            {
                objusuario.Id_empleado = Convert.ToInt32(txtId.Text);
                objusuario.Id_area = txtArea.Text;
                objusuario.Nombre = txtNombre.Text;
                objusuario.Usuario = txtUsuario.Text;
                objusuario.Contraseña = txtContraseña.Text;
                objusuario.Tipo_usuario = Convert.ToInt32(cboTipoUsuario.SelectedValue);
                objdatos.EditaUsuario(objusuario);
                Limpiar();
                txtId.Enabled = true;
                MessageBox.Show("Se Modifico Correctamente");
            }
            
            
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnAgregar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Datos objdatos = new Datos();
            objusuario.Id_empleado = Convert.ToInt32(txtId.Text);
            objdatos.EliminarUsuario(objusuario);

            MessageBox.Show("Se Elimino Correctamente"); 
            Limpiar();
            txtId.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnAgregar.Enabled = true;
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            TipoUsuario();
        }
        
        private void TipoUsuario()
        {
            Datos objusua = new Datos();
            cboTipoUsuario.DataSource = objusua.TipoUsuario();
            cboTipoUsuario.DisplayMember = "tipo_usuario";
            cboTipoUsuario.ValueMember = "id_tipousuario";
        }
        

        private void Limpiar()
        {
            txtArea.Clear();
            txtNombre.Clear();
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtReContraseña.Clear();
            txtId.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Datos objdatos = new Datos();

            if (txtContraseña.Text != txtReContraseña.Text)
            {
                MessageBox.Show("Las Contraseñas no son Identicas");

            }
            else
            {
                    objusuario.Tipo_usuario = Convert.ToInt32(cboTipoUsuario.SelectedValue);
                    objusuario.Id_area = txtArea.Text;
                    objusuario.Nombre = txtNombre.Text;
                    objusuario.Usuario = txtUsuario.Text;
                    objusuario.Contraseña = txtContraseña.Text;
                    objdatos.InsertarUsuario(objusuario);

                    MessageBox.Show("Se Agrego Correctamente");
            }
            Limpiar();
        }
    }
}
