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
    public class LoginTest
    {
        [TestMethod]
        public void LookupTest()
        {
            //to use Mock you need to set up method as a virtual to override the method.
            var mock = new Mock<Data.Repo>();
            mock.Setup(x => x.UsernameExist("test")).Returns(true);
            LoginController loginController = new LoginController(mock.Object);
            var response = loginController.LookUpUser("test");
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(AcceptedResult));
        }
        [TestMethod]
        public void LookupTestFail()
        {
            //to use Mock you need to set up method as a virtual to override the method.
            var mock = new Mock<Data.Repo>();
            mock.Setup(x => x.UsernameExist("test")).Returns(true);
            LoginController loginController = new LoginController(mock.Object);
            var response = loginController.LookUpUser("fail");
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(ConflictResult));
        }

        [TestMethod]
        public void LoginNotFound()
        {
            //to use Mock you need to set up method as a virtual to override the method.
            var mock = new Mock<Data.Repo>();
            mock.Setup(x => x.PasswordMatched("test", "word")).Returns(true);
            LoginController loginController = new LoginController(mock.Object);
            var testValue = new BGUser("Bob","fail");
            var response = loginController.UserLogin(testValue);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(NotFoundResult));
        }
        [TestMethod]
        public void LoginUnauthorized()
        {
            //to use Mock you need to set up method as a virtual to override the method.
            var mock = new Mock<Data.Repo>();
            mock.Setup(x => x.UsernameExist("test")).Returns(true);
            mock.Setup(x => x.PasswordMatched("test", "word")).Returns(false);
            LoginController loginController = new LoginController(mock.Object);
            var testValue = new BGUser("test", "word");
            var response = loginController.UserLogin(testValue);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(UnauthorizedResult));
        }
        [TestMethod]
        public void LoginAccepted()
        {
            //to use Mock you need to set up method as a virtual to override the method.
            var mock = new Mock<Data.Repo>();
            mock.Setup(x => x.UsernameExist("test")).Returns(true);
            mock.Setup(x => x.PasswordMatched("test", "word")).Returns(true);
            LoginController loginController = new LoginController(mock.Object);
            var testValue = new BGUser("test", "word");
            var response = loginController.UserLogin(testValue);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(AcceptedResult));
        }
        [TestMethod]
        public void CreateAccountTestFail()
        {
            var mock = new Mock<Data.Repo>();
            Guid g = Guid.NewGuid();
            var testValue = new BGUser("test", "word","doesnotexsit",g);
            mock.Setup(x => x.AddUser(testValue)).Throws(new Exception());
            LoginController loginController = new LoginController(mock.Object);
            var response = loginController.CreateAccount(testValue);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(BadRequestResult));
        }
        [TestMethod]
        public void CreateAccountTest()
        {
            var mock = new Mock<Data.Repo>();
            Guid g = Guid.NewGuid();
            var testValue = new BGUser("test", "word", "doesnotexsit", g);
            mock.Setup(x => x.AddUser(testValue));
            LoginController loginController = new LoginController(mock.Object);
            var response = loginController.CreateAccount(testValue);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(CreatedResult));
        }



    }
}
