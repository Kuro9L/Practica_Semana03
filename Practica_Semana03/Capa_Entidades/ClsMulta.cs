using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    internal class ClsMulta
    {
        public int MultaID { get; set; }
        public DateTime FechaPago { get; set; }
        public double Monto { get; set; }
        public int PrestamoID { get; set; }
    }
}
