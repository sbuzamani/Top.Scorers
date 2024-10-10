using System.ComponentModel.DataAnnotations;

namespace Top.Scorers.Data.Entities
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int Score { get; set; }
    }
}
