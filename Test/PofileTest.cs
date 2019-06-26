using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using webapi.Controllers;
using Domain;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Test
{
    [TestClass]
    public class ProfileTest
    {

        [TestMethod]
        public void UpdateEmailTest()
        {
            var mock = new Mock<Data.Repo>();
            Guid g = Guid.NewGuid();
            mock.Setup(x => x.UsernameExist("test")).Returns(true);
            var user = new BGUser();
            user.Username = "testing";
            user.Username = "test";
            ProfileController profileController = new ProfileController(mock.Object);
            var response = profileController.UpdateEmail(user);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(AcceptedResult));
        }
        [TestMethod]
        public void UpdateEmailTestFail()
        {
            var mock = new Mock<Data.Repo>();
            Guid g = Guid.NewGuid();
            mock.Setup(x => x.UsernameExist("test")).Returns(true);
            var user = new BGUser();
            user.Username = "testing";
            ProfileController profileController = new ProfileController(mock.Object);
            var response = profileController.UpdateEmail(user);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(BadRequestResult));
        }
        [TestMethod]
        public void UpdatePhoneTest()
        {
            var mock = new Mock<Data.Repo>();
            Guid g = Guid.NewGuid();
            mock.Setup(x => x.UsernameExist("test")).Returns(true);
            var user = new BGUser();
            user.Username = "testing";

            user.Username = "test";
            ProfileController profileController = new ProfileController(mock.Object);
            var response = profileController.UpdatePhone(user);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(AcceptedResult));
        }
        [TestMethod]
        public void UpdatePhoneTestFail()
        {
            var mock = new Mock<Data.Repo>();
            Guid g = Guid.NewGuid();
            mock.Setup(x => x.UsernameExist("test")).Returns(true);
            var user = new BGUser();
            user.Username = "testing";
            ProfileController profileController = new ProfileController(mock.Object);
            var response = profileController.UpdatePhone(user);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(BadRequestResult));
        }
        [TestMethod]
        public void UpdateLocationTest()
        {
            var mock = new Mock<Data.Repo>();
            Guid g = Guid.NewGuid();
            mock.Setup(x => x.UsernameExist("test")).Returns(true);
            var user = new BGUser();
            user.Username = "test";
            ProfileController profileController = new ProfileController(mock.Object);
            var response = profileController.UpdateLocation(user);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(AcceptedResult));
        }
        [TestMethod]
        public void UpdateLocationTestFail()
        {
            var mock = new Mock<Data.Repo>();
            Guid g = Guid.NewGuid();
            mock.Setup(x => x.UsernameExist("test")).Returns(true);
            var user = new BGUser();
            user.Username = "testing";
            ProfileController profileController = new ProfileController(mock.Object);
            var response = profileController.UpdateLocation(user);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(BadRequestResult));
        }
    
        [TestMethod]
        public void UpdateENfail()
        {
            var mock = new Mock<Data.Repo>();
            Guid g = Guid.NewGuid();
            mock.Setup(x => x.UsernameExist("test")).Returns(true);
            var user = new BGUser();
            user.Username = "testing";
            ProfileController profileController = new ProfileController(mock.Object);
            var response = profileController.UpdateAllowEN(user);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(BadRequestResult));
        }
     


        [TestMethod]
        public void UpdatePNfail()
        {
            var mock = new Mock<Data.Repo>();
            Guid g = Guid.NewGuid();
            mock.Setup(x => x.UsernameExist("test")).Returns(true);
            var user = new BGUser();
            user.Username = "testing";
            ProfileController profileController = new ProfileController(mock.Object);
            var response = profileController.UpdateAllowPN(user);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(BadRequestResult));
        }
    }
}