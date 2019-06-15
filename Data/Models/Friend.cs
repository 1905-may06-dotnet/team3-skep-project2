using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Data.Models
{
    public class Friend
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FID { get; set; }
        //int BGUserUID;
        //int BGUserUID1;
        //public Friend()
        //{ }
        //public Friend(int uid1, int uid2)
        //{
        //    BGUserUID = uid1;
        //    BGUserUID1 = uid2;
        //}
    }
}
