using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class UserMeeting
    {
        [Key]
        public int UMID { get; set; }
    }
}
