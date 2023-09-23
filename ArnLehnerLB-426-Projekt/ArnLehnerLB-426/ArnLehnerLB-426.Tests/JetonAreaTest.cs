using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ArnLehnerLB_426.Tests
{
    [TestClass]
    public class JetonAreaTest
    {
        private ISubject _player = null!;
        private Mock<IConsoleWrapper> _mockConsoleWrapper = null!;
        private IObserver _jetonArea = null!;

        [TestInitialize]
        public void Setup()
        {
            _player = new Player(100);
            _mockConsoleWrapper = new Mock<IConsoleWrapper>();
            _jetonArea = new JetonArea(0, 0, _mockConsoleWrapper.Object);

            _player.Attach(_jetonArea);
        }
        [TestMethod]
        public void TestUpdateWIthJetonChange()
        {
            // Arrange

            // Act
            _player.AddJetons(10);

            // Assert
            _mockConsoleWrapper.Verify(c => c.WriteLine("Jetons: 110"));
        }
    }
}
