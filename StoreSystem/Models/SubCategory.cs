using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreSystem.Models
{
    public class SubCategory
    {
        public SubCategory()
        {
            Items = new HashSet<Item>();
        }

        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
