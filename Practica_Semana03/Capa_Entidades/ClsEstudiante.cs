using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class ClsEstudiante
    {
        public string Dni { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int IdGenero { get; set; }
        public String Correo { get; set; }
        public String Direccion { get; set; }
        public DateTime Fecha_Registro { get; set; }

        public ClsEstudiante() { }
        public ClsEstudiante(string dni, string nombre, string apellido, int idGenero, string correo, string direccion, DateTime fecha_Registro)
        {
            this.Dni = dni;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.IdGenero = idGenero;
            this.Correo = correo;
            this.Direccion = direccion;
            this.Fecha_Registro = fecha_Registro;
        }
    }
}
