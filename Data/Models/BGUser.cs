using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class BGUser
    {
        [Key]
        public int UID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool AllowPN { get; set; }
        public bool AllowEN { get; set; }
        public Location loction { get; set; }

    }
}
