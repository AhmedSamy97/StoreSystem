using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreSystem.Models
{
    public class Item
    {

       // public Guid? ItemId { get; set; }
        public int SubCategoryId { get; set; }
        public int Qty { get; set; }
        public decimal PricePerUnit { get; set; }
        public int? MinQty { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
