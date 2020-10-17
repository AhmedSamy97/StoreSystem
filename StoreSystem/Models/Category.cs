using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreSystem.Models
{
    [Table("Category")]

    public class Category
    {
        public Category()
        {
            SubCategory = new HashSet<SubCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubCategory> SubCategory { get; set; }
    }
}
