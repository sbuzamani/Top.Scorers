using Moq;
using Top.Scorers.Domain.Interfaces;
using Top.Scorers.Domain.Models;
using Top.Scorers.Domain.Services;

namespace Top.Scorers.Tests
{
    public class PersonServiceTests
    {
        private IPersonService _personService;
        private Mock<ICsvHandler> _csvHandler;
        public PersonServiceTests()
        {
            _csvHandler = new Mock<ICsvHandler>();
            _personService = new PersonService(_csvHandler.Object);
        }
        [Fact]
        public void GetAll_ValidInputList_ReturnsListOfPeople()
        {
            var stringList = new List<string> { "Name,Surname,Score", "Kudu, Zela, 99"};
            _csvHandler.Setup(x => x.Read()).Returns(stringList);
            var result = _personService.GetAll();
            Assert.NotEmpty(result);
            Assert.IsType<List<Person>>(result);
        }
        [Fact]
        public void GetTop_ValidList_ReturnsTopResult()
        {
            var stringList = new List<string> { "Name,Surname,Score", "Kudu, Zela, 99", "Max, Keeble, 100, Dan, The Man, 80" };
            _csvHandler.Setup(x => x.Read()).Returns(stringList);
            var result = _personService.GetTop();
            Assert.Single(result);
            Assert.IsType<List<Person>>(result);
        }
        [Fact]
        public void PrintTop_ValidList_ReturnsSingleStringToPrint()
        {
            var stringList = new List<string> { "Name,Surname,Score", "Kudu, Zela, 99", "Max, Keeble, 100, Dan, The Man, 80" };
            _csvHandler.Setup(x => x.Read()).Returns(stringList);
            var result = _personService.PrintTop();
            Assert.NotEmpty(result);
            Assert.Contains("Max", result);
            Assert.Contains("Score: ", result);
        }

        [Fact]
        public void Get_ValidId_ReturnsValidPerson()
        {
            var result = _personService.Get(2);
            Assert.NotNull(result);
            Assert.IsType<Person>(result);
            Assert.Equal("Max", result.FirstName);
            Assert.Equal("Ine", result.LastName);
            Assert.Equal(56, result.Score);
        }
    }
}
