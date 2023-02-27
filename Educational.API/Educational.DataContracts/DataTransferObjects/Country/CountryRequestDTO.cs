using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.DataTransferObjects.Country
{
    public  class CountryRequestDTO
    {

        public string? Code { get; set; }
        public string? Name { get; set; }
        public int? Status { get; set; }
        public string? Currency { get; set; }
    }
}
