using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcBook.Models
{
    public class MvcBookContext : DbContext
    {
        public MvcBookContext (DbContextOptions<MvcBookContext> options)
            : base(options)
        {
        }

        public DbSet<MvcBook.Models.Book> Book { get; set; }

        public DbSet<MvcBook.Models.Reservation> Reservation { get; set; }

    }
}
