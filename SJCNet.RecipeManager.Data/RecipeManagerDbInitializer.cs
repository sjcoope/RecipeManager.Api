using SJCNet.RecipeManager.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Data
{
    public class RecipeManagerDbInitializer : DropCreateDatabaseIfModelChanges<RecipeManagerDbContext>
    {
        protected override void Seed(RecipeManagerDbContext context)
        {
            #region Categories
            
            var categoryBreakfast = new Category { Name = "Breakfast" };
            context.Categories.Add(categoryBreakfast);

            var categoryLunch = new Category { Name = "Lunch" };
            context.Categories.Add(categoryLunch);

            var categoryDinner = new Category { Name = "Dinner" };
            context.Categories.Add(categoryDinner);

            var categorySnack = new Category { Name = "Snacks" };
            context.Categories.Add(categorySnack);

            #endregion

            #region Measurements

            // Add Measurements
            var measurementGrams = new Measurement { Name = "Grams" };
            context.Measurements.Add(measurementGrams);

            var measurementCups = new Measurement { Name = "Cups" };
            context.Measurements.Add(measurementCups);

            var measurementUnit = new Measurement { Name = "Unit" };
            context.Measurements.Add(measurementUnit);

            #endregion

            #region Products

            // Add Products
            var productFlour = new Product { Name = "Plain Flour" };
            context.Products.Add(productFlour);
            
            var productEgg = new Product { Name = "Egg" };
            context.Products.Add(productEgg);

            var productSugar = new Product { Name = "Sugar" };
            context.Products.Add(productSugar);

            var productButter = new Product { Name = "Butter" };
            context.Products.Add(productButter);

            var productMilk = new Product { Name = "Milk" };
            context.Products.Add(productMilk);

            #endregion

            #region Recipes

            // Recipe 1
            var recipe1 = new Recipe { Name = "Test One", Description = "Test Description One", Category = categoryBreakfast };
            
            // Recipe 1 - Steps
            recipe1.Steps.Add(new Step { Description = "Step One", SortOrder = 1 });
            recipe1.Steps.Add(new Step { Description = "Step Two", SortOrder = 2 });
            recipe1.Steps.Add(new Step { Description = "Step Three", SortOrder = 3 });

            // Recipe 1 - Ingredients
            recipe1.Ingredients.Add(new Ingredient { Unit = 100, Measurement = measurementGrams, Product = productFlour, SortOrder = 1 });
            recipe1.Ingredients.Add(new Ingredient { Unit = 1, Measurement = measurementUnit, Product = productEgg, SortOrder = 2 });
            recipe1.Ingredients.Add(new Ingredient { Unit = 2, Measurement = measurementCups, Product = productSugar, SortOrder = 3 });
            recipe1.Ingredients.Add(new Ingredient { Unit = 100, Measurement = measurementGrams, Product = productButter, SortOrder = 4 });
            recipe1.Ingredients.Add(new Ingredient { Unit = 100, Measurement = measurementGrams, Product = productMilk, SortOrder = 5 });

            context.Recipes.Add(recipe1);

            // Recipe 2
            var recipe2 = new Recipe { Name = "Test Two", Description = "Test Description Two", Category = categoryDinner };
            
            // Recipe 2 - Steps
            recipe2.Steps.Add(new Step { Description = "Step One", SortOrder = 1 });
            recipe2.Steps.Add(new Step { Description = "Step Two", SortOrder = 2 });
            recipe2.Steps.Add(new Step { Description = "Step Three", SortOrder = 3 });
            recipe2.Steps.Add(new Step { Description = "Step Four", SortOrder = 4 });
            recipe2.Steps.Add(new Step { Description = "Step Five", SortOrder = 5 });
            
            // Recipe 2 - Ingredients
            recipe2.Ingredients.Add(new Ingredient { Unit = 100, Measurement = measurementGrams, Product = productFlour, SortOrder = 1 });
            recipe2.Ingredients.Add(new Ingredient { Unit = 1, Measurement = measurementUnit, Product = productEgg, SortOrder = 2 });

            context.Recipes.Add(recipe2);

            // Recipe 3
            var recipe3 = new Recipe { Name = "Test Three", Description = "Test Description Three", Category = categorySnack};
            
            // Recipe 3 - Steps
            recipe3.Steps.Add(new Step { Description = "Step One", SortOrder = 1 });
            
            // Recipe 3 - Ingredients
            recipe3.Ingredients.Add(new Ingredient { Unit = 100, Measurement = measurementGrams, Product = productFlour, SortOrder = 1 });

            context.Recipes.Add(recipe3);
            
            // Recipe 4
            var recipe4 = new Recipe { Name = "Test Four", Description = "Test Description Four", Category = categoryLunch};
            context.Recipes.Add(recipe4);

            // Recipe 5
            var recipe5 = new Recipe { Name = "Test Five", Description = "Test Description Five", Category = categoryBreakfast};

            // Recipe 5 - Steps
            recipe5.Steps.Add(new Step { Description = "Step One", SortOrder = 1 });
            recipe5.Steps.Add(new Step { Description = "Step Two", SortOrder = 2 });

            context.Recipes.Add(recipe5);

            #endregion

            base.Seed(context);
        }
    }
}
