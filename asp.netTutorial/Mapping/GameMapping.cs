using asp.netTutorial.Dtos;
using asp.netTutorial.Entities;
using Microsoft.EntityFrameworkCore;

namespace asp.netTutorial.Mapping
{
    public static class GameMapping
    {
        public static Game ToEntity(this CreateGameDto game)
        {
            return new Game()
            {

                Name = game.Name,
                GenreId = game.Genre,
                ReleaseDate = game.ReleaseDate
            };

        }

        public static GameDto ToDto(this Game game)
        {
            return new(
                    Id: game.Id,
                    Name: game.Name,
                    genre: game.Genre!.Name,
                    Price: game.Name.Length,
                    RealseDate: game.ReleaseDate

                );

        }
    }
}
