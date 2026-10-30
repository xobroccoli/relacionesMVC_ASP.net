using System.ComponentModel.DataAnnotations;

namespace relacionesMVC_ASP.net.Models
{
    public class Marca
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        [Display(Name = "Nombre de la marca")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El país de origen es obligatorio")]
        [StringLength(40, ErrorMessage = "El país no puede superar los 40 caracteres")]
        [Display(Name = "País de origen")]
        public string PaisOrigen { get; set; } = string.Empty;

        [Required(ErrorMessage = "El año de fundación es obligatorio")]
        [Range(1800, 2026, ErrorMessage = "El año debe estar entre 1800 y 2026")]
        [Display(Name = "Año de fundación")]
        public int AnioFundacion { get; set; }

       
        public ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
    }
}