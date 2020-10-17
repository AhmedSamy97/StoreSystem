using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreSystem.Core
{
  public  interface IUnitOfWork
    {
        IcategoryRepository Categories { get; }
        ISubCategoryRepository SubCategories { get; }
        IItemRepository Items { get; }
        void Complete();
    }
}
