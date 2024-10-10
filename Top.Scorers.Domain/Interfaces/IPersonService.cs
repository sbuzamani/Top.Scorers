using Top.Scorers.Domain.Models;

namespace Top.Scorers.Domain.Interfaces
{
    public interface IPersonService
    {
        List<Person> GetAll();

        List<Person> GetTop();

        string PrintTop();

        Person Get(int id);

        bool Save(Person person);
    }
}