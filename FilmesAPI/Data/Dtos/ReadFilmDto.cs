﻿namespace FilmesAPI.Data.Dtos;

public class ReadFilmDto
{
    public string Title { get; set; }
    public string Gender { get; set; }
    public int Duration { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public ICollection<ReadSessionDto> Sessions { get; set; }
}
