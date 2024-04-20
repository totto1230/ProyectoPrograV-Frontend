using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login1.Models.Entidades
{
    public class OrdenActivaCompletar
    {
        public bool completada { get; set; }

        public string numDriver { get; set; }

        public int idOrden { get; set; }

        public DateTime fecha { get; set; }
    }
}
