using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Entidades;
using System.Security.AccessControl;
using System.Collections;

namespace Capa_Datos
{
    public class Datos
    {
        private Conexion Conexion = new Conexion();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;

        public DataTable D_user(Entidades obje)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "logeo1";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@usuario", obje.usuario);
            Comando.Parameters.AddWithValue("@contraseña", obje.contraseña);
            SqlDataAdapter da = new SqlDataAdapter(Comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
            return dt;
        }


        public DataTable D_Multas()
        {
            SqlCommand cmd = new SqlCommand("select * from Multas", Conexion.AbrirConexion());
            cmd.CommandType = CommandType.Text; SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_Multas_Id(int bus)
        {
            SqlCommand cmd = new SqlCommand("select * from Multas where id=" + bus, Conexion.AbrirConexion());
            cmd.CommandType = CommandType.Text; SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable TipoUsuario()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "TipoUsuario";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return tabla;
        }

        public DataTable ListarGenero()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarGenero";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ListarProveedor()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarProveedor";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ListarSexo()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarSexo";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return tabla;
        }
        public DataTable TipoPrestamo()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "TipoPrestamo";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ListarEstudiante()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarEstudiante";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ListaIdioma()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarIdioma";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return tabla;
        }



        //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ Datos Para Usuario ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓//
        public void InsertarUsuario(ClsUsuario enn)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarUsuario";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id_area", enn.Id_area);
            Comando.Parameters.AddWithValue("@nombre", enn.Nombre);
            Comando.Parameters.AddWithValue("@usuario", enn.Usuario);
            Comando.Parameters.AddWithValue("@contraseña", enn.Contraseña);
            Comando.Parameters.AddWithValue("@tipo_usuario", enn.Tipo_usuario);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public DataTable Buscar(ClsUsuario obje)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "buscar";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id_empleado", obje.Id_empleado);
            Comando.Parameters.AddWithValue("@id_area", obje.Id_area);
            Comando.Parameters.AddWithValue("@nombre", obje.Nombre);
            Comando.Parameters.AddWithValue("@usuario", obje.Usuario);
            Comando.Parameters.AddWithValue("@contraseña", obje.Contraseña);
            Comando.Parameters.AddWithValue("@tipo_usuario", obje.Tipo_usuario);
            SqlDataAdapter da = new SqlDataAdapter(Comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
            return dt;
        }
        public void EditaUsuario(ClsUsuario enn)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EditaUsuario";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id_area", enn.Id_area);
            Comando.Parameters.AddWithValue("@nombre", enn.Nombre);
            Comando.Parameters.AddWithValue("@usuario", enn.Usuario);
            Comando.Parameters.AddWithValue("@contraseña", enn.Contraseña);
            Comando.Parameters.AddWithValue("@tipo_usuario", enn.Tipo_usuario);
            Comando.Parameters.AddWithValue("@id_empleado", enn.Id_empleado);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void EliminarUsuario(ClsUsuario enn)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "delete usuario where id_empleado=" + enn.Id_empleado;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }




        //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ Datos Para Proveedor ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓//

        public DataTable BuscarProveedor(ClsProveedor obje)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarProveedor";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", obje.IdProveedor);
            Comando.Parameters.AddWithValue("@nombre", obje.Nombre);
            Comando.Parameters.AddWithValue("@correo", obje.Correo);
            Comando.Parameters.AddWithValue("@telefono", obje.Telefono);
            Comando.Parameters.AddWithValue("@ubicacion", obje.Ubicacion);
            SqlDataAdapter da = new SqlDataAdapter(Comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
            return dt;
        }
        public void InsertarProveedor(ClsProveedor enn)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarProveedor";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", enn.IdProveedor);
            Comando.Parameters.AddWithValue("@nombre", enn.Nombre);
            Comando.Parameters.AddWithValue("@correo", enn.Correo);
            Comando.Parameters.AddWithValue("@telefono", enn.Telefono);
            Comando.Parameters.AddWithValue("@ubicacion", enn.Ubicacion);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void EditaProveedor(ClsProveedor enn)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EditarProveedor";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", enn.IdProveedor);
            Comando.Parameters.AddWithValue("@nombre", enn.Nombre);
            Comando.Parameters.AddWithValue("@correo", enn.Correo);
            Comando.Parameters.AddWithValue("@telefono", enn.Telefono);
            Comando.Parameters.AddWithValue("@ubicacion", enn.Ubicacion);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void EliminarProveedor(ClsProveedor enn)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "delete Proveedor where id=" + enn.IdProveedor;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }




        //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ Datos Para Libro ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓//
        public DataTable BuscarLibro(ClsLibros obje)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarLibro";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", obje.IdLibro);
            Comando.Parameters.AddWithValue("@titulo", obje.Titulo);
            Comando.Parameters.AddWithValue("@paginas", obje.Paginas);
            Comando.Parameters.AddWithValue("@idioma_id", obje.IdIdioma);
            Comando.Parameters.AddWithValue("@autor", obje.Autor);
            Comando.Parameters.AddWithValue("@genero_id", obje.IdGenero);
            Comando.Parameters.AddWithValue("@proveedor_id", obje.IdProveedor);
            Comando.Parameters.AddWithValue("@año_publicacion", obje.AñoPublicacion);
            Comando.Parameters.AddWithValue("@descripcion", obje.Descripcion);
            SqlDataAdapter da = new SqlDataAdapter(Comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
            return dt;
        }
        public void InsertarLibro(ClsLibros enn)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarLibro";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", enn.IdLibro);
            Comando.Parameters.AddWithValue("@titulo", enn.Titulo);
            Comando.Parameters.AddWithValue("@paginas", enn.Paginas);
            Comando.Parameters.AddWithValue("@idioma_id", enn.IdIdioma);
            Comando.Parameters.AddWithValue("@autor", enn.Autor);
            Comando.Parameters.AddWithValue("@genero_id", enn.IdGenero);
            Comando.Parameters.AddWithValue("@proveedor_id", enn.IdProveedor);
            Comando.Parameters.AddWithValue("@año_publicacion", enn.AñoPublicacion);
            Comando.Parameters.AddWithValue("@descripcion", enn.Descripcion);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void EditaLibro(ClsLibros enn)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EditarLibro";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", enn.IdLibro);
            Comando.Parameters.AddWithValue("@titulo", enn.Titulo);
            Comando.Parameters.AddWithValue("@paginas", enn.Paginas);
            Comando.Parameters.AddWithValue("@idioma_id", enn.IdIdioma);
            Comando.Parameters.AddWithValue("@autor", enn.Autor);
            Comando.Parameters.AddWithValue("@genero_id", enn.IdGenero);
            Comando.Parameters.AddWithValue("@proveedor_id", enn.IdProveedor);
            Comando.Parameters.AddWithValue("@año_publicacion", enn.AñoPublicacion);
            Comando.Parameters.AddWithValue("@descripcion", enn.Descripcion);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();

        }
        public void EliminarLibro(ClsLibros enn)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "delete Libros where id=" + enn.IdLibro;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }




        //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ Datos Para Estudiante ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓//
        public DataTable BuscarEstudiante(ClsEstudiante obje)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarEstudiante";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@dni", obje.Dni);
            Comando.Parameters.AddWithValue("@nombre", obje.Nombre);
            Comando.Parameters.AddWithValue("@apellido", obje.Apellido);
            Comando.Parameters.AddWithValue("@sexo_id", obje.IdGenero);
            Comando.Parameters.AddWithValue("@correo", obje.Correo);
            Comando.Parameters.AddWithValue("@direccion", obje.Direccion);
            Comando.Parameters.AddWithValue("@fecha_registro", obje.Fecha_Registro);
            SqlDataAdapter da = new SqlDataAdapter(Comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
            return dt;
        }
        public void InsertarEstudiante(ClsEstudiante enn)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarEstudiante";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@dni", enn.Dni);
            Comando.Parameters.AddWithValue("@nombre", enn.Nombre);
            Comando.Parameters.AddWithValue("@apellido", enn.Apellido);
            Comando.Parameters.AddWithValue("@sexo_id", enn.IdGenero);
            Comando.Parameters.AddWithValue("@correo", enn.Correo);
            Comando.Parameters.AddWithValue("@direccion", enn.Direccion);
            Comando.Parameters.AddWithValue("@fecha_registro", enn.Fecha_Registro);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void EditaEstudiante(ClsEstudiante enn)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "EditarEstudiante";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@dni", enn.Dni);
            Comando.Parameters.AddWithValue("@nombre", enn.Nombre);
            Comando.Parameters.AddWithValue("@apellido", enn.Apellido);
            Comando.Parameters.AddWithValue("@sexo_id", enn.IdGenero);
            Comando.Parameters.AddWithValue("@correo", enn.Correo);
            Comando.Parameters.AddWithValue("@direccion", enn.Direccion);
            Comando.Parameters.AddWithValue("@fecha_registro", enn.Fecha_Registro);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();

        }
        public void EliminarEstudiante(ClsEstudiante enn)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "delete Estudiante where dni=" + enn.Dni;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }



        //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ Datos Para Prestamo ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓//
        public DataTable BuscarPrestamo(ClsPrestamo obje)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarPrestamoss";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", obje.IdPrestamo);
            Comando.Parameters.AddWithValue("@dni_estudiante", obje.DniEstudiante);
            Comando.Parameters.AddWithValue("@libro_id", obje.IdLibro);
            Comando.Parameters.AddWithValue("@isbn", obje.Isbn);
            Comando.Parameters.AddWithValue("@tipo_prestamo", obje.TipoPrestamo);
            Comando.Parameters.AddWithValue("@fecha_emision", obje.FechaPrestamo);
            Comando.Parameters.AddWithValue("@fecha_devolucion", obje.FechaDevolucion);
            Comando.Parameters.AddWithValue("@nombre", obje.Nombre);
            Comando.Parameters.AddWithValue("@apellido", obje.Apellido);
            Comando.Parameters.AddWithValue("@correo", obje.Correo);
            Comando.Parameters.AddWithValue("@direccion", obje.Direccion);

            SqlDataAdapter da = new SqlDataAdapter(Comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
            return dt;
        }
        public void InsertarPrestamo(ClsPrestamo enn)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarPrestamo";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", enn.IdPrestamo);
            Comando.Parameters.AddWithValue("@dni_estudiante", enn.DniEstudiante);
            Comando.Parameters.AddWithValue("@libro_id", enn.IdLibro);
            Comando.Parameters.AddWithValue("@isbn", enn.Isbn);
            Comando.Parameters.AddWithValue("@tipo_prestamo", enn.TipoPrestamo);
            Comando.Parameters.AddWithValue("@fecha_emision", enn.FechaPrestamo);
            Comando.Parameters.AddWithValue("@fecha_devolucion", enn.FechaDevolucion);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void EditaPrestamo(ClsPrestamo enn)
        { 
        }
        public void EliminarPrestamo(ClsPrestamo enn)
        {
        }

        public DataTable BuscarEstudiantePrestamo(ClsEstudiante obje)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "BuscarEstudiantePrestamo";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@dni", obje.Dni);
            Comando.Parameters.AddWithValue("@nombre", obje.Nombre);
            Comando.Parameters.AddWithValue("@apellido", obje.Apellido);
            Comando.Parameters.AddWithValue("@correo", obje.Correo);
            Comando.Parameters.AddWithValue("@direccion", obje.Direccion);
            SqlDataAdapter da = new SqlDataAdapter(Comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Comando.Parameters.Clear();
            Conexion.CerrarConexion();
            return dt;
        }

        public void InsertarCopia(ClsCopias enn)
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarCopia";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@id", enn.Isbn);
            Comando.Parameters.AddWithValue("@libro_id", enn.IdLibro);
            Comando.Parameters.AddWithValue("@estado", enn.Estado);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
    }
}
