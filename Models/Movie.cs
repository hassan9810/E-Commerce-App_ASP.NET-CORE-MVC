using eCommerce.Data.Entity;
using eCommerce.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models
{
    public class Movie : IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set;}
        public string ImageURL { get; set; }

        public MovieCategory MovieCategory { get; set;}

        public List<Actor_Movie> Actor_Movies { get; set; }

        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
