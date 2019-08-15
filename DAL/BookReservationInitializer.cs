//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;


//using System.Threading.Tasks;
//using MvcBook.Models;

//namespace MvcBook.DAL
//{
//    public class BookReservationInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BookReservationContext>
//    {
//        protected void Seed(BookReservationContext context)
//        {

//            var books = new List<Book>
//            {
//            new Book{Id=1050,Title="Chemistry",ReleaseDate=DateTime.Parse("1989-2-12"),Genre="Sci-Fi",Price=9.67M,},
//            new Book{Id=2050,Title="ABC",ReleaseDate=DateTime.Parse("1999-2-12"),Genre="Sci-Fi",Price=9.17M,},
//            new Book{Id=3050,Title="Math",ReleaseDate=DateTime.Parse("2020-2-12"),Genre="Sci-Fi",Price=4.67M,},
//            };
//            books.ForEach(s => context.Bookss.Add(s));
//            context.SaveChanges();

//            var reservations = new List<Reservation>
//            {
//            new Reservation{Id=1,BookId=1050,Title="Chemistry",ReservationDate=DateTime.Parse("2020-2-12"),ReturnDate=DateTime.Parse("2020-2-13")},
//            new Reservation{Id=2,BookId=1050,Title="Chemistry",ReservationDate=DateTime.Parse("2020-2-12"),ReturnDate=DateTime.Parse("2020-2-13")},
//            new Reservation{Id=3,BookId=2050,Title="ABC",ReservationDate=DateTime.Parse("2020-2-12"),ReturnDate=DateTime.Parse("2020-2-13")},
//            new Reservation{Id=4,BookId=3050,Title="Math",ReservationDate=DateTime.Parse("2020-2-12"),ReturnDate=DateTime.Parse("2020-2-13")},
//            new Reservation{Id=4,BookId=3050,Title="Math",ReservationDate=DateTime.Parse("2020-2-12"),ReturnDate=DateTime.Parse("2020-2-13")},
//            new Reservation{Id=4,BookId=3050,Title="Math",ReservationDate=DateTime.Parse("2020-2-12"),ReturnDate=DateTime.Parse("2020-2-13")},
//            };
//            reservations.ForEach(s => context.Reservationss.Add(s));
//            context.SaveChanges();
//        }
//    }
//}