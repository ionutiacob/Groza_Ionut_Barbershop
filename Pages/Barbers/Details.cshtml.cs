﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Groza_Ionut_Barbershop.Data;
using Groza_Ionut_Barbershop.Models;

namespace Groza_Ionut_Barbershop.Pages.Barbers
{
    public class DetailsModel : PageModel
    {
        private readonly Groza_Ionut_Barbershop.Data.Groza_Ionut_BarbershopContext _context;

        public DetailsModel(Groza_Ionut_Barbershop.Data.Groza_Ionut_BarbershopContext context)
        {
            _context = context;
        }

      public Barber Barber { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Barber == null)
            {
                return NotFound();
            }

            var barber = await _context.Barber.FirstOrDefaultAsync(m => m.BarberId == id);
            if (barber == null)
            {
                return NotFound();
            }
            else 
            {
                Barber = barber;
            }
            return Page();
        }
    }
}
