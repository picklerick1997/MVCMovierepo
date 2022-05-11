using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class MovieReview
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        [Required]
        public string Body { get; set; }

        public Movie Film { get; set; }
        public int FilmId { get; set; }
    }
}
