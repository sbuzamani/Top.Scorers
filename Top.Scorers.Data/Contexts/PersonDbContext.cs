using Microsoft.EntityFrameworkCore;
using Top.Scorers.Data.Entities;

namespace Top.Scorers.Data.Contexts
{
    public class PersonDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public PersonDbContext(DbContextOptions<PersonDbContext> options): base(options)
        {
             
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=PersonDatabase.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
        }
    }
}
