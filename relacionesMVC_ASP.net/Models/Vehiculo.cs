using System.ComponentModel.DataAnnotations;

namespace relacionesMVC_ASP.net.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        /*
        [Required(ErrorMessage = "El campo Marca es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo Marca no puede superar los 50 caracteres.")]
        [Display(Name = "Marca del Vehículo")]
        public string Marca { get; set; } = string.Empty;
        */
        [Display(Name = "Marca")]
        public int MarcaId { get; set; }
        public Marca? Marca { get; set; } 


        [Required(ErrorMessage = "El campo Modelo es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo Modelo no puede superar los 50 caracteres.")]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Capacidad es obligatorio.")]
        [Range(1, 100, ErrorMessage = "La capacidad debe estar entre 1 y 100 pasajeros.")]
        [Display(Name = "Capacidad ")]
        public int Capacidad { get; set; }

        [Required(ErrorMessage = "El campo Color es obligatorio.")]
        [StringLength(30, ErrorMessage = "El campo Color no puede superar los 30 caracteres.")]
        [Display(Name = "Color")]
        public string Color { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Año de Fabricación es obligatorio.")]
        [Range(1900, 2100, ErrorMessage = "El año de fabricación debe estar entre 1900 y 2100.")]
        [Display(Name = "Año de Fabricación")]
        public int AnioFabricacion { get; set; }

        [Required(ErrorMessage = "El campo Precio es obligatorio.")]
        [Range(0, 10000000, ErrorMessage = "El precio debe estar entre 0 y 10000000.")]
        [Display(Name = "Precio")]
        public int Precio { get; set; } 


    }
}