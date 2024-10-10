using Top.Scorers.Data.Entities;

namespace Top.Scorers.Data
{
    public interface IPersonRepository
    {
        Person GetPerson(int id);
        bool SavePerson(Person person);
    }
}
