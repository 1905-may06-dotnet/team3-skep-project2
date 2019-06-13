using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class UserCollection
    {
        [Key]
        public int UCID { get; set; }
    }
}
