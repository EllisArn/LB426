using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ArnLehnerLB_426.Tests
{
    [TestClass]
    public class SecurityTest
    {
        private ISubject _player = null!;
        private Mock<IConsoleWrapper> _mockConsoleWrapper = null!;
        private IConsoleArea _textArea = null!;
        private IObserver _security = null!;

        [TestInitialize]
        public void Setup()
        {
            _player = new Player(100);
            _mockConsoleWrapper = new Mock<IConsoleWrapper>();
            _textArea = new TextArea(0, 3, _mockConsoleWrapper.Object);
            _security = new Security(_mockConsoleWrapper.Object);

            _player.Attach(_security);
        }
        [TestMethod]
        public void TestPlayerHasNoTokens()
        {
            // Arrange

            // Act
            _player.RemoveJetons(100);

            // Assert
            _mockConsoleWrapper.Verify(c => c.WriteLine("Hello casino player, you don't have any more jetons."));
            _mockConsoleWrapper.Verify(c => c.WriteLine("We will have to ask you to leave. This way."));
            _mockConsoleWrapper.Verify(c => c.WriteLine("[Press any key to leave]"));
        }

        [TestMethod]
        public void TestPlayerHasTokens()
        {
            // Arrange

            // Act
            _player.RemoveJetons(10);

            // Assert
            _mockConsoleWrapper.Verify(c => c.WriteLine("Hello casino player, you don't have any more jetons."), Times.Never);
            _mockConsoleWrapper.Verify(c => c.WriteLine("We will have to ask you to leave. This way."), Times.Never);
            _mockConsoleWrapper.Verify(c => c.WriteLine("[Press any key to leave]"), Times.Never);
        }
    }
}
