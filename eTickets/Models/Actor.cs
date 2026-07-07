using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;
namespace eTickets.Models;
public class Actor : IEntityBase
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "Full Name")]
    [Required(ErrorMessage = "FullNmae is Required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "FullName must be between 3 and 50 charachters")]
    public string FullName { get; set; } = String.Empty;
    
    [Display(Name = "Profile Picture")]
    [Required(ErrorMessage ="Profile Picture Url is Required")]
    public string ProfilePictureURL { get; set; } = String.Empty;

    [Display(Name = "Biography")]
    [Required(ErrorMessage = "Biography is Required")]
    public string Bio { get; set; } = String.Empty;

    //Relationships
    public List<Actor_Movie>? Actors_Movies { get; set; }
}
