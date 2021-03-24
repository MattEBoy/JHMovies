using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JHMovies.Models
{
    public class Movie
    {
        // o For the Edited field, we want that to be a yes/no(true/false) option.
        // o The “Edited”, “Lent To”, and “Notes” fields are optional.All other fields must be
        //entered.
        //o Notes should be limited to 25 characters.
        [Key]
        public int MovieID { get; set; }

        [Required]
        public String Rating { get; set; }
        [Required]
        public String Category { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public String Director { get; set; }

        public String LentTo { get; set; }
        [MaxLength(25)]
        public String Notes { get; set; }
        public bool Edited { get; set; }
    }
}
