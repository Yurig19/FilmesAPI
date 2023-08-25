using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

public class AddressProfile:Profile
{
    public AddressProfile()
    {
        CreateMap<CreateAddressDto, Address>();
        CreateMap<Address, ReadAddressDto>();
        CreateMap<UpdateAddressDto, Address>();
    }
}
