using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Capa_Entidades;
using Capa_Negocio;

namespace Capa_Presentacion
{
    public partial class Login : Form
    {
       
        // Instancia de clases de entidades y negocio
        Entidades objuser = new Entidades();
        Negocio objne = new Negocio();

        // Formularios a mostrar
        Principal frm1 = new Principal();
        Administrador frm2 = new Administrador();
        FrmPrestamo frm3 = new FrmPrestamo();

        // Variables estáticas para compartir datos entre formularios
        public static String usuario_nombre;
        public static String tipo_usuario;
        public static String nombre;

        void logueo()
        {
            // Crear DataTable para recibir los datos
            DataTable dt = new DataTable();
            objuser.usuario = txtUsuario.Text;
            objuser.contraseña = txtContraseña.Text;

            // Verificar los datos del usuario en la capa de negocio
            dt = objne.n_user(objuser);

            // Si hay datos (usuario encontrado)
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bienvenido " + dt.Rows[0][1].ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                usuario_nombre = dt.Rows[0][1].ToString(); // Nombre del usuario
                tipo_usuario = dt.Rows[0][4].ToString(); // Tipo de usuario (Administrador o Usuario)
                nombre = dt.Rows[0][1].ToString();

                // Evaluar el tipo de usuario para abrir el formulario adecuado
                if (tipo_usuario == "1")
                {
                    // Si es administrador, abrir el formulario de Administrador
                    Administrador frmAdmin = new Administrador();
                    this.Hide(); // Ocultar el formulario de login
                    frmAdmin.ShowDialog(); // Mostrar el formulario de Administrador
                    this.Show(); // Mostrar nuevamente el formulario de login al cerrar
                }
                else if (tipo_usuario == "2")
                {
                    // Si es usuario, abrir el formulario de Prestamo
                    FrmPrestamo frmPrestamo = new FrmPrestamo();
                    this.Hide(); // Ocultar el formulario de login
                    frmPrestamo.ShowDialog(); // Mostrar el formulario de Prestamo
                    this.Show(); // Mostrar nuevamente el formulario de login al cerrar
                }

                // Limpiar campos de usuario y contraseña
                txtUsuario.Clear();
                txtContraseña.Clear();
                
            }
            else
            {
                // Si los datos son incorrectos
                MessageBox.Show("Usuario o Contraseña Incorrecta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Focus();
                txtUsuario.Clear();
                txtContraseña.Clear();
            }
        }
        public Login()
        {
            InitializeComponent();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            CustomizeComponents();
            pnlUsuarioLogin.TabStop = false;
            panel3.TabStop = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            logueo();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCerrarLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizarLogin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void CustomizeComponents()
        {
            // txtUsuario
            txtUsuario.AutoSize = false;
            txtUsuario.Size = new Size(250, 25);
            txtUsuario.Padding = new Padding(0, 5, 0, 5);


            // txtContraseña
            txtContraseña.AutoSize = false;
            txtContraseña.Size = new Size(250, 25);
            txtContraseña.UseSystemPasswordChar = true;
            txtContraseña.Padding = new Padding(0, 5, 0, 5);
        }
        private void btnIngresar_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle myRectangle = btnIngresar.ClientRectangle;

            // Ajusta el tamaño del rectángulo
            myRectangle.Inflate(5, 30);

            // Añade una elipse al rectángulo
            buttonPath.AddEllipse(myRectangle);

            // Asigna la región elíptica al botón
            btnIngresar.Region = new Region(buttonPath);
        }
        private void pnlUsuarioLogin_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Puedes cambiar el color y grosor según desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
            txtUsuario.Focus();
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Puedes cambiar el color y grosor según desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
            KeyEventArgs simulatedKeyEvent = new KeyEventArgs(Keys.Tab);
            ProcesarTecla(simulatedKeyEvent);
        }
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            ProcesarTecla(e);
        }
        private void ProcesarTecla(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = false;  // Evita que el Tab siga el comportamiento predeterminado
                txtContraseña.Focus();  // Cambia el enfoque directamente al TextBox de contraseña
            }
        }

    }
}
