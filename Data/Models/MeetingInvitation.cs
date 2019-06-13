using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class MeetingInvitation
    {
        [Key]
        public int MIID { get; set; }
        [ForeignKey("UID")]
        public BGUser SenderUID { get; set; }
        [ForeignKey("UID")]
        public BGUser ReciverUID { get; set; }
        [ForeignKey("MID")]
        public Meeting MID { get; set; }

    }
}
