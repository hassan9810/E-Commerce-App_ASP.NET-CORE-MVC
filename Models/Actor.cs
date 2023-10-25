using eCommerce.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class Actor :IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage ="Profile Picture is required")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Actor Name should be between 3 and 50 chars. ")]

        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        // Relationship //
        public List<Actor_Movie>? Actor_Movies { get; set;}
    }
}
