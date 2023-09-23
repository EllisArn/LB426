using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ArnLehnerLB_426.Tests
{
    [TestClass]
    public class PlayerTest
    {
        private Mock<IObserver> _mockObserver = null!;
        private ISubject _player = null!;

        [TestInitialize]
        public void Setup()
        { 
            _mockObserver = new Mock<IObserver>();
            _player = new Player(100);

            _player.Attach(_mockObserver.Object);
        }

        [TestMethod]
        public void TestAddJetons()
        {
            // Arrange

            // Act
            _player.AddJetons(10);

            // Assert
            Assert.AreEqual(110, _player.Jetons);
        }

        [TestMethod]
        public void TestRemoveJetons()
        {
            // Arrange

            // Act
            _player.RemoveJetons(10);

            // Assert
            Assert.AreEqual(90, _player.Jetons);
        }

        [TestMethod]
        public void TestNotify()
        {
            // Arrange

            // Act
            _player.AddJetons(10);

            // Assert
            _mockObserver.Verify(o => o.Update());
        }
    }
}
