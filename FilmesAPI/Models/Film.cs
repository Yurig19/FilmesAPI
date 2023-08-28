﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Film
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public string Title { get; set; }
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "A quantidade de caracteres não pode exceder 50")]
    public string Gender { get; set; }
    [Required(ErrorMessage = "A duração do filme é obrigatório")]
    [Range(70, 600, ErrorMessage = "A duração deve ser entre 70 e 600 minutos")]
    public int Duration { get; set; }
    public virtual ICollection<Session> Sessions { get; set; }
}
