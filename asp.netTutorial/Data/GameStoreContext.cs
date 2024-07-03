using asp.netTutorial.Entities;
using Microsoft.EntityFrameworkCore;

namespace asp.netTutorial.Data
{
    public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
    {
        public DbSet<Game> Games => Set<Game>();
        public DbSet<Genre> Genres => Set<Genre>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                
                    new { Id = 1 , Name = "fighting"},
                    new { Id = 2, Name = "Roleplaying" },
                    new { Id = 3, Name = "Sports" },
                    new { Id = 4, Name = "Racing"},
                    new { Id = 5, Name = "Kids and Family" }    //me awilla genere table ekt app ek ptan gaddima wage data athulth krnwa

                );

            //me model builder ekn apita krnna puluwan dewal 
            //1.Entity Configuration: You can configure individual entities, including specifying primary keys, column types, and constraints.
            //2.Relationship Configuration: You can define relationships between entities, such as one-to-one, one-to-many, and many-to-many relationships.
            //3.Seeding Data: You can seed initial data into your database.
            //4.Conventions: You can override EF Core's conventions to customize the mappings.
        }
    }
}
