using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreSystem.Models;

namespace StoreSystem.Core
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllItemOfSpecificSubCategory(int subcategoryId);
        Task<bool> AddNewItem(Item item);
        Task<Item> EditQuantityinItems(Item item);
    }
}
