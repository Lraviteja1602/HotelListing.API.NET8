using System.ComponentModel.DataAnnotations;
namespace HotelListing.API.DTO_s.Country
{
    public abstract class BaseCountryDto
    {
        [Required]
        public string Name { get; set; }

        public string ShortName { get; set; }
    }
}
