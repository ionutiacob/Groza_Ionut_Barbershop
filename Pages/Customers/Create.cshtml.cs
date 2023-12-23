using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Groza_Ionut_Barbershop.Data;
using Groza_Ionut_Barbershop.Models;

namespace Groza_Ionut_Barbershop.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly Groza_Ionut_Barbershop.Data.Groza_Ionut_BarbershopContext _context;

        public CreateModel(Groza_Ionut_Barbershop.Data.Groza_Ionut_BarbershopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Customer == null || Customer == null)
            {
                return Page();
            }

            _context.Customer.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
