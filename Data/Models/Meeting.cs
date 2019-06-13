using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Meeting
    {
        [Key]
        public int MID { get; set; }
        public Location LID { get; set; }
        public BoardGame GID { get; set; }
        public DateTime MeetingTime { get; set; }
    }
}
