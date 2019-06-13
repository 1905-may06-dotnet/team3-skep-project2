using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    class MeetingRequest
    {
        [Key]
        public int MRID { get; set; }
        public DateTime MeetingTime { get; set; }
        [ForeignKey("UID")]
        public BGUser InitiatorUID { get; set; }
        [ForeignKey("UID")]
        public ICollection<BGUser> ReceiverUID { get; set; }
        [ForeignKey("GID")]
        public BoardGame GID { get; set; }
        [ForeignKey("LID")]
        public Location LID { get; set; }



    }
}
