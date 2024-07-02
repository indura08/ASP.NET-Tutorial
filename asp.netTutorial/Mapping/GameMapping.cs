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

        public static Game ToEntity(this UpdateDto game , int id)
        {
            return new Game()
            {
                Id = id,
                Name = game.name,
                GenreId = game.GenreId,
                ReleaseDate = game.releaseDate
            };

        }


        public static GamesummeryDto ToGameSummeryDto(this Game game)
        {
            return new(
                    Id: game.Id,
                    Name: game.Name,
                    genre: game.Genre!.Name,
                    Price: game.Name.Length,
                    RealseDate: game.ReleaseDate

                );

        }

        public static GameDetailsDto ToGameDetailsDto(this Game game)
        {
            return new(
                    Id: game.Id,
                    Name: game.Name,
                    genre: game.GenreId,
                    Price: game.Name.Length,
                    RealseDate: game.ReleaseDate

                );

        }
    }
}
