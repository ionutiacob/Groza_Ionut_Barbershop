using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Groza_Ionut_Barbershop.Models;

namespace Groza_Ionut_Barbershop.Data
{
    public class Groza_Ionut_BarbershopContext : DbContext
    {
        public Groza_Ionut_BarbershopContext (DbContextOptions<Groza_Ionut_BarbershopContext> options)
            : base(options)
        {
        }

        public DbSet<Groza_Ionut_Barbershop.Models.Appointment> Appointment { get; set; } = default!;

        public DbSet<Groza_Ionut_Barbershop.Models.Barber>? Barber { get; set; }

        public DbSet<Groza_Ionut_Barbershop.Models.Customer>? Customer { get; set; }

        public DbSet<Groza_Ionut_Barbershop.Models.Service>? Service { get; set; }
    }
}
