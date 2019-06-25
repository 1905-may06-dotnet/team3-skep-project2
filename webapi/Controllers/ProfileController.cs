using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace webapi.Controllers
{
    [Route("Profile/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IRepo db;
        public ProfileController(IRepo db)
        {
            this.db = db;
        }

        [HttpPut("UpdateUserName")]
        public ActionResult UpdateUserName([FromBody] BGUser user)
        {
            if (db.UsernameExist(user.Username))
            {
                db.UpdateUserName(user.New, user.Username);
                //need to update Guild
                
                return Accepted(user.Token);
            }
                return BadRequest();            
        }
        [HttpPut("UpdateEmail")]
        public ActionResult UpdateEmail([FromBody] BGUser user)
        {
            //get user from guid
            if (db.UsernameExist(user.Username))
            {
                db.UpdateEmail(user.New, user.Username);
                return Accepted(user.Token);
            }
                return BadRequest();
        }
        [HttpPut("UpdatePhone")]
        public ActionResult UpdatePhone([FromBody] BGUser user)
        {
            //get user from guid
            if (db.UsernameExist(user.Username)) { 
                db.UpdatePhoneNumber(user.New, user.Username);
                return Accepted(user.Token);
       
                
            }
            return BadRequest();

        }
        [HttpPut("UpdatePassword")]
        public ActionResult UpdatePassword([FromBody] BGUser user)
        {
            //get user from guid

            if (db.UsernameExist(user.Username))
            {
                db.UpdatePassword(user.New, user.Username);
                return Accepted(user.Token);
            }
                return BadRequest();
        }
        [HttpPut("UpdateLocation")]
        public ActionResult UpdateLocation([FromBody] BGUser user)
        {
            //get user from guid

            if (db.UsernameExist(user.Username))
            {
                var BGLocation = db.GetLocationById(user.UID);
                db.UpdateLoction(BGLocation, user.Username);
                return Accepted(user.Token);
            }
            return BadRequest();
        }
    }
}
