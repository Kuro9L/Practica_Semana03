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
using static System.Windows.Forms.AxHost;

namespace Capa_Presentacion
{
    public partial class FrmAgregarCopias : Form
    {
        public FrmAgregarCopias()
        {
            InitializeComponent();
        }
        Negocio objne = new Negocio();
        Datos objdatos = new Datos();

        public string TituloLibro { get; set; }
        public int IdLibro { get; set; }
        public int CantidadCopias { get; set; }


        private void FrmAgregarCopias_Load(object sender, EventArgs e)
        {
            // Asegúrate de que el tamaño del formulario sea adecuado para los controles
            this.Size = new Size(500, 500); // Ajusta el tamaño del formulario a tus necesidades

            // Crear el Label para mostrar el TituloLibro
            Label lblIdLibro = new Label
            {
                Text = $"{TituloLibro}",
                Font = new Font("Century Gothic", 20.25f, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true // Esto hace que el Label se ajuste al texto
            };

            // Calcular la posición centrada en el formulario
            lblIdLibro.Location = new Point((this.ClientSize.Width - lblIdLibro.Width) / 2, 20); // Centrado en el formulario

            // Agregar el Label al formulario
            this.Controls.Add(lblIdLibro);

            // Establecer la posición inicial para los demás controles
            int startX = 20;    // Posición inicial de la columna
            int startY = 80;    // Posición inicial en Y
            int spacingY = 40;  // Espaciado entre los controles en Y
            int columnWidth = 400; // Ancho de la columna para los controles
            int maxISBNPorColumna = 10; // Máximo de ISBN por columna

            for (int i = 0; i < CantidadCopias; i++)
            {
                // Calcular la columna y fila
                int column = i / maxISBNPorColumna; // Número de columna (cada 10 ISBN se mueve a la siguiente columna)
                int row = i % maxISBNPorColumna;    // Número de fila dentro de la columna

                // Crear un Label para el campo de ISBN
                Label lblISBN = new Label
                {
                    Text = $"ISBN #{i + 1}:",
                    Location = new Point(startX + (column * columnWidth), startY + (row * spacingY)),
                    AutoSize = true,
                    Font = new Font("Century Gothic", 20.25f, FontStyle.Bold), // Aplicar el estilo a la fuente
                    ForeColor = Color.White // Establecer el color del texto
                };
                this.Controls.Add(lblISBN);

                // Crear un Panel para contener el TextBox
                Panel pnlTextBox = new Panel
                {
                    Location = new Point(startX + 135 + (column * columnWidth), startY + (row * spacingY) - 7), // Ajustar la posición
                    Size = new Size(225, 38), // Tamaño del panel
                };
                pnlTextBox.Paint += panel1_Paint; // Evento Paint para dibujar la línea en la parte inferior
                this.Controls.Add(pnlTextBox);

                // Crear un TextBox dentro del Panel
                TextBox txtISBN = new TextBox
                {
                    Name = $"txtISBN{i + 1}",
                    BackColor = Color.FromArgb(49, 66, 82), // Establecer el color de fondo
                    BorderStyle = BorderStyle.None, // Establecer el estilo del borde
                    Width = 219, // Ancho del TextBox
                    Height = 24, // Altura del TextBox
                    ForeColor = Color.White, // Establecer el color del texto
                    Font = new Font("Century Gothic", 14f) // Estilo de la fuente del TextBox
                };

                // Asegurarse de que el TextBox esté alineado con la línea del Panel (parte inferior)
                txtISBN.Location = new Point((pnlTextBox.ClientSize.Width - txtISBN.Width) / 2, pnlTextBox.ClientSize.Height - txtISBN.Height - 3);

                pnlTextBox.Controls.Add(txtISBN);
            }

            // Ajustar el tamaño del formulario dinámicamente según la cantidad de copias
            int columnas = (int)Math.Ceiling((double)CantidadCopias / maxISBNPorColumna); // Número total de columnas
            this.Height = startY + (Math.Min(CantidadCopias, maxISBNPorColumna) * spacingY) + 100; // Ajustar altura según filas
            this.Width = startX + (columnas * columnWidth) + 20; // Ajustar ancho según el número de columnas

            CrearBotonAgregar();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                // Color y grosor de la línea inferior
                Pen pen = new Pen(Color.White, 2); // Cambia el color y grosor según lo desees
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1); // Dibuja la línea en la parte inferior
            }
        }

        private void CrearBotonAgregar()
        {
            int startY = 80;    // Posición inicial en Y
            int spacingY = 40;  // Espaciado entre los controles en Y

            // Crear el botón "Agregar"
            Button btnAgregar = new Button
            {
                Text = "Agregar Copias",   // Texto que se mostrará en el botón
                Size = new Size(150, 40),  // Tamaño del botón
                Location = new Point(20, startY + (CantidadCopias * spacingY) + 40),  // Ubicación del botón, ajustado según el formulario
                BackColor = Color.FromArgb(49, 66, 82), // Color de fondo
                ForeColor = Color.White,  // Color del texto
                Font = new Font("Century Gothic", 12f, FontStyle.Bold), // Estilo de la fuente
            };

            // Asignar el evento Click al botón
            btnAgregar.Click += new EventHandler(btnAgregar_Click);

            // Agregar el botón al formulario
            this.Controls.Add(btnAgregar);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Datos objdatos = new Datos();
            // Asegurarse de que el campo IdLibro esté lleno antes de agregar copias
            if (IdLibro == 0)
            {
                MessageBox.Show("Por favor, ingrese un ID de libro.");
                return;
            }



            // Recorremos todos los controles en el formulario
            foreach (Control control in this.Controls)
            {
                // Verificar si el control es un TextBox (donde se ingresaron los ISBN)
                if (control is TextBox txtISBN && txtISBN.Name.StartsWith("txtISBN"))
                {
                    // Crear el objeto de copia para cada ISBN
                    ClsCopias objcopia = new ClsCopias
                    {
                        Isbn = txtISBN.Text,     // El ISBN de cada TextBox
                        IdLibro = IdLibro,       // El mismo IdLibro para todas las copias
                        Estado = "Disponible"    // El estado será "Disponible"
                    };

                    // Llamar al método para insertar la copia en la base de datos o lista
                    objdatos.InsertarCopia(objcopia);
                }
            }

            // Mostrar mensaje de éxito
            MessageBox.Show("Se Agregaron las Copias Correctamente.");
        }


    }
}
