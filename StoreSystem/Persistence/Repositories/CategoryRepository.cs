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
    public class CategoryRepository:IcategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
           return await _context.Categories.ToListAsync();
        }

        public async Task<bool> Add(Category category)
        {
            bool status = _context.Categories.Any(a => a.Name == category.Name);
            await _context.Categories.AddAsync(category);
            return status;
        }
    }
}
