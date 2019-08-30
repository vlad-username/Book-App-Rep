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
        public async Task<IActionResult> New(int id, string bookGenre,int BookId,  [Bind("Title,BookId,ReservationDate,ReturnDate")] Reservation reservation)
        {

            var resDate = from m in _context.Reservation
                          select m;
            var books = from m in _context.Book
                        select m;
            var bookQueryGenre = from m in _context.Book
                                 select m.Genre;
            {
                SelectList myGenres = new SelectList(await bookQueryGenre.Distinct().ToListAsync());

                reservation.BookGenres = myGenres;
                //var items = await books.Select(x => x).Where(x => x.Genre == bookGenre).ToListAsync();
                //var filterdItems = items.Where(s => s.Genre == bookGenre);
                //SelectList myTitle = new SelectList(items, "Id", "Title");
                if (bookGenre != "-2")
                {
                    SelectList myTitle = new SelectList(await books.Where(s => s.Genre == bookGenre).ToListAsync(), "Id", "Title");
                    reservation.BookNames = myTitle;
                }
                else
                {
                    SelectList myTitle = new SelectList(await books.ToListAsync(), "Id", "Title");
                    reservation.BookNames = myTitle;
                }
            }

            if (id != reservation.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {  

                try
                {
                    if (resDate.Any(m => m.BookId == reservation.BookId) && BookId != -1 && bookGenre != "-2")
                    {
                        if (!(reservation.ReservationDate > reservation.ReturnDate))
                        {

                            //   List<Element> _context.Reservation = BuildList();
                            bool i = true;
                            var bookQueryres = from m in _context.Reservation
                                               where m.BookId == BookId
                                               select m;
                            foreach (var item in bookQueryres)
                            {

                                if (((reservation.ReservationDate >= item.ReturnDate) && (reservation.ReturnDate > reservation.ReservationDate))
                                    || ((reservation.ReturnDate <= item.ReservationDate) && (reservation.ReturnDate > reservation.ReservationDate)))
                                {

                                }
                                else {
                                    i = false;
                                    break;
                                }
                            }
                            if (i == true)
                            {
                                _context.Add(reservation);
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));
                            }
                            else {
                                ViewBag.ErrorMessage = "Reservation is not valid, please check !";
                            }
                        }
                        else {
                            ViewBag.ErrorMessage = "Reservation is not valid, please check !";
                        }
                    }
                    else if (!(reservation.ReservationDate < reservation.ReturnDate)) {
                        ViewBag.ErrorMessage = "ReturnDate is not valid, please check !";
                    }
                    else if (BookId == -1 && bookGenre != "-2")
                        ViewBag.ErrorMessage = "Please don't forget to choose a book !";
                    else if (bookGenre == "-2")
                        ViewBag.ErrorMessage = "Please don't forget to choose a genre !";
                    else
                    {
                        _context.Add(reservation);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
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
            }).ToList(), new Newtonsoft.Json.JsonSerializerSettings { ContractResolver = new DefaultContractResolver()});
        }
        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Reservation.Include(b => b.Book).FirstOrDefaultAsync(m => m.Id == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var books = await _context.Reservation.FindAsync(id);
            _context.Reservation.Remove(books);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
