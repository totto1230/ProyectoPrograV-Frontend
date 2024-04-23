using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login1.Models.Entidades
{
    public class Orden
    {
        //NUMBER COMPRADOR
        public string Numero { get; set; }

        //PRODUCTO
        public int?[] IdProducto { get; set; }

        public int?[] Cantidad { get; set; }

        public double?[] coordenadas { get; set; }

        //public double[] totalComprar { get; set; }

        //Tarjeta
        public string NumeroTar { get; set; }

        public string code { get; set; }

        public DateTime expiration { get; set; }
    }
}
