namespace asp.netTutorial.Dtos
{
    public record class GamesummeryDto(
        int Id,
        string Name,
        string genre,
        decimal Price,
        DateOnly RealseDate
        );
}
