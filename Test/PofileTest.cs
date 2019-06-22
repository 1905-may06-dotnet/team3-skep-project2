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
               var user = new BGUser();
               user.New = "newMan";
               user.Token = g;
               user.Username = "test";
               var response = profileController.UpdateUserName(user);
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(AcceptedResult));
          }
          [TestMethod]
          public void UpdateUserNameTestFail(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               mock.Setup(x => x.UpdateUserName("newMan", "fail"));
               var user = new BGUser();
               user.New = "test";
               user.Token = g;
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdateUserName(user);
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(BadRequestResult));
          }
          [TestMethod]
          public void UpdateEmailTest(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               var user = new BGUser();
               user.New = "testing";
               user.Token = g;
               user.Username = "test";
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdateEmail(user);
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(AcceptedResult));
          }
          [TestMethod]
          public void UpdateEmailTestFail(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               var user = new BGUser();
               user.New = "testing";
               user.Token = g;
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdateEmail(user);
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(BadRequestResult));
          }
          [TestMethod]
          public void UpdatePhoneTest(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               var user = new BGUser();
               user.New = "testing";
               user.Token = g;
               user.Username = "test";
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdatePhone(user);
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(AcceptedResult));
          }
          [TestMethod]
          public void UpdatePhoneTestFail(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               var user = new BGUser();
               user.New = "testing";
               user.Token = g;
               user.Username = "testing";
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdatePhone(user);
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(BadRequestResult));
          }
          [TestMethod]
          public void UpdatePasswordTest(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               mock.Setup(x => x.UpdatePassword("test","test"));
               var user = new BGUser();
               user.New = "test";
               user.Token = g;
               user.Username = "test";
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdatePassword(user);
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(AcceptedResult));
          }
          [TestMethod]
          public void UpdatePasswordTestFail(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               mock.Setup(x => x.UpdatePassword("test", "test"));
               var user = new BGUser();
               user.New = "testing";
               user.Token = g;
               user.Username = "testing";
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdatePassword(user);
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(BadRequestResult));
          }
          [TestMethod]
          public void UpdateLocationTest(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               var user = new BGUser();
               user.New = "testing";
               user.Token = g;
               user.Username = "test";
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdatePassword(user);
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(AcceptedResult));
          }
          [TestMethod]
          public void UpdateLocationTestFail(){
               var mock = new Mock<Data.Repo>();
               Guid g = Guid.NewGuid();
               mock.Setup(x => x.UsernameExist("test")).Returns(true);
               var user = new BGUser();
               user.New = "testing";
               user.Token = g;
               user.Username = "testing";
               ProfileController profileController = new ProfileController(mock.Object);
               var response = profileController.UpdatePassword(user);
               Assert.IsNotNull(response);
               Assert.IsInstanceOfType(response, typeof(BadRequestResult));
          }
    }
}