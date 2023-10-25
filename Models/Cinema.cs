using eCommerce.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Cinema Logo")]
        public string Logo { get; set; }
        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Cinema Name should be between 3 and 50 chars.")]
        public string Name { get; set; }
        [Display(Name = "Cinema Description")]
        public string Description { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
