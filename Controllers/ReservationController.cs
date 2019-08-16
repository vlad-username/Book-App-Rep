using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcBook.Models;
using Newtonsoft.Json.Serialization;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace MvcBook.Controllers
{
    public class ReservationController : Controller
    {
        private readonly MvcBookContext _context;

        public ReservationController(MvcBookContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var rawDbData = _context.Reservation.Include(b => b.Book);

            var reservationsList = await rawDbData.ToListAsync();

            //iterate the list and take the book from db based on reservation book id

            return View(reservationsList);
        }
        
        public async Task<IActionResult> New(string bookGenre)
        {

            var books = from m in _context.Book
                        select m;
            Reservation myModel = new Reservation();

            var bookQueryGenre = from m in _context.Book
                                 select m.Genre;
            SelectList myGenres = new SelectList(await bookQueryGenre.Distinct().ToListAsync());


            //var items = await books.Select(x => x).Where(x => x.Genre == bookGenre).ToListAsync();
            //var filterdItems = items.Where(s => s.Genre == bookGenre);

            //SelectList myTitle = new SelectList(items, "Id", "Title");
            SelectList myTitle = new SelectList(await books.ToListAsync(), "Id", "Title");
            

            //books = books.Where(m => m.Genre == bookQueryGenre);
            //.Where(m => m.Genre == myModel.BookGenres.ToString())
            DateTime now = DateTime.Now;
            myModel.ReservationDate = now;
            myModel.ReturnDate = now.AddDays(1);
            myModel.BookGenres = myGenres;
            myModel.BookNames = myTitle;

            return View(myModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(int id, string bookGenre, [Bind("Title,BookId,ReservationDate,ReturnDate")] Reservation reservation)
        {
            var resDate = from m in _context.Reservation
                          select m;
            //{
            //    var books = from m in _context.Book
            //                select m;
            //    var bookQueryGenre = from m in _context.Book
            //                         select m.Genre;
                                     
            //    SelectList myGenres = new SelectList(await bookQueryGenre.Distinct().ToListAsync());


            //    //var items = await books.Select(x => x).Where(x => x.Genre == bookGenre).ToListAsync();
            //    //var filterdItems = items.Where(s => s.Genre == bookGenre);
            //    //SelectList myTitle = new SelectList(items, "Id", "Title");
            //    if (bookGenre != "All")
            //    {
            //        SelectList myTitle = new SelectList(await books.Where(s => s.Genre == bookGenre).ToListAsync(), "Id", "Title");
            //        reservation.BookNames = myTitle;
            //    }
            //    else
            //    {
            //        SelectList myTitle = new SelectList(await books.ToListAsync(), "Id", "Title");
            //        reservation.BookNames = myTitle;
            //    }

            //    reservation.BookGenres = myGenres;
                
            //}
            
            if (id != reservation.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {  
                try
                {
                    if (resDate.Any(m => m.BookId == reservation.BookId))
                    {
                        if (!resDate.Any(m => m.ReservationDate == reservation.ReservationDate) && !resDate.Any(m => m.BookId == reservation.BookId))
                        {
                            if (reservation.ReservationDate <= reservation.ReturnDate)
                            {
                                _context.Add(reservation);
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));
                            }
                            else
                                ViewBag.ErrorMessage = "Return Date is not valid, please check !";
                        }
                        else {
                            ViewBag.ErrorMessage = "Reservation Date for this book is not valid !";

                        }
                    }
                    else if (reservation.ReservationDate <= reservation.ReturnDate)
                    {
                        _context.Add(reservation);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else {
                        ViewBag.ErrorMessage = "Return Date is not valid, please check !";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
            }
            return View(reservation);

        }

        public ActionResult getGenre()
        {
            return Json(_context.Book.Select(x => new
            {
                Genre = x.Genre,
                Id = x.Id,
                Title = x.Title
            }).ToList().Distinct(), new Newtonsoft.Json.JsonSerializerSettings { ContractResolver = new DefaultContractResolver()});
        }



        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.Id == id);
        }
        private bool ReservationExistsBook(int id)
        {
            return _context.Reservation.Any(e => e.BookId == id);
        }

        
    }
}
