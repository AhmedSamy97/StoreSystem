using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreSystem.Core;
using StoreSystem.Data;
using StoreSystem.Persistence.Repositories;

namespace StoreSystem.Persistence
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DataContext _context;
        public IcategoryRepository Categories { get; }
        public ISubCategoryRepository SubCategories { get; }
        public IItemRepository Items { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Categories = new CategoryRepository(context);
            SubCategories = new SubCategoryRepository(context);
            Items = new ItemRepository(context);
        }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
