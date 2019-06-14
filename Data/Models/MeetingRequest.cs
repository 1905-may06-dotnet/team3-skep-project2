using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class MeetingRequest
    {
        [Key]
        public int MRID { get; set; }
        public DateTime MeetingTime { get; set; }
    }
}
