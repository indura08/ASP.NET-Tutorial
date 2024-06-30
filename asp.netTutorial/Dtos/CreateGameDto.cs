using System.ComponentModel.DataAnnotations;

namespace asp.netTutorial.Dtos
{
    public record class CreateGameDto(
            [Required][StringLength(50)]string Name,        //me otu warahan athule daala tiyna ewa awilla validation wlata use krna dewla , dan meke required kiynne name saha anik required daala thiyna attributes okkomatam value ekk requird kiylai., e wagema thami anik annotaionuth , meka gana not ekk thiyna data annotaion kiyla notes folder eke 
            [Required][StringLength(20)]string Genre,
            [Range(1,100)]decimal Price,
            DateOnly ReleaseDate
        );
}
