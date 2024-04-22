using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login1.Models.Entidades
{
    public class ProductosAdminActualizar
    {
        public int id { get; set; }

        public char categoria { get; set; }

        public decimal precio { get; set; }

        public int cantidad { get; set; }
    }
}
