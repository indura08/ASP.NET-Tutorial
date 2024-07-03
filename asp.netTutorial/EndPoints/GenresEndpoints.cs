using asp.netTutorial.Data;
using asp.netTutorial.Mapping;
using Microsoft.EntityFrameworkCore;

namespace asp.netTutorial.EndPoints
{
    public static class GenresEndpoints
    {
        public static RouteGroupBuilder MapGenereEndPoints(this WebApplication app)
        {
            var group = app.MapGroup("genres");

            group.MapGet("/", async (GameStoreContext dbContext) =>

                await dbContext.Genres.Select(genre => genre.ToDto()).AsNoTracking().ToListAsync());


            return group;
        }
    }
}
