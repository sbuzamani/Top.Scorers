using Top.Scorers.Data.Entities;

namespace Top.Scorers.Tests
{
    public static class ObjectMother
    {
        public static List<string> GetStringList()
        {
            return new List<string> { "Name,Surname,Score", "Kudu, Zela, 99", "Max, Keeble, 100, Dan, The Man, 80" };
        }

        public static Person GetPerson()
        {
            return new Data.Entities.Person { Id = 2, FirstName = "Max", LastName = "Ine", Score = 56 };
        }
    }
}
