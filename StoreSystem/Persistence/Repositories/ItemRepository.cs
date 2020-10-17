
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreSystem.Core;
using StoreSystem.Data;
using StoreSystem.Dtos;
using StoreSystem.Models;

namespace StoreSystem.Persistence.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _context;

        public ItemRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ItemInformation> GetAllItemOfSpecificSubCategory(int subcategoryId)
        {
            var AllItems = await GetListSortedWithPrice(subcategoryId);

            var Iteminfo = new ItemInformation(AllItems);
            if (AllItems.Count() > 0)
                Iteminfo.Qtys = Iteminfo.Quantities.Sum();

            return Iteminfo;
        }

        private async Task<List<Item>> GetListSortedWithPrice(int subcategoryId)
        {
            return await _context.Items.Where(i => i.SubCategoryId == subcategoryId)
                .Include(a => a.SubCategory).OrderBy(a => a.PricePerUnit).ToListAsync();
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

        public async Task EditQuantityinItems(EditItemDto dto)
        {
            var SortedItem = await GetListSortedWithPrice(dto.subcategoryId);
            for (int i = 0; i < SortedItem.Count; i++)
            {
                SortedItem[i].Qty = dto.qtysArr[i];
            }
        }

        private bool CheckValidateItem(Item item)
        {
            return _context.Items.Count(i =>
                i.SubCategoryId == item.SubCategoryId && i.PricePerUnit == item.PricePerUnit) == 0;

        }

    }
}
