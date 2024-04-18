namespace Login1.Models
{
    public class OrdenA
    {
        public string? NumeroCliente { get; set; }
        public string? NombreProductos { get; set; }
        public string? Cantidad { get; set; }
        public string? Coordenadas { get; set; }
        public double? TotalComprarOrden { get; set; }
        public double? CostoViaje { get; set; }

        public int NumOrder { get; set; }
        //public int[] CantidadProductosxOrden { get; set; }
    }
}
