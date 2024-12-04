using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Entidades;

namespace Capa_Datos
{
    public class Conexion
    {
        static private string CadenaConexion = "server=DESKTOP-BE0IPE6\\SQLEXPRESS;DataBase=UsuarioLogin1;Integrated Security=true";
        private SqlConnection Coneccion= new SqlConnection(CadenaConexion);
        public SqlConnection AbrirConexion()
        {
         if (Coneccion.State==ConnectionState.Closed)
             Coneccion.Open();
         return Coneccion;
        }

        public SqlConnection CerrarConexion()
        {
            if (Coneccion.State == ConnectionState.Open)
                Coneccion.Close();
            return Coneccion;
        }
    }
}
