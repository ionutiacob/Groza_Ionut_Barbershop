using System.ComponentModel.DataAnnotations;

namespace Groza_Ionut_Barbershop.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int BarberId { get; set; }
        public Barber Barber { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public string Notes { get; set; }
    }
}
