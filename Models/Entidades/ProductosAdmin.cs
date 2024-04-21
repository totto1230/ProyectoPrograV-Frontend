using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login1.Models.Entidades
{
    public class ProductosAdmin
    {
        public int?[] IdProducto { get; set; }
        public string[] Name { get; set; }
        public int?[] Cantidad { get; set; }
        public decimal?[] Precio { get; set; }
        public char?[] Categoria { get; set; }
    }
}
