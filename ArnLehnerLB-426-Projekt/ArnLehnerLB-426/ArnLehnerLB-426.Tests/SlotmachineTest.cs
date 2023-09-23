using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ArnLehnerLB_426.Tests
{
    [TestClass]
    public class SlotmachineTest
    {
        private ISubject _player = null!;
        private Mock<IConsoleWrapper> _mockConsoleWrapper = null!;
        private IConsoleArea _textArea = null!;
        private Slotmachine _slotmachine = null!;
        private Menu _menu = null!;

        [TestInitialize]
        public void Setup()
        {
            _player = new Player(100);
            _mockConsoleWrapper = new Mock<IConsoleWrapper>();
            _textArea = new TextArea(0, 3, _mockConsoleWrapper.Object);
            _slotmachine = new Slotmachine(_mockConsoleWrapper.Object);
            _menu = new Menu();
        }

        [TestMethod]
        public void TestNoIconsMatch()
        {
            // Arrange
            List<char> icons = new List<char> { '$', '¥', 'Ø' };

            // Act
            int result = _slotmachine.EvaluateResults(icons);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestFifthIconsMatch()
        {
            // Arrange
            List<char> icons = new List<char> { 'Ø', 'Ø', 'Ø' };

            // Act
            int result = _slotmachine.EvaluateResults(icons);

            // Assert
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void TestFourthIconsMatch()
        {
            // Arrange
            List<char> icons = new List<char> { '§', '§', '§' };

            // Act
            int result = _slotmachine.EvaluateResults(icons);

            // Assert
            Assert.AreEqual(35, result);
        }

        [TestMethod]
        public void TestThirdIconsMatch()
        {
            // Arrange
            List<char> icons = new List<char> { '¥', '¥', '¥' };

            // Act
            int result = _slotmachine.EvaluateResults(icons);

            // Assert
            Assert.AreEqual(50, result);
        }

        [TestMethod]
        public void TestSecondIconsMatch()
        {
            // Arrange
            List<char> icons = new List<char> { '£', '£', '£' };

            // Act
            int result = _slotmachine.EvaluateResults(icons);

            // Assert
            Assert.AreEqual(75, result);
        }

        [TestMethod]
        public void TestJackpot()
        {
            // Arrange
            List<char> icons = new List<char> { '$', '$', '$' };

            // Act
            int result = _slotmachine.EvaluateResults(icons);

            // Assert
            Assert.AreEqual(150, result);
        }

        [TestMethod]
        public void TestEnterPressed_StartGame()
        {
            // Arrange
            Menu menu = new Menu();

            // Act
            _slotmachine.PressEnter(menu);

            // Assert
            Assert.IsInstanceOfType(menu.State, typeof(EndOfRound));
        }
    }
}
