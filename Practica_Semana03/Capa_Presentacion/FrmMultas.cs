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
    public partial class FrmMultas : Form
    {
        Negocio objNegocio = new Negocio();
        int IDMulta;
        
        public FrmMultas()
        {
            InitializeComponent();
            listarMulta();
        }

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
        void listarMultaId()
        {
            try
            {
                DataTable dt = objNegocio.N_listado_Id(Convert.ToInt32(txtId.Text));
                dgvMultas.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void listarMulta()
        {
            DataTable dt = objNegocio.N_listado(); dgvMultas.DataSource = dt;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listarMultaId();
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            listarMulta();
            txtId.Clear();
        }
    }
}
