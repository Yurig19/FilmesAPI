using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Session
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
