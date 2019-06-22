using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Friend
    {
        public int Fid { get; set; }
        public int Uid1 { get; set; }
        public int Uid2 { get; set; }

        public virtual BGUser Uid1Navigation { get; set; }
        public virtual BGUser Uid2Navigation { get; set; }
    }
}
