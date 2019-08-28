using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcBook.Models
{
    public class Reservation
    {
        [Display(Name = "Reservation Date")]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        [NotMapped]
        public SelectList BookNames { get; set; }

        [NotMapped]
        public SelectList BookGenres { get; set; }

        [NotMapped]
        public String bookGenre { get; set; }

        public int Id { get; set; }

        [NotMapped]
        public object DateTime { get; internal set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }


    }
}
