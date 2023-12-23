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

        public async Task OnGetAsync()
        {
            if (_context.Appointment != null)
            {
                Appointment = await _context.Appointment
                .Include(a => a.Barber)
                .Include(a => a.Customer)
                .Include(a => a.Service)
                .ToListAsync();
            }
        }
    }
}
