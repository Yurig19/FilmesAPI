using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class MovieTheaterProfile: Profile
    {
        public MovieTheaterProfile()
        {
            CreateMap<CreateMovieTheaterDto, MovieTheater>();
            CreateMap<MovieTheater, ReadMovieTheaterDto>().ForMember(movieTheaterDto => movieTheaterDto.Address, opts => opts.MapFrom(movieTheater => movieTheater.Address)).ForMember(movieTheaterDto => movieTheaterDto.Sessions, opts => opts.MapFrom(movieTheater => movieTheater.Sessions));
            CreateMap<UpdateMovieTheaterDto, MovieTheater>();
        }
    }
}
