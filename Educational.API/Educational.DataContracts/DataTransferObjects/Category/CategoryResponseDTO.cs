using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.DataTransferObjects
{
    public  class CategoryResponseDTO
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? Status { get; set; }
    }
}
