using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Authenticators;

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
        [HttpPost("CreateMeetingRequest")]
        public ActionResult AddMeetingRequest([FromBody] Domain.MeetingRequest meetingRequest)
        {
            try
            {
                db.CreateMeetingRequest(meetingRequest);
                string sender = db.GetUserByUid(meetingRequest.InitiatorUid).Username;
                string receiver = db.GetUserByUid(meetingRequest.ReceiverUid).Username;
                string location= db.GetLocationById(meetingRequest.Lid).LocationName;
                string boardgame = db.GetBoardGameByUid(meetingRequest.Gid).BGName;
                string time = meetingRequest.MeetingTime.ToString();
                SendMessage(receiver, sender, location, boardgame,time);
                return Created(meetingRequest.MeetingTime.ToString(), meetingRequest.InitiatorUid);
            }
               catch
                {
                 return BadRequest();
                }
            }

        public IRestResponse SendMessage(string r, string s, string l, string bg, string time)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                                            "49d580152859b132a138a91a1418aa43-2b778fc3-24fa546d");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandboxd3b07b7021e44d4d86a10aec3eaa29c4.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Excited User <mailgun@sandboxd3b07b7021e44d4d86a10aec3eaa29c4.mailgun.org>");
            request.AddParameter("to", "team.skep4@gmail.com");
            request.AddParameter("to", "YOU@YOUR_DOMAIN_NAME");
            request.AddParameter("subject", "Hello");
            request.AddParameter("text", $"Hi, {r} receive a meeting request from {s}! Request Details: Location: {l}, BoardGame: {bg}, Time: {time}");
            request.Method = Method.POST;
            return client.Execute(request);
        }


        [HttpPost("SearchMeeting")]
        public ActionResult SearchMeeting([FromBody] Domain.Meeting meeting)
        {
            try
            {
                if (db.GetMeetings(meeting).Count() > 0)
                { return Ok(db.GetMeetings(meeting)); }
                else { return NotFound(); }
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
