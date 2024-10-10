using Top.Scorers.Data.Contexts;
using Top.Scorers.Data.Entities;

namespace Top.Scorers.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _personDbContext;
        public PersonRepository(PersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
            _personDbContext.Database.EnsureCreated();
        }
        public Person GetPerson(int id)
        {
            var person = _personDbContext.People.ToList().Where(x => x.Id == id).FirstOrDefault();
            return person;
        }

        public bool SavePerson(Person person)
        {
            try
            {
                _personDbContext.People.Add(person);
                _personDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
    }
}
