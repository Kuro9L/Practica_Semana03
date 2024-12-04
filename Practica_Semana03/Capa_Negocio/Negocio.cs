using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidades;
using static Capa_Negocio.Negocio;

namespace Capa_Negocio
{
    public class Negocio
    {
        Datos Objed = new Datos();
        Datos objDato = new Datos();
        public DataTable n_user(Entidades obje)
        {
            return Objed.D_user(obje);

        }

        public DataTable N_listado()
        {
            return objDato.D_Multas();
        }


        public DataTable N_listado_Id(int bus)
        {
            return objDato.D_Multas_Id(bus);
        }

        public DataTable Buscarusuario(ClsUsuario obje)
        {
            return Objed.Buscar(obje);

        }

        public DataTable BuscarProveedor(ClsProveedor obje)
        {
            return Objed.BuscarProveedor(obje);

        }

        public DataTable BuscarLibro(ClsLibros obje)
        {
            return Objed.BuscarLibro(obje);

        }

        public DataTable BuscarEstudiante(ClsEstudiante obje)
        {
            return Objed.BuscarEstudiante(obje);

        }

        public DataTable BuscarPrestamo(ClsPrestamo obje)
        {
            return Objed.BuscarPrestamo(obje);

        }

        public DataTable BuscarEstudiantePrestamo(ClsEstudiante obje)
        {
            return Objed.BuscarEstudiantePrestamo(obje);

        }

    }
}
