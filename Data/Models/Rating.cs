using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Rating
    {
        [Key]
        public int RID { get; set; }
        public int UserRating { get; set; }
    }
}
