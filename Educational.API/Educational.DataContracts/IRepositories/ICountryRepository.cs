using Educational.DataContracts.DataTransferObjects.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.IRepositories
{
    public  interface ICountryRepository
    {
        Task<List<CountryResponseDTO>> GetAllCountry();
        Task AddCountry(CountryRequestDTO country);
        Task UpdateCountry(CountryRequestDTO country,int id);
        Task<int> DeleteCountry(CountryRequestDTO country);
    }
}
