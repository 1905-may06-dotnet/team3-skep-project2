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
        [HttpPost("CreateMeeting")]
        public ActionResult AddMeeting([FromBody] Domain.Meeting meeting)
        {
            try
            {
                db.CreateMeeting(meeting);
                return Created(meeting.MeetingTime.ToString(),meeting.HostUid);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("SearchMeeting")]
        public ActionResult SearchMeeting([FromBody] Domain.Meeting meeting)
        {
            try
            {
                return Ok(db.GetMeetings(meeting));
            }
            catch
            {
                return NotFound();
            }
        }

    }
}
