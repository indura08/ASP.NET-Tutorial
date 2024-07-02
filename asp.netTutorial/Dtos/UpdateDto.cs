using System.ComponentModel.DataAnnotations;

namespace asp.netTutorial.Dtos
{
    public record class UpdateDto(
        
            [Required][StringLength(50)]string name,
            int GenreId,
            [Range(1,100)]decimal price,
            DateOnly releaseDate
        );
    
}
