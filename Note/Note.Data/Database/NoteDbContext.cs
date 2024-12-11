using Microsoft.EntityFrameworkCore;
using Note.Data.Configuration;

namespace Note.Data.Database
{
    public class NoteDbContext : DbContext
    {
        public DbSet<Book>? Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add all the configuration in the assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookEntityTypeConfiguration).Assembly);
        }
    }
}
