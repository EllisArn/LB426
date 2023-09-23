using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ArnLehnerLB_426.Tests
{
    [TestClass]
    public class JetonChangeTest
    {
        private ISubject _player = null!;
        private Mock<IConsoleWrapper> _mockConsoleWrapper = null!;
        private IConsoleArea _textArea = null!;
        private IState _jetonChange = null!;
        private Menu _menu = null!;

        [TestInitialize]
        public void Setup()
        {
            _player = new Player(0);
            _mockConsoleWrapper = new Mock<IConsoleWrapper>();
            _textArea = new TextArea(0, 3, _mockConsoleWrapper.Object);
            _jetonChange = new JetonChange();
            _menu = new Menu();
        }

        [TestMethod]
        public void TestOpenJetonChangeMenu_PrintQuestionAndAmount()
        {
            // Arrange

            // Act

            // Assert
            VerifyConsoleOutput(
                "How many jetons do you want?",
                ">100",
                " 200",
                " 300",
                " 400",
                " 500");
        }

        [TestMethod]
        public void TestOpenJetonChangeMenu_PressArrowDown_PrintQuestionAndAmount()
        {
            // Arrange

            // Act
            _jetonChange.PressArrowDown(_menu);

            // Assert
            VerifyConsoleOutput(
                "How many jetons do you want?",
                " 100",
                ">200",
                " 300",
                " 400",
                " 500");
        }

        [TestMethod]
        public void TestOpenJetonChangeMenu_PressArrowDown2_PrintQuestionAndAmount()
        {
            // Arrange

            // Act
            for (int i = 0; i < 2; i++) _jetonChange.PressArrowDown(_menu);

            // Assert
            VerifyConsoleOutput(
                "How many jetons do you want?",
                " 100",
                " 200",
                ">300",
                " 400",
                " 500");
        }

        [TestMethod]
        public void TestOpenJetonChangeMenu_PressArrowDown3_PrintQuestionAndAmount()
        {
            // Arrange

            // Act
            for (int i = 0; i < 3; i++) _jetonChange.PressArrowDown(_menu);

            // Assert
            VerifyConsoleOutput(
                "How many jetons do you want?",
                " 100",
                " 200",
                " 300",
                ">400",
                " 500");
        }

        [TestMethod]
        public void TestOpenJetonChangeMenu_PressArrowDown4_PrintQuestionAndAmount()
        {
            // Arrange

            // Act
            for (int i = 0; i < 4; i++) _jetonChange.PressArrowDown(_menu);

            // Assert
            VerifyConsoleOutput(
                "How many jetons do you want?",
                " 100",
                " 200",
                " 300",
                " 400",
                ">500");
        }

        [TestMethod]
        public void TestOpenJetonChangeMenu_PressArrowDown5_PrintQuestionAndAmount()
        {
            // Arrange

            // Act
            for (int i = 0; i < 5; i++) _jetonChange.PressArrowDown(_menu);

            // Assert
            VerifyConsoleOutput(
                "How many jetons do you want?",
                ">100",
                " 200",
                " 300",
                " 400",
                " 500");
        }

        [TestMethod]
        public void TestOpenJetonChangeMenu_PressArrowUp_PrintQuestionAndAmount()
        {
            // Arrange

            // Act
            _jetonChange.PressArrowUp(_menu);

            // Assert
            VerifyConsoleOutput(
                "How many jetons do you want?",
                " 100",
                " 200",
                " 300",
                " 400",
                ">500");
        }

        [TestMethod]
        public void TestOpenJetonChangeMenu_PrintQuestionAndAmount_PressEnter()
        {
            // Arrange

            // Act
            _jetonChange.PressEnter(_menu);

            // Assert
            Assert.AreEqual(100, _player.Jetons);
        }

        [TestMethod]
        public void TestOpenJetonChangeMenu_PressArrowDown_PrintQuestionAndAmount_PressEnter()
        {
            // Arrange

            // Act
            _jetonChange.PressArrowDown(_menu);
            _jetonChange.PressEnter(_menu);

            // Assert
            Assert.AreEqual(200, _player.Jetons);
        }

        [TestMethod]
        public void TestOpenJetonChangeMenu_PressArrowDown2_PrintQuestionAndAmount_PressEnter()
        {
            // Arrange

            // Act
            for (int i = 0; i < 2; i++) _jetonChange.PressArrowDown(_menu);
            _jetonChange.PressEnter(_menu);

            // Assert
            Assert.AreEqual(300, _player.Jetons);
        }

        [TestMethod]
        public void TestOpenJetonChangeMenu_PressArrowDown3_PrintQuestionAndAmount_PressEnter()
        {
            // Arrange

            // Act
            for (int i = 0; i < 3; i++) _jetonChange.PressArrowDown(_menu);
            _jetonChange.PressEnter(_menu);

            // Assert
            Assert.AreEqual(400, _player.Jetons);
        }

        [TestMethod]
        public void TestOpenJetonChangeMenu_PressArrowDown4_PrintQuestionAndAmount_PressEnter()
        {
            // Arrange

            // Act
            for (int i = 0; i < 4; i++) _jetonChange.PressArrowDown(_menu);
            _jetonChange.PressEnter(_menu);

            // Assert
            Assert.AreEqual(500, _player.Jetons);
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
