using DniApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DniApi.DataContext
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
    }
}
