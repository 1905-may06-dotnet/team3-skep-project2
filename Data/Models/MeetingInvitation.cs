using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class MeetingInvitation
    {
        [Key]
        public int MIID { get; set; }
        ///fk
        
        public BGUser SenderUID { get; set; }
        public BGUser ReciverUID { get; set; }
        public Meeting MID { get; set; }

    }
}
