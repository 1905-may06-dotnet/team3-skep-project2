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
    }
}
