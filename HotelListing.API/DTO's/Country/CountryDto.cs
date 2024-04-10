using HotelListing.API.DTO_s.Hotel;

namespace HotelListing.API.DTO_s.Country
{
    public class CountryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public virtual ICollection<HotelDto> Hotels { get; set; }
    }
}
