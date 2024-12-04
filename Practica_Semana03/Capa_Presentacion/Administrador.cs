using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using Capa_Entidades;
using Capa_Negocio;

namespace Capa_Presentacion
{
    public partial class Administrador : Form
    {
        

        public Administrador()
        {
            String nombre = Login.nombre;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            labelTipoUsuario.Text = nombre;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            MessageBox.Show("Sesion Cerrada Correctamente","Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AbrirHijos(object usuarios)
        {
            if (this.pnlContenedor.Controls.Count > 0)
                this.pnlContenedor.Controls.RemoveAt(0);
            Form fh = usuarios as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnlContenedor.Controls.Add(fh);
            this.pnlContenedor.Tag = fh;
            fh.Show();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            AbrirHijos(new FrmUsuario());
            
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            AbrirHijos(new FrmProveedor());
            
        }

        private void btnPrestamo_Click(object sender, EventArgs e)
        {
            AbrirHijos(new FrmPrestamo());
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            AbrirHijos(new FrmLibros());
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            AbrirHijos(new FrmEstudiantes());
        }

        private void btnMultas_Click(object sender, EventArgs e)
        {
            AbrirHijos(new FrmMultas());
        }
        bool isFirstClick = true;
        private void btnReportes_Click(object sender, EventArgs e)
        {
            pnlReportes.Visible = !pnlReportes.Visible;
        }

        private void btnReporteUsuarios_Click(object sender, EventArgs e)
        {
            AbrirHijos(new FrmReporteUsuario());
            pnlReportes.Visible = false;
        }

        private void btnReporteProveedor_Click(object sender, EventArgs e)
        {
            AbrirHijos(new FrmReporteProveedor());
            pnlReportes.Visible = false;
        }

        private void btnReporteLibros_Click(object sender, EventArgs e)
        {
            AbrirHijos(new FrmReporteLibro());
            pnlReportes.Visible = false;
        }

        private void btnReportePrestamos_Click(object sender, EventArgs e)
        {
            AbrirHijos(new FrmReportePrestamo());
            pnlReportes.Visible = false;
        }

        private void btnReporteEstudiantes_Click(object sender, EventArgs e)
        {
            AbrirHijos(new FrmReporteEstudiante());
            pnlReportes.Visible = false;
        }
    }
}
