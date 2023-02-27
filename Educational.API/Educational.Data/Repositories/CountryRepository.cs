using AutoMapper;
using Educational.DataContracts.DataTransferObjects.Country;
using Educational.DataContracts.IRepositories;
using Educational.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Data.Repositories
{
    public class CountryRepository : ICountryRepository
        
    {
        private readonly EducationalContext _context;
        private readonly IMapper _mapper;
        public CountryRepository(EducationalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddCountry(CountryRequestDTO country)
        {
          
               var countryData= _mapper.Map<TbCountry>(country);
                countryData.Status = 1;
                countryData.CreatedOn = DateTime.Now;
                _context.TbCountries.Add(countryData);

            await _context.SaveChangesAsync();
        }

        public Task<int> DeleteCountry(CountryRequestDTO country)
        {
            throw new NotImplementedException();
        }

        public Task<List<CountryResponseDTO>> GetAllCountry()
        {
            throw new NotImplementedException();
        }

        public Task UpdateCountry(CountryRequestDTO country, int id)
        {
            throw new NotImplementedException();
        }
    }
}
