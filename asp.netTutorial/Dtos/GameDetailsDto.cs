namespace asp.netTutorial.Dtos
{
    public record class GameDetailsDto(
        int Id,
        string Name,
        int genre,
        decimal Price,
        DateOnly RealseDate
        );
}
