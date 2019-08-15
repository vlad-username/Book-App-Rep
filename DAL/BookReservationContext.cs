//using Microsoft.EntityFrameworkCore;
//using MvcBook.Models;

//namespace MvcBook.DAL
//{
//    public class BookReservationContext : DbContext
//    {
//        internal object books;
//        internal object Reservations;

//        public BookReservationContext() : base()
//        {
//        }

//        public DbSet<Book> Bookss { get; set; }
//        public DbSet<Reservation> Reservationss { get; set; }


//        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        //{
//        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
//        //}
//    }
//}