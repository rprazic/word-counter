using Microsoft.EntityFrameworkCore;

namespace WordCounter.Infrastructure
{
    public class WordCountDbContext : DbContext
    {
        public WordCountDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TextData> TextData { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ConfigureTables(builder);
        }

        private void ConfigureTables(ModelBuilder builder)
        {
            builder.Entity<TextData>().
                Property(c => c.Text);
        }
    }
}
