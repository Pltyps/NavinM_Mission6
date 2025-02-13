using Microsoft.EntityFrameworkCore;

namespace Mission06_Manirajan.Models
{
    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base (options) //Constructor
        { 
        }

        public DbSet<Record> Records { get; set; } //Property
    }

}
