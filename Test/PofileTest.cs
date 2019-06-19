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
     public class ProfileTest{
          [TestMethod]
          public void UpdateUserNameTest(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               mock.Setup(x => x.UpdateUserName("newMan","test"));//forgot to add setup to UpdateUserName
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdateUserName("newMan", g,  "test");
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(AcceptedResult));
          }
          [TestMethod]
          public void UpdateUserNameTestFail(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               mock.Setup(x => x.UpdateUserName("newMan", "fail"));
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdateUserName("test", g,  "fail");
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(BadRequestResult));
          }
          [TestMethod]
          public void UpdateEmailTest(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdateEmail("testing", g,  "test");
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(AcceptedResult));
          }
          [TestMethod]
          public void UpdateEmailTestFail(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdateEmail("testing", g,  "testing");
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(BadRequestResult));
          }
          [TestMethod]
          public void UpdatePhoneTest(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdatePhone("testing", g,  "test");
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(AcceptedResult));
          }
          [TestMethod]
          public void UpdatePhoneTestFail(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdatePhone("testing", g,  "testing");
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(BadRequestResult));
          }
          [TestMethod]
          public void UpdatePasswordTest(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               mock.Setup(x => x.UpdatePassword("test","test"));
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdatePassword("test", g,  "test");
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(AcceptedResult));
          }
          [TestMethod]
          public void UpdatePasswordTestFail(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               mock.Setup(x => x.UpdatePassword("test", "test"));
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdatePassword("testing", g,  "testing");
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(BadRequestResult));
          }
          [TestMethod]
          public void UpdateLocationTest(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdatePassword("testing", g,  "test");
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(AcceptedResult));
          }
          [TestMethod]
          public void UpdateLocationTestFail(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdatePassword("testing", g,  "testing");
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(BadRequestResult));
          }
    }
}