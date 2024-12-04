using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class ClsCopias
    {
        public string Isbn { get; set; }
        public int IdLibro { get; set; }
        public string Estado { get; set; }

        public ClsCopias() { }

        public ClsCopias(string isbn, int idLibro, string estado)
        {
            this.Isbn = isbn;
            this.IdLibro = idLibro;
            this.Estado= estado;
        }
    }

}
