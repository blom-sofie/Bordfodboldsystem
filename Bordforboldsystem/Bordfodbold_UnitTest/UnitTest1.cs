using System;
using Moq;
using Bordfodbold_System.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bordfodbold_System.Controllers;
using Bordfodbold_System.Entities;
using System.Web.Mvc;

namespace Bordfodbold_UnitTest {
  [TestClass]
  public class UnitTest1 {
    [TestMethod]
    public void CanDeletePlayer() {
      //Arrange
      Mock<IPlayerRepository> mock = GetRepositoryMock();

      HomeController cont = new HomeController(mock.Object);

      Player player = new Player { id = 42, name = "Testy McTesterson" };

      //Act
      cont.DeleteUser(player.id);

      //Assert
      mock.Verify(m => m.DeletePlayer(player.id));
    }


    [TestMethod]
    public void CanSaveValidChanges() {
      //Arrange
      Mock<IPlayerRepository> mock = new Mock<IPlayerRepository>();

      HomeController cont = new HomeController(mock.Object);

      Player player = new Player { name = "Test" };

      //Act
      ActionResult result = cont.EditUser(player);

      //Assert
      mock.Verify(m => m.SavePlayer(player));

      Assert.IsNotInstanceOfType(result, typeof(ViewResult));

    }

    private Mock<IPlayerRepository> GetRepositoryMock() {
      Mock<IPlayerRepository> mock = new Mock<IPlayerRepository>();
      mock.Setup(m => m.Players).Returns(new Player[] {
        new Player {id = 42, name = "Testy McTesterson"},
        new Player {id = 52, name = "Karsten"},
        new Player {id = 62, name = "Arne"},


      });
      return mock;
    }
  }
}
