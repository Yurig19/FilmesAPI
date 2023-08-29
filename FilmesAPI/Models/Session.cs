using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Session
    {
        public int? FilmId { get; set; }
        public virtual Film Film { get; set; }
        public int? MovieTheaterId { get; set; }
        public virtual MovieTheater MovieTheater { get; set; }
    }
}
