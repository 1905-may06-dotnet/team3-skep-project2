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
        //[TestMethod]
        //public void CreateAccount()
        //{
        //    IRepo db =new Repo();
        //    LoginController loginController = new LoginController(db);
        //    var response = loginController.CreateAccount();
        //    Assert.IsNotNull(response);    
        //    Assert.IsInstanceOfType(response, typeof(AcceptedResult));
        //}
    }
}
