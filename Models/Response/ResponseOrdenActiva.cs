namespace Login1.Models.Response
{
    public class ResponseOrdenActiva : ResponseBase
    {
        public string NumeroCliente { get; set; }
        public List<Product> Productos { get; set; }
        public string Coordenadas { get; set; }
        public string TotalComprarOrden { get; set; }
        public string CostoViaje { get; set; }
        public bool Completada { get; set; }
    }
}
