using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain;
namespace webapi.Controllers
{

    [Route("login/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRepo db;
        public LoginController(IRepo db)
        {
            this.db = db;
        }

        //login 
        [HttpPost]
        public ActionResult LookUpUser([FromBody] string userID)
        {
            if (db.UsernameExist(userID))
            {
                return Accepted();
            }
            return Conflict();
        }
        //api doc's
        public ActionResult CreateAccount ([FromBody]BGUser t)
        {
            try
            {
                db.AddUser(t);
                Guid u = Guid.NewGuid();
                return Created(t.Username,u);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPost]
        //fix doc's
        public ActionResult UserLogin([FromBody]BGUser u)
        {
            if (db.UsernameExist(u.Username))
            {
                if (db.PasswordMatched(u.Username, u.Password))
                {
                    /// can't work on API need store locally TempData["UserID"] = userID;
                    /// 
                    Guid g = Guid.NewGuid();
                    return Accepted(g);
                }
                else
                {
                    return Unauthorized();
                }
            }
            return NotFound();
        }
    }
}
