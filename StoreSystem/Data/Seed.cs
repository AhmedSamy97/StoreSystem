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
                //run this have ForeignKey Relation
                context.SaveChanges();

            }
            if (!context.Items.Any())
            {
                var items = new List<Item>{
                    new Item{SubCategoryId = 1 , Qty = 5,PricePerUnit = 3,MinQty=1},
                    new Item{SubCategoryId = 1 , Qty = 4,PricePerUnit = 1,MinQty=null},
                };
                context.Items.AddRange(items);
            }
            context.SaveChanges();
        }
    }
}