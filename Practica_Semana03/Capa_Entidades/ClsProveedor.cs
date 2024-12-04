using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class ClsProveedor
    {
        public int IdProveedor { get; set; }
        public String Nombre { get; set; }
        public String Correo { get; set; }
        public String Telefono { get; set; }
        public String Ubicacion { get; set; }


        public ClsProveedor(){}

        public ClsProveedor (int idProveedor,String nombre, String correo, String Telefono, String Ubicacion)
        {
            this.IdProveedor = idProveedor;
            this.Nombre = nombre;
            this.Correo = correo;
            this.Telefono = Telefono;
            this.Ubicacion = Ubicacion;
            
        }



    }
}
