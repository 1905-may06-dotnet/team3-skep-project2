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
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IRepo db;
        public ProfileController(IRepo db)
        {
            this.db = db;
        }

        [HttpPut("UpdateEmail")]
        public ActionResult UpdateEmail([FromBody] BGUser user)
        {
            if (db.UsernameExist(user.Username))
            {
                db.UpdateEmail(user);
                return Accepted();
            }
                return BadRequest();
        }
        [HttpPut("UpdatePhone")]
        public ActionResult UpdatePhone([FromBody] BGUser user)
        {
            if (db.UsernameExist(user.Username)) { 
                db.UpdatePhoneNumber(user);
                return Accepted();              
            }
            return BadRequest();
        }

        [HttpPut("UpdateLocation")]
        public ActionResult UpdateLocation([FromBody] BGUser user)
        {
            if (db.UsernameExist(user.Username))
            {
                db.UpdateLoction(user);
                return Accepted();
            }
            return BadRequest();
        }
        [HttpPut("UpdateAllowEN")]
        public ActionResult UpdateAllowEN([FromBody] BGUser user)
        {
            //get user from guid
            if (db.UsernameExist(user.Username))
            {
                db.UpdateAllowEN(user);
                return Accepted();
            }
            return BadRequest();
        }
        [HttpPut("UpdateAllowPN")]
        public ActionResult UpdateAllowPN([FromBody] BGUser user)
        {
            if (db.UsernameExist(user.Username))
            {
                db.UpdateAllowPN(user);
                return Accepted();
            }
            return BadRequest();
        }
        [HttpPost("AddGames")]
        public ActionResult AddGames([FromBody] UserCollection item)
        {
            //get user from guid
            try
            { 
                db.AddGames(item);
                return Accepted();
            }
            catch
            { return BadRequest();}           
        }
        [HttpGet("GetBGCollection")]
        public ActionResult GetBGCollection([FromBody] BGUser user)
        {
            //get user from guid
            try
            {
                user.BGCollectionList = db.GetUserBGCollectionList(user.UID);
                return Ok(user);
            }
            catch
            { return BadRequest(); }
        }
    }
}
