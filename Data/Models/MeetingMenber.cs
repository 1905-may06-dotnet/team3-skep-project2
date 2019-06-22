using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class MeetingMenber
    {
        public int Umid { get; set; }
        public int Uid { get; set; }
        public int Mid { get; set; }

        public virtual Meeting M { get; set; }
        public virtual BGUser U { get; set; }
    }
}
