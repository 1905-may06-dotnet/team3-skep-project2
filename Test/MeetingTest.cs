using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using webapi.Controllers;
using Domain;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;


namespace Test
{
    [TestClass]
    public class MeetingTest
    {
        [TestMethod]
        public void AddMeetingTest()
        {
            var mock = new Mock<Data.Repo>();
            Guid g = Guid.NewGuid();
            Domain.Meeting meeting = new Meeting(1,1,DateTime.Now,1);
            mock.Setup(x => x.CreateMeeting(meeting)).Returns(true);
            MeetingController meetingController = new MeetingController(mock.Object);
            var response = meetingController.AddMeeting(meeting);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(CreatedResult));


        }
        [TestMethod]
        public void AddMeetingTestFailed()
        {
            var mock = new Mock<Data.Repo>();
            Guid g = Guid.NewGuid();
            Domain.Meeting meeting = new Meeting();
            mock.Setup(x => x.CreateMeeting(meeting)).Returns(false);
            MeetingController meetingController = new MeetingController(mock.Object);
            var response = meetingController.AddMeeting(meeting);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(BadRequestResult));
        }
        [TestMethod]
        public void AddMeetingRequestTestFail()
        {
            var mock = new Mock<Data.Repo>();
            Guid g = Guid.NewGuid();
            Domain.MeetingRequest meeting = new MeetingRequest();
            mock.Setup(x => x.CreateMeetingRequest(meeting));
            MeetingController meetingController = new MeetingController(mock.Object);
            var response = meetingController.AddMeetingRequest(meeting);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(BadRequestResult));
        }

    }
}