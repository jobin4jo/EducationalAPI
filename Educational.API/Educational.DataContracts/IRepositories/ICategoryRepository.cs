using Educational.DataContracts.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.IRepositories
{
    public  interface ICategoryRepository
    {
        Task<int> AddCategory(CategoryRequestDTO categoryRequset);
        Task<List<CategoryResponseDTO>> GetAllCategory();
        Task<CategoryResponseDTO> GetCategoryById(int id);
        Task<int>DeleteCategoryById(int id);    
    }
}
