namespace asp.netTutorial.Entities
{
    public class Game
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public int GenreId { get; set; }

        public Genre? Genre { set; get; }

        public DateOnly ReleaseDate { get; set; }
    }
}
