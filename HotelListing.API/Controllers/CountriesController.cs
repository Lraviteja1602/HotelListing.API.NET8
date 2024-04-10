using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using AutoMapper;
using HotelListing.API.IRepository;
using HotelListing.API.Repository;
using HotelListing.API.DTO_s.Country;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;

        public CountriesController(IMapper mapper,ICountriesRepository countriesRepository)
        {
            _mapper = mapper;
            _countriesRepository = countriesRepository;

        }

        //Task<ActionResult<IEnumerable<TEntity>>> Get()

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var country = await _countriesRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCountryDto>>(country);
            return Ok(records);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        { 
            var country = await _countriesRepository.GetDetails(id);

            if (country == null)
            {
                return NotFound();
            }

            var countryDto = _mapper.Map<CountryDto>(country);

            return Ok(countryDto);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
        {
            if (id != updateCountryDto.Id)
            {
                return BadRequest();
            }
            //_context.Entry(country).State = EntityState.Modified;
            var country = await _countriesRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            _mapper.Map(updateCountryDto, country);
            try
            {
                await _countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Country>> PostCountry(Country country)
        //{
        //    _context.Countries.Add(country);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        //}

        [HttpPost]
        public async Task<ActionResult<Country>> Create(CreateCountryDto createcountrydto)
        {
            //var country = new Country
            //{
            //    Name = createcountry.Name,
            //    ShortName = createcountry.ShortName,
            //};

            var country = _mapper.Map<Country>(createcountrydto);

            await _countriesRepository.AddAsync(country);

            return Ok(country);
        }


        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countriesRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            await _countriesRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}
