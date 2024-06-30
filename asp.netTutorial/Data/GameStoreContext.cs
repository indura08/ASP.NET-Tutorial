using asp.netTutorial.Entities;
using Microsoft.EntityFrameworkCore;

namespace asp.netTutorial.Data
{
    public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
    {
        public DbSet<Game> Games => Set<Game>();
        public DbSet<Genre> Genres => Set<Genre>();
    }
}
