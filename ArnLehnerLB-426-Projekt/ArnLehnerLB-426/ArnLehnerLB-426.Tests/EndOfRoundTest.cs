using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ArnLehnerLB_426.Tests
{
    [TestClass]
    public class EndOfRoundTests
    {
        private Mock<IConsoleWrapper> _mockConsoleWrapper = null!;
        private IConsoleArea _textArea = null!;
        private IState _endOfRound = null!;
        private Menu _menu = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockConsoleWrapper = new Mock<IConsoleWrapper>();
            _textArea = new TextArea(0, 3, _mockConsoleWrapper.Object);
            _endOfRound = new EndOfRound(2, _mockConsoleWrapper.Object);
            _menu = new Menu();
        }

        [TestMethod]
        public void TestOpenEndOfRound1Menu_PrintQuestionAndPossibilities()
        {
            // Act

            // Assert
            VerifyConsoleOutput(
                "The round is over, do you want to play again?",
                ">Yes",
                " No");
        }

        [TestMethod]
        public void TestOpenEndOfRound1Menu_PressArrowDown_PrintQuestionAndPossibilities()
        {
            // Act
            _endOfRound.PressArrowDown(_menu);

            // Assert
            VerifyConsoleOutput(
                "The round is over, do you want to play again?",
                " Yes",
                ">No");
        }

        [TestMethod]
        public void TestOpenEndOfRound1Menu_PressArrowUp_PrintQuestionAndPossibilities()
        {
            // Act
            _endOfRound.PressArrowUp(_menu);

            // Assert
            VerifyConsoleOutput(
                "The round is over, do you want to play again?",
                " Yes",
                ">No");
        }

        [TestMethod]
        public void TestOpenEndOfRound2Menu_PrintQuestionAndPossibilities()
        {
            // Act

            // Assert
            VerifyConsoleOutput(
                "The round is over, do you want to play again?",
                ">Yes",
                " No");
        }

        [TestMethod]
        public void TestOpenEndOfRound2Menu_PressArrowDown_PrintQuestionAndPossibilities()
        {
            // Act
            _endOfRound.PressArrowDown(_menu);

            // Assert
            VerifyConsoleOutput(
                "The round is over, do you want to play again?",
                " Yes",
                ">No");
        }

        [TestMethod]
        public void TestOpenEndOfRound2Menu_PressArrowUp_PrintQuestionAndPossibilities()
        {
            // Act
            _endOfRound.PressArrowUp(_menu);

            // Assert
            VerifyConsoleOutput(
                "The round is over, do you want to play again?",
                " Yes",
                ">No");
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
