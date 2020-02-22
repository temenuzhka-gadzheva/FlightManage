using FlightManage.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManage.Data
{
    public class FlightDbContext :DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-UF96G8T\SQLEXPRESS;Initial Catalog=MyLibraryDb; Trusted_Connection=true ");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
