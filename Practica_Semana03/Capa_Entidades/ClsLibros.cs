using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class ClsLibros
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Paginas { get; set; }
        public int IdIdioma { get; set; }
        public string Autor { get; set; }
        public int IdGenero { get; set; }
        public int IdProveedor { get; set; }
        public string AñoPublicacion { get; set; }
        public String Descripcion { get; set; }

        public ClsLibros() { }
        public ClsLibros(int idLibro , string titulo,string paginas, int idIdioma,string autor, int idGenero,int idProveedor, string añoPublicacion, String descripcion)
        {
            this.IdLibro = idLibro;
            this.Titulo = titulo;
            this.Paginas = paginas;
            this.IdIdioma = idIdioma;
            this.Autor = autor;
            this.IdGenero = idGenero;
            this.IdProveedor= idProveedor;
            this.AñoPublicacion = añoPublicacion;
            this.Descripcion = descripcion;
        }
    }


}
