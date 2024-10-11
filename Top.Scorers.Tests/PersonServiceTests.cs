using Moq;
using Top.Scorers.Data;
using Top.Scorers.Domain.Interfaces;
using Top.Scorers.Domain.Models;
using Top.Scorers.Domain.Services;

namespace Top.Scorers.Tests
{
    public class PersonServiceTests
    {
        private IPersonService _personService;
        private Mock<ICsvHandler> _mockCsvHandler;
        private Mock<IPersonRepository> _mockPersonRepository;
        public PersonServiceTests()
        {
            _mockCsvHandler = new Mock<ICsvHandler>();
            _mockPersonRepository = new Mock<IPersonRepository>();
            _personService = new PersonService(_mockCsvHandler.Object, _mockPersonRepository.Object);
        }
        [Fact]
        public void GetAll_ValidInputList_ReturnsListOfPeople()
        {
            _mockCsvHandler.Setup(x => x.Read()).Returns(ObjectMother.GetStringList());
            var result = _personService.GetAll();
            Assert.NotEmpty(result);
            Assert.IsType<List<Person>>(result);
        }
        [Fact]
        public void GetTop_ValidList_ReturnsTopResult()
        {
            _mockCsvHandler.Setup(x => x.Read()).Returns(ObjectMother.GetStringList());
            var result = _personService.GetTop();
            Assert.Single(result);
            Assert.IsType<List<Person>>(result);
        }
        [Fact]
        public void PrintTop_ValidList_ReturnsSingleStringToPrint()
        {
            _mockCsvHandler.Setup(x => x.Read()).Returns(ObjectMother.GetStringList());
            var result = _personService.PrintTop();
            Assert.NotEmpty(result);
            Assert.Contains("Max", result);
            Assert.Contains("Score: ", result);
        }

        [Fact]
        public void Get_ValidId_ReturnsValidPerson()
        {
            _mockPersonRepository.Setup(x => x.GetPerson(It.IsAny<int>())).Returns(ObjectMother.GetPerson());
            var result = _personService.Get(2);
            Assert.NotNull(result);
            Assert.IsType<Person>(result);
            Assert.Equal("Max", result.FirstName);
            Assert.Equal("Ine", result.LastName);
            Assert.Equal(56, result.Score);
        }
    }
}
