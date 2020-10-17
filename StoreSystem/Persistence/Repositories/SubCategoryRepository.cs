using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreSystem.Core;
using StoreSystem.Data;
using StoreSystem.Models;

namespace StoreSystem.Persistence.Repositories
{
    public class SubCategoryRepository:ISubCategoryRepository
    {
        private readonly DataContext _context;

        public SubCategoryRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SubCategory>> GetSubCategory_ForCategory(int categoryId)
        {
            return await _context.SubCategories.Where(s => s.CategoryId == categoryId).ToListAsync();
        }

        public async Task<bool> AddSubcategory(SubCategory subCategory)
        {
            if (CheckValidSubcategory(subCategory))
            {
                await _context.AddAsync(subCategory);
                return true;
            }

            return  false;
        }

        private bool CheckValidSubcategory(SubCategory subCategory)
        {
            return _context.Categories.Any(s => s.Id == subCategory.CategoryId) &&
                   _context.SubCategories.Count(s =>
                       s.CategoryId == subCategory.CategoryId && s.Name == subCategory.Name) == 0;

        }
    }
}
