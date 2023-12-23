using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Groza_Ionut_Barbershop.Models
{
    public class Service
    {
        public int ServiceId { get; set; }

        [Required]
        public string ServiceName { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }
    }
}
