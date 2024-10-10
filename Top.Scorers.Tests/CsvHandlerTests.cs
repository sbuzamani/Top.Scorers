using Top.Scorers.Domain.Interfaces;
using Top.Scorers.Domain.Services;

namespace Top.Scorers.Tests
{
    public class CsvHandlerTests
    {
        private ICsvHandler _csvHandler;
        private string filePath = "TestData.csv";
        public CsvHandlerTests()
        {
            _csvHandler = new CsvHandler(filePath);
        }

        [Fact]
        public void Read_ValidFile_ReturnsListOfString()
        {
            var result = _csvHandler.Read();
            Assert.NotNull(result);
            Assert.IsType<List<String>>(result);
        }
    }
}