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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            if (Login.tipo_usuario == "Administrador")
            {
                btnIngresarUsuario.Enabled = true;
                btnIngresarProducto.Enabled = true;
                lblCargar.Text = "Administrador";

            }
            else if(Login.tipo_usuario =="Usuario")
            {
                btnIngresarUsuario.Enabled = false;
                btnIngresarProducto.Enabled = true;
                lblCargar.Text = "Usuario";

            }
        }
    }
}
