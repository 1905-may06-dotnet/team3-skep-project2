using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class BoardGame
    {
        [Key]
        public int GID { get; set; }
        [ForeignKey("genre")]
        public Genre genre { get; set; }

        public string BGName { get; set; }
        public int MaxPlayerCount { get; set; }
        public int MinPlyaerCount { get; set; }




    }
}
