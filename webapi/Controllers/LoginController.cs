using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

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
                string pw = t.Password;
                Guid g = Guid.NewGuid();
                string salt = g.ToString();
                Console.WriteLine(g);
                byte[] saltToBytes = Encoding.ASCII.GetBytes(salt);
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: pw,
                    salt: saltToBytes,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8));
                t.Salt = g;
                t.Password = hashed;
                db.AddUser(t);
                //Guid u = Guid.NewGuid();
                //t.Salt = u;
                //db.AddUser(t);
                return Created(t.Username, g);
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
