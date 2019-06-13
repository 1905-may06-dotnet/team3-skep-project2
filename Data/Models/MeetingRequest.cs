using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
namespace Data.Models
{
    public class MeetingRequest
    {
        [Key]
        public int MRID { get; set; }
        [ForeignKey("UID")]
        public BGUser SenderUID { get; set; }
        [ForeignKey("UID")]
        public BGUser ReceiverUID { get; set; }
        [ForeignKey("MID")]
        public Meeting MID { get; set; }
        public DateTime MeetingTime { get; set; }
    }
}
