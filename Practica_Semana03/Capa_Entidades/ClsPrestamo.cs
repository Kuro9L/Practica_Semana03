using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class ClsPrestamo:ClsEstudiante
    {
        public int IdPrestamo { get; set; }
        public String DniEstudiante { get; set; }
        public int IdLibro { get; set; }
        public String Isbn { get; set; }
        public int TipoPrestamo { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set;}


        public ClsPrestamo() { }
        public ClsPrestamo(int idPrestamo, String dniEstudiante, int idLibro, string isbn, int tipoPrestamo, DateTime fechaPrestamo, DateTime fechaDevolucion, string dni, string nombre, string apellido, string correo, string direccion)
        {
            this.IdPrestamo = idPrestamo;
            this.DniEstudiante = dniEstudiante;
            this.IdLibro = idLibro;
            this.Isbn = isbn;
            this.TipoPrestamo = tipoPrestamo;
            this.FechaPrestamo = fechaPrestamo;
            this.FechaDevolucion = fechaDevolucion;


            this.Dni = dni;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Correo = correo;
            this.Direccion = direccion;

            
        }
    }
}
