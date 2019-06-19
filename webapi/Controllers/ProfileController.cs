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

        [HttpPut]
        public ActionResult UpdateUserName([FromBody] string userID,Guid g, [FromBody] string confirmUser)
        {
            if (db.UsernameExist(confirmUser))
            {
                db.UpdateUserName(userID, confirmUser);
                //need to update Guild
                
                return Accepted(g);
            }
                return BadRequest();            
        }
        [HttpPut]
        public ActionResult UpdateEmail([FromBody] string Email, Guid g, [FromBody] string confirmUser)
        {
            //get user from guid
            if (db.UsernameExist(confirmUser))
            {
                db.UpdateEmail(Email, confirmUser);
                return Accepted(g);
            }
                return BadRequest();
            

        }
        public ActionResult UpdatePhone([FromBody] string Phone, Guid g, [FromBody] string confirmUser)
        {
            //get user from guid
            if (db.UsernameExist(confirmUser)) { 
                db.UpdatePhoneNumber(Phone, confirmUser);
                return Accepted(g);
       
                
            }
            return BadRequest();

        }
        public ActionResult UpdatePassword([FromBody] string Password, Guid g,[FromBody] string confirmUser)
        {
            //get user from guid

            if (db.UsernameExist(confirmUser))
            {
                db.UpdatePassword(Password, confirmUser);
                return Accepted(g);
            }
                return BadRequest();
        }

        public ActionResult UpdateLocation([FromBody] string location, Guid g, [FromBody] string confirmUser)
        {
            //get user from guid

            if (db.UsernameExist(confirmUser))
            {
                var BGLocation = db.GetLocationByName(location);
                db.UpdateLoction(BGLocation, confirmUser);
                return Accepted(g);
            }
            return BadRequest();
        }
    }
}
