using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ArnLehnerLB_426.Tests
{
    [TestClass]
    public class TextAreaTest
    {
        private Mock<IConsoleWrapper> _mockConsoleWrapper = null!;
        private IConsoleArea _textArea = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockConsoleWrapper = new Mock<IConsoleWrapper>();
            _textArea = new TextArea(0, 3, _mockConsoleWrapper.Object);
        }
        [TestMethod]
        public void TestRefreshArea()
        {
            // Arrange

            // Act
            _textArea.RefreshArea("Hello, World!");

            // Assert
            _mockConsoleWrapper.Verify(c => c.WriteLine("Hello, World!"));
        }

        [TestMethod]
        public void TestClearArea()
        {
            // Arrange

            // Act
            _textArea.RefreshArea("Hello, World!");
            _textArea.ClearArea();

            // Assert
            _mockConsoleWrapper.Verify(c => c.Write(""));
        }
    }
}
