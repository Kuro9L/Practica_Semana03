using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class ClsUsuario
    {
        public int Id_empleado { get; set; }
        public String Id_area { get; set; }
        public String Nombre { get; set; }
        public String Usuario { get; set; }
        public String Contraseña { get; set; }
        public int Tipo_usuario { get; set; }


        public ClsUsuario() { }
        public ClsUsuario(int id_empleado, string id_area, string nombre, string usuario, string contraseña, int tipo_usuario)
        {
            this.Id_empleado = id_empleado;
            this.Id_area = id_area;
            this.Nombre = nombre;
            this.Usuario = usuario;
            this.Contraseña = contraseña;
            this.Tipo_usuario = tipo_usuario;
        }
    }
}
