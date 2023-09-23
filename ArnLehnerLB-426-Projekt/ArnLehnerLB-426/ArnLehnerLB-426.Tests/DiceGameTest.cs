using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ArnLehnerLB_426.Tests
{
    [TestClass]
    public class DiceGameTest
    {
        private ISubject _player = null!;
        private Mock<IConsoleWrapper> _mockConsoleWrapper = null!;
        private IConsoleArea _textArea = null!;
        private DiceGame _diceGame = null!;
        private Menu _menu = null!;

        [TestInitialize]
        public void Setup()
        {
            _player = new Player(100);
            _mockConsoleWrapper = new Mock<IConsoleWrapper>();
            _textArea = new TextArea(0, 3, _mockConsoleWrapper.Object);
            _diceGame = new DiceGame(_mockConsoleWrapper.Object);
            _menu = new Menu();
        }

        [TestMethod]
        public void TestCorrectGuess()
        {
            // Arrange
            int guess = 3;
            int randomNumber = 3;

            // Act
            int prize = _diceGame.EvaluateResults(guess, randomNumber);

            // Assert
            Assert.AreEqual(30, prize);
        }

        [TestMethod]
        public void TestWrongGuess()
        {
            // Arrange
            int guess = 3;
            int randomNumber = 5;

            // Act
            int prize = _diceGame.EvaluateResults(guess, randomNumber);

            // Assert
            Assert.AreEqual(0, prize);
        }

        [TestMethod]
        public void TestOpenDiceGameMenu_PressEnter_EndRound()
        {
            // Arrange

            // Act
            _diceGame.PressEnter(_menu);

            // Assert
            Assert.IsInstanceOfType(_menu.State, typeof(EndOfRound));
        }

        [TestMethod]
        public void TestOpenDiceGameMenu_PrintQuestionAndAmount()
        {
            // Arrange

            // Act

            // Assert
            VerifyConsoleOutput(
                "Choose a number between 1-6, if it matches the number generated afterwards you have won.",
                ">1",
                " 2",
                " 3",
                " 4",
                " 5",
                " 6"
            );
        }

        [TestMethod]
        public void TestOpenDiceGameMenu_PressArrowDown_PrintQuestionAndAmount()
        {
            // Arrange

            // Act
            _diceGame.PressArrowDown(_menu);

            // Assert
            VerifyConsoleOutput(
                "Choose a number between 1-6, if it matches the number generated afterwards you have won.",
                " 1",
                ">2",
                " 3",
                " 4",
                " 5",
                " 6"
            );
        }

        [TestMethod]
        public void TestOpenDiceGameMenu_PressArrowDown2_PrintQuestionAndAmount()
        {
            // Arrange

            // Act
            for (int i = 0; i < 2; i++) _diceGame.PressArrowDown(_menu);

            // Assert
            VerifyConsoleOutput(
                "Choose a number between 1-6, if it matches the number generated afterwards you have won.",
                " 1",
                " 2",
                ">3",
                " 4",
                " 5",
                " 6"
            );
        }

        [TestMethod]
        public void TestOpenDiceGameMenu_PressArrowDown3_PrintQuestionAndAmount()
        {
            // Arrange

            // Act
            for (int i = 0; i < 3; i++) _diceGame.PressArrowDown(_menu);

            // Assert
            VerifyConsoleOutput(
                "Choose a number between 1-6, if it matches the number generated afterwards you have won.",
                " 1",
                " 2",
                " 3",
                ">4",
                " 5",
                " 6"
            );
        }

        [TestMethod]
        public void TestOpenDiceGameMenu_PressArrowDown4_PrintQuestionAndAmount()
        {
            // Arrange

            // Act
            for (int i = 0; i < 4; i++) _diceGame.PressArrowDown(_menu);     
            
            // Assert
            VerifyConsoleOutput(
                "Choose a number between 1-6, if it matches the number generated afterwards you have won.",
                " 1",
                " 2",
                " 3",
                " 4",
                ">5",
                " 6"
            );
        }

        [TestMethod]
        public void TestOpenDiceGameMenu_PressArrowDown5_PrintQuestionAndAmount()
        {
            // Arrange

            // Act
            for (int i = 0; i < 5; i++) _diceGame.PressArrowDown(_menu);

            // Assert
            VerifyConsoleOutput(
                "Choose a number between 1-6, if it matches the number generated afterwards you have won.",
                " 1",
                " 2",
                " 3",
                " 4",
                " 5",
                ">6"
            );
        }

        [TestMethod]
        public void TestOpenDiceGameMenu_PressArrowDown6_PrintQuestionAndAmount()
        {
            // Arrange

            // Act
            for (int i = 0; i < 6; i++) _diceGame.PressArrowDown(_menu);

            // Assert
            VerifyConsoleOutput(
                "Choose a number between 1-6, if it matches the number generated afterwards you have won.",
                ">1",
                " 2",
                " 3",
                " 4",
                " 5",
                " 6"
            );
        }

        [TestMethod]
        public void TestOpenDiceGameMenu_PressArrowUp_PrintQuestionAndAmount()
        {
            // Arrange

            // Act
            _diceGame.PressArrowUp(_menu);

            // Assert
            VerifyConsoleOutput(
                "Choose a number between 1-6, if it matches the number generated afterwards you have won.",
                ">1",
                " 2",
                " 3",
                " 4",
                " 5",
                " 6"
            );
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
