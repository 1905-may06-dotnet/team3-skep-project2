using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Genres
    {
        [Key]
        public string Genre { get; set; }
    }
}
