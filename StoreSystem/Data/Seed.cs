using System;
using System.Collections.Generic;
using System.Linq;
using StoreSystem.Models;

namespace StoreSystem.Data
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Categories.Any())
            {
                var categries = new List<Category>{
                    new Category{Name="Computers"},
                    new Category{Name="Furniture"},
                    new Category{Name="Pharmacy"},
                };
                context.Categories.AddRange(categries);
            }
            if (!context.SubCategories.Any())
            {
                var subCategories = new List<SubCategory>{
                    new SubCategory{CategoryId= 1,Name= "KeyBoard"},
                    new SubCategory{CategoryId= 1,Name= "Mouse"},
                    new SubCategory{CategoryId= 1,Name= "HeadPhone"}
                };
                context.SubCategories.AddRange(subCategories);
            }
            if (!context.Items.Any())
            {
                var items = new List<Item>{
                    new Item{SubCategoryId = 1 , Qty = 5,PricePerUnit = 15,MinQty=1},
                    new Item{SubCategoryId = 1 , Qty = 4,PricePerUnit = 5,MinQty=1},
                };
                context.Items.AddRange(items);
            }
            context.SaveChanges();
        }
    }
}