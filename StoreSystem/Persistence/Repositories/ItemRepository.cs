
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreSystem.Core;
using StoreSystem.Data;
using StoreSystem.Models;

namespace StoreSystem.Persistence.Repositories
{
    public class ItemRepository:IItemRepository
    {
        private readonly DataContext _context;

        public ItemRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Item>> GetAllItemOfSpecificSubCategory(int subcategoryId)
        {
            return await _context.Items.Where(i => i.SubCategoryId == subcategoryId).ToListAsync();
        }

        public async Task<bool> AddNewItem(Item item)
        {
            bool status = false;
            if (CheckValidateItem(item))
            {
                status = true;
                await _context.Items.AddAsync(item);
            }

            return status;
        }

        public async Task<Item> EditQuantityinItems(Item item)
        {
            throw new System.NotImplementedException();
        }

        private bool CheckValidateItem(Item item)
        {
            return _context.Items.Count(i =>
                i.SubCategoryId == item.SubCategoryId && i.PricePerUnit == item.PricePerUnit) == 0;

        }

    }
}
