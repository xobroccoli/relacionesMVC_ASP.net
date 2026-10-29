namespace relacionesMVC_ASP.net.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }

        public string Marca { get; set; } = string.Empty;

        public string Modelo { get; set; } = string.Empty;

        public int Capacidad { get; set; }

        public string Color {  get; set; } = string.Empty;

        public int AnioFabricacion { get; set; }

        public int Precio { get; set; }
    }
}
