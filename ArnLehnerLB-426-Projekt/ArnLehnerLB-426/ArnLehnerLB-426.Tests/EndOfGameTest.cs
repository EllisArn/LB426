using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ArnLehnerLB_426.Tests
{
    [TestClass]
    public class EndOfGameTest
    {
        private Mock<IConsoleWrapper> _mockConsoleWrapper = null!;
        private IConsoleArea _textArea = null!;
        private IState _endOfGame = null!;
        private Menu _menu = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockConsoleWrapper = new Mock<IConsoleWrapper>();
            _textArea = new TextArea(0, 3, _mockConsoleWrapper.Object);
            _endOfGame = new EndOfGame(_mockConsoleWrapper.Object);
            _menu = new Menu();
        }

        [TestMethod]
        public void TestOpenEndOfGameMenu_PrintQuestionAndPossibilities()
        {
            // Arrange

            // Act

            // Assert
            VerifyConsoleOutput(
                "The game has ended, do you want to play a different game or close the casino?",
                ">Different game",
                " Close the casino");
        }

        [TestMethod]
        public void TestOpenEndOfGameMenu_PressArrowDown_PrintQuestionAndPossibilities()
        {
            // Arrange

            // Act
            _endOfGame.PressArrowDown(_menu);

            // Assert
            VerifyConsoleOutput(
                "The game has ended, do you want to play a different game or close the casino?",
                " Different game",
                ">Close the casino");
        }

        [TestMethod]
        public void TestOpenEndOfGameMenu_PressArrowDown2_PrintQuestionAndPossibilities()
        {
            // Arrange

            // Act
            for (int i = 0; i < 2; i++)
            {
                _endOfGame.PressArrowDown(_menu);
            }

            // Assert
            VerifyConsoleOutput(
                "The game has ended, do you want to play a different game or close the casino?",
                " Different game",
                ">Close the casino");
        }

        [TestMethod]
        public void TestOpenEndOfGameMenu_PressArrowUp_PrintQuestionAndPossibilities()
        {
            // Arrange

            // Act
            _endOfGame.PressArrowUp(_menu);

            // Assert
            VerifyConsoleOutput(
                "The game has ended, do you want to play a different game or close the casino?",
                ">Different game",
                " Close the casino");
        }

        [TestMethod]
        public void TestOpenEndOfGameMenu_PrintQuestionAndPossibilities_PressEnter()
        {
            // Arrange

            // Act
            _endOfGame.PressEnter(_menu);

            // Assert
            Assert.IsInstanceOfType(_menu.State, typeof(GameChooser));
        }

        [TestMethod]
        public void TestOpenEndOfGameMenu_PressArrowDown_PrintQuestionAndPossibilities_PressEnter2()
        {
            // Arrange

            // Act
            _endOfGame.PressArrowDown(_menu);
            _endOfGame.PressEnter(_menu);

            // Assert
            VerifyConsoleOutput(
                "Dear player, thank you very much for visiting our casino, hope we see you soon!",
                "[Press any key to close the casino]");
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
