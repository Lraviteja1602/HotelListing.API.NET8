using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.DTO_s.Country;
using HotelListing.API.DTO_s.Hotel;
//using HotelListing.API.DTO.Country;
//using HotelListing.API.DTO.Hotel;

namespace HotelListing.API.AutoMapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, GetCountryDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();

            CreateMap<Hotel, HotelDto>().ReverseMap();

        }
    }

}
