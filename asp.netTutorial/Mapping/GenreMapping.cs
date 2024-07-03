using asp.netTutorial.Dtos;
using asp.netTutorial.Entities;

namespace asp.netTutorial.Mapping
{
    public static class GenreMapping
    {
        public static GenreDto ToDto(this Genre genre) {

            return new GenreDto(genre.Id, genre.Name);
        }
    }
}
