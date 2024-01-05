using db_thesis.Models;
using Microsoft.EntityFrameworkCore;

namespace db_thesis.Utility
{
	public class ThesisDbContext : DbContext
	{
		public ThesisDbContext(DbContextOptions<ThesisDbContext> options) : base(options) { }

		public DbSet<Person> Persons { get; set; }
		public DbSet<Author> Authors { get; set; }

		public DbSet<Supervisor> Supervisors { get; set; }

        public DbSet<Thesis> Thesisses { get; set; }
        public DbSet<ThesisType> Types { get; set; }

        public DbSet<University> Universities { get; set; }
        public DbSet<Institue> Institues { get; set; }
        public DbSet<Language> Languages { get; set; }

    }
}
