using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

public class FilmProfile : Profile
{
    public FilmProfile()
    {
        CreateMap<CreateFilmDto, Film>();
        CreateMap<UpdateFilmDto, Film>();
        CreateMap<Film, UpdateFilmDto>();
        CreateMap<Film, ReadFilmDto>();
    }
}
