using System.Text;
using Top.Scorers.Data;
using Top.Scorers.Domain.Interfaces;
using Top.Scorers.Domain.Models;

namespace Top.Scorers.Domain.Services
{
    public class PersonService : IPersonService
    {
        private ICsvHandler _csvHandler;
        private IPersonRepository _personRepository;
        public PersonService(ICsvHandler csvHandler, IPersonRepository personRepository)
        {
            _csvHandler = csvHandler;
            _personRepository = personRepository;
        }

        public List<Person> GetAll()
        {
            var stringList = _csvHandler.Read();
            var people = new List<Person>();

            foreach (var person in stringList.Skip(1))//Assuming that the first row will be always be heading
            {
                var x = person.Split(',');
                var y = new Person { FirstName = x[0], LastName = x[1], Score = int.Parse(x[2]) };//Assuming that score will always be int value

                people.Add(y);
            }

            return people;
        }

        public List<Person> GetTop()
        {
            var people = GetAll();
            var maxScore = people.Max(x => x.Score);
            var result = people.OrderBy(x => x.FirstName).Where(x => x.Score == maxScore).Select(y => y).ToList();
            return result;
        }

        public string PrintTop()
        {
            var top = GetTop();
            var result = new StringBuilder();
            foreach (var person in top)
            {
                result.AppendLine($"{person.FirstName} {person.LastName}");
            }
            result.AppendLine($"Score: {top.Last().Score}");

            return result.ToString();
        }

        public Person Get(int id)
        {
            var result = _personRepository.GetPerson(id);
            if (result == null)
            {
                return null;
            }

            return MapFromEntity(result);
        }
        public bool Save(Person person)
        {
            var entity = MapToEntity(person);
            
            var result = _personRepository.SavePerson(entity);
            
            return result;
        }

        private Person MapFromEntity(Data.Entities.Person person)
        {
            return new Person
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Score = person.Score
            };
        }

        private Data.Entities.Person MapToEntity(Person person)
        {
            return new Data.Entities.Person
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Score = person.Score
            };
        }
    }
}
