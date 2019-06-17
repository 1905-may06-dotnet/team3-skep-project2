using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using webapi.Controllers;
using Domain;
using Data;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Mvc;

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



    }
}
