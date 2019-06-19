using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class UserMeeting
    {
        public int Umid { get; set; }
        public int Uid { get; set; }
        public int Mid { get; set; }

        public virtual Meeting M { get; set; }
        public virtual BGUser U { get; set; }
    }
}
