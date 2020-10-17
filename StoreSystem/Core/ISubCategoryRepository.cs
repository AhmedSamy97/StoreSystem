using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreSystem.Models;

namespace StoreSystem.Core
{
   public interface ISubCategoryRepository
   {
       Task<IEnumerable<SubCategory>> GetSubCategory_ForCategory(int categoryId);
       Task<bool> AddSubcategory(SubCategory subCategory);
   }
}
