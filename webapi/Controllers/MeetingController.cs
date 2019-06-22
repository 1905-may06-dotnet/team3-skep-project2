using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IRepo db;
        public MeetingController(IRepo db)
        {
            this.db = db;
        }

        // POST: api/Meeting
        [HttpPost]
        public ActionResult AddMeeting([FromBody] Domain.Meeting meeting)
        {
            try
            {
                db.CreateMeeting(meeting);
                return Created("uri", meeting.HostUid);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Meeting/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
