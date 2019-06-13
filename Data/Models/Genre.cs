using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    class Genre
    {
        [Key]
        public string genre { get; set; }
    }
}
