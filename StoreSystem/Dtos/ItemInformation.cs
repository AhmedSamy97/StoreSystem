using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreSystem.Models;

namespace StoreSystem.Dtos
{
    public class ItemInformation
    {
        public int[] Quantities { get; set; }
        public int SubcategoryID { get; set; }
        public string Name { get; set; }
        public decimal[] Prices { get; set; }
        public int Qtys { get; set; }
        public int? MinQty { get; set; }
        public ItemInformation(List<Item> items)
        {
            if (items.Count > 0)
            {
                Name = items[0].SubCategory.Name;
                SubcategoryID = items[0].SubCategoryId;
                Prices = GetPricesArray(items);
                Quantities = GetQuantities(items);
            }
            //MinQty = items[0].MinQty.Value;
        }

        private decimal[] GetPricesArray(List<Item> items)
        {
            decimal[] prices = new Decimal[items.Count];
            for (int i = 0; i < items.Count; i++)
            {
                prices[i] = items[i].PricePerUnit;
            }

            return prices;
        }

        private int[] GetQuantities(List<Item> items)
        {
            int[] qunatities = new int[items.Count];
            for (int i = 0; i < items.Count; i++)
            {
                qunatities[i] = items[i].Qty;
            }

            return qunatities;
        }
    }
}
