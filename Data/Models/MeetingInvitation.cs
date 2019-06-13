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
<<<<<<< HEAD
        [ForeignKey("UID")]
        public BGUser SenderUID { get; set; }
        [ForeignKey("UID")]
        public ICollection<BGUser> ReceiverUID { get; set; }
        [ForeignKey("MID")]
        public Meeting MID { get; set; }



=======
        ///fk
        
        public BGUser SenderUID { get; set; }
        public BGUser ReciverUID { get; set; }
        public Meeting MID { get; set; }
>>>>>>> 4810601d07d1d7c48bf05739c366aa23d6991e7a

    }
}
