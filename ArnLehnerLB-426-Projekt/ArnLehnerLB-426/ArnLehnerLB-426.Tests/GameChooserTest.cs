using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ArnLehnerLB_426.Tests
{
    [TestClass]
    public class GameChooserTests
    {
        private Mock<IConsoleWrapper> _mockConsoleWrapper = null!;
        private IConsoleArea _textArea = null!;
        private IState _gameChooser = null!;
        private Menu _menu = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockConsoleWrapper = new Mock<IConsoleWrapper>();
            _textArea = new TextArea(0, 3, _mockConsoleWrapper.Object);
            _gameChooser = new GameChooser();
            _menu = new Menu();
        }

        [TestMethod]
        public void TestOpenGameChooserMenu_PrintUpdatedQuestionAndGames()
        {
            // Arrange

            // Act

            // Assert
            VerifyConsoleOutput(
                "What game do you want to play?", 
                ">Slotmachine", 
                " Dice game");
        }

        [TestMethod]
        public void TestOpenGameChooserMenu_PressArrowDown_PrintUpdatedQuestionAndGames()
        {
            // Arrange

            // Act
            _gameChooser.PressArrowDown(_menu);

            // Assert
            VerifyConsoleOutput(
                "What game do you want to play?", 
                " Slotmachine", 
                ">Dice game");
        }

        [TestMethod]
        public void TestOpenGameChooserMenu_PressArrowUp_PrintUpdatedQuestionAndGames()
        {
            // Arrange

            // Act
            _gameChooser.PressArrowUp(_menu);

            // Assert
            VerifyConsoleOutput(
                "What game do you want to play?", 
                " Slotmachine", 
                ">Dice game");
        }

        [TestMethod]
        public void TestOpenGameChooserMenu_SetsStateToSlotmachine()
        {
            // Arrange

            // Act
            _gameChooser.PressEnter(_menu);

            // Assert
            Assert.IsInstanceOfType(_menu.State, typeof(Slotmachine));
        }

        [TestMethod]
        public void TestOpenGameChooserMenu_PressArrowDown_SetsStateToSlotmachine()
        {
            // Arrange

            // Act
            _gameChooser.PressArrowDown(_menu);
            _gameChooser.PressEnter(_menu);

            // Assert
            Assert.IsInstanceOfType(_menu.State, typeof(DiceGame));
        }

        private void VerifyConsoleOutput(params string[] expectedLines)
        {
            foreach (string expectedLine in expectedLines)
            {
                _mockConsoleWrapper.Verify(c => c.WriteLine(expectedLine));
            }
        }
    }
}
