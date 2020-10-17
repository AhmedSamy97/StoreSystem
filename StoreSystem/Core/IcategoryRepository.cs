using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreSystem.Models;

namespace StoreSystem.Core
{
    public interface IcategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();

       Task<bool> Add(Category category);
    }
}
