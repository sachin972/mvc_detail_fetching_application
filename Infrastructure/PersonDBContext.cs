using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Infrastructure
{
    public class PersonDBContext : DbContext
    {
        public PersonDBContext(DbContextOptions<PersonDBContext> options) : base(options) { 

        }

        public DbSet<PersonModel> PersonModels { get; set; }
    }
}
