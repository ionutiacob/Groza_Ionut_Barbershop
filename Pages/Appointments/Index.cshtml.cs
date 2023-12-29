using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Groza_Ionut_Barbershop.Data;
using Groza_Ionut_Barbershop.Models;

namespace Groza_Ionut_Barbershop.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly Groza_Ionut_Barbershop.Data.Groza_Ionut_BarbershopContext _context;

        public IndexModel(Groza_Ionut_Barbershop.Data.Groza_Ionut_BarbershopContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; } = default!;

        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;

            if (_context.Appointment != null)
            {
                Appointment = await _context.Appointment
                .Include(a => a.Barber)
                .Include(a => a.Customer)
                .Include(a => a.Service).ToListAsync();
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                Appointment = Appointment.Where(s =>
                    s.Barber.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    s.Barber.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    s.Customer.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    s.Customer.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }
        }
    }
}
