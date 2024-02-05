using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityTier;

namespace DataAccessTier 
{
    public class AppDbContext : DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Types> Contacttypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
