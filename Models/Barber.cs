using System.ComponentModel.DataAnnotations;

namespace Groza_Ionut_Barbershop.Models
{
    public class Barber
    {
        public int BarberId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Firstname should start with uppercase character")]
        [StringLength(100, ErrorMessage = "Maximum 100 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Last name should start with uppercase character")]
        [StringLength(100, ErrorMessage = "Maximum 100 characters")]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [RegularExpression(@"^0\d{2,3}[-. ]?\d{3}[-. ]?\d{3}$", ErrorMessage = "Phone number should start with '0' and should have the following format: '0722-123-123', '0722.123.123', or '0722 123 123'")]
        public string Phone { get; set; }

        [StringLength(200, ErrorMessage = "Maximum 200 characters")]
        public string Address { get; set; }
    }
}
