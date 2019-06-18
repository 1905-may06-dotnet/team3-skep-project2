using System;
using System.Collections.Generic;

namespace webapi.Models
{
    public partial class UserCollection
    {
        public int Ucid { get; set; }
        public int Uid { get; set; }
        public int Gid { get; set; }

        public virtual BoardGame G { get; set; }
        public virtual BGUser U { get; set; }
    }
}
