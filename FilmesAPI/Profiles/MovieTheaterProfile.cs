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
            CreateMap<MovieTheater, ReadMovieTheaterDto >().ForMember(MovieTheaterDto => MovieTheaterDto.Address, opts => opts.MapFrom(movieTheater => movieTheater.Address));
            CreateMap<UpdateMovieTheaterDto, MovieTheater>();
        }
    }
}
