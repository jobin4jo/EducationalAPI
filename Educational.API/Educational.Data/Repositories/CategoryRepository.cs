using Educational.DataContracts.DataTransferObjects;
using Educational.DataContracts.IRepositories;
using Educational.DataContracts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly EducationalContext _context;
        public CategoryRepository(EducationalContext context)
        {
            this._context = context;
        }

        public async Task<int> AddCategory(CategoryRequestDTO categoryRequset)
        {
            TbCategory category = new TbCategory();
            category.CategoryName=categoryRequset.CategoryName;
            category.Status = 1;
            category.CreatedOn = DateTime.Now;
            this._context.TbCategories.Add(category);
            await this._context.SaveChangesAsync();
            return category.CategoryId;
        }

        

        public async Task<List<CategoryResponseDTO> >GetAllCategory()
        {
            List<CategoryResponseDTO> categoryResponses = await (from cat in _context.TbCategories
                                                                 where cat.Status == 1
                                                                 select (new CategoryResponseDTO
                                                                 {
                                                                     CategoryId = cat.CategoryId,
                                                                     CategoryName = cat.CategoryName,
                                                                     Status = cat.Status,
                                                                 })).ToListAsync();

            return categoryResponses;   
        }

        public async Task<CategoryResponseDTO> GetCategoryById(int id)
        {
            CategoryResponseDTO categoryResponse = ( from cat in _context.TbCategories
                                                          where cat.Status == 1 && cat.CategoryId == id
                                                          select (new CategoryResponseDTO
                                                          {
                                                              CategoryId = cat.CategoryId,
                                                              CategoryName = cat.CategoryName,
                                                              Status = cat.Status,
                                                          })).First();
            return categoryResponse;
        }

        public async Task<int> DeleteCategoryById(int id)
        {
            var categoryData= await _context.TbCategories.FindAsync(id);
            categoryData.Status = 0;
            categoryData.DeletedOn = DateTime.Now;
            _context.Entry(categoryData).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return categoryData.CategoryId;
        }
    }
}
