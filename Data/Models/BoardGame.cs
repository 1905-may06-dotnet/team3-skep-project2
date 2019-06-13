using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    class BoardGame
    {
        [Key]
        public int GID { get; set; }
        public Genre genre { get; set; }
        public string BGName { get; set; }
        public int MaxPlayerCount { get; set; }
        public int MinPlyaerCount { get; set; }



    }
}
