using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreSystem.Dtos;
using StoreSystem.Models;

namespace StoreSystem.Core
{
    public interface IItemRepository
    {
        Task<ItemInformation> GetAllItemOfSpecificSubCategory(int subcategoryId);
        Task<bool> AddNewItem(Item item);
        Task EditQuantityinItems(EditItemDto dto);
    }
}
