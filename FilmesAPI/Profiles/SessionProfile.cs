using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class SessionProfile: Profile
    {
        public SessionProfile()
        {
            CreateMap<CreateSessionDto, Session>();
            CreateMap<Session, ReadSessionDto>();
        }
    }
}
