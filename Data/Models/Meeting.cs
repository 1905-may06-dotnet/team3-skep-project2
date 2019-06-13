using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class Meeting
    {
        [Key]
        public int MID { get; set; }
        [ForeignKey("LID")]
        public Location LID { get; set; }
        [ForeignKey("GID")]
        public BoardGame GID { get; set; }
        public DateTime MeetingTime { get; set; }
        [ForeignKey("UID")]
        public BGUser HostUID { get; set; }
        

    }
}
