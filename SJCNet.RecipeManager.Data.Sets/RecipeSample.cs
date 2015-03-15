using SJCNet.RecipeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Test.Samples
{
    public class RecipeSample : Sample<Recipe>
    {
        public RecipeSample(SampleContext context) : base(context)
        {}

        protected override void InitializeData()
        {
            // Recipe 1
            var recipe1 = new Recipe { Name = "Test One", Description = "Test Description One", Category = (Category)base.Context.Categories.GetRandomEntity() };

            // Recipe 1 - Steps
            recipe1.Steps.Add(new Step { Description = "Step One", SortOrder = 1 });
            recipe1.Steps.Add(new Step { Description = "Step Two", SortOrder = 2 });
            recipe1.Steps.Add(new Step { Description = "Step Three", SortOrder = 3 });

            // Recipe 1 - Ingredients
            recipe1.Ingredients.Add(new Ingredient { Unit = 100, Measurement = (Measurement)base.Context.Measurements.GetRandomEntity(), Product = (Product)base.Context.Products.GetRandomEntity(), SortOrder = 1 });
            recipe1.Ingredients.Add(new Ingredient { Unit = 1, Measurement = (Measurement)base.Context.Measurements.GetRandomEntity(), Product = (Product)base.Context.Products.GetRandomEntity(), SortOrder = 2 });
            recipe1.Ingredients.Add(new Ingredient { Unit = 2, Measurement = (Measurement)base.Context.Measurements.GetRandomEntity(), Product = (Product)base.Context.Products.GetRandomEntity(), SortOrder = 3 });
            recipe1.Ingredients.Add(new Ingredient { Unit = 100, Measurement = (Measurement)base.Context.Measurements.GetRandomEntity(), Product = (Product)base.Context.Products.GetRandomEntity(), SortOrder = 4 });
            recipe1.Ingredients.Add(new Ingredient { Unit = 100, Measurement = (Measurement)base.Context.Measurements.GetRandomEntity(), Product = (Product)base.Context.Products.GetRandomEntity(), SortOrder = 5 });

            // Recipe 1 - Tags
            recipe1.Tags.Add(new Tag { Name = "Tag One" });
            recipe1.Tags.Add(new Tag { Name = "Tag Two" });

            base.Data.Add(recipe1);

            // Recipe 2
            var recipe2 = new Recipe { Name = "Test Two", Description = "Test Description Two", Category = (Category)base.Context.Categories.GetRandomEntity() };

            // Recipe 2 - Steps
            recipe2.Steps.Add(new Step { Description = "Step One", SortOrder = 1 });
            recipe2.Steps.Add(new Step { Description = "Step Two", SortOrder = 2 });
            recipe2.Steps.Add(new Step { Description = "Step Three", SortOrder = 3 });
            recipe2.Steps.Add(new Step { Description = "Step Four", SortOrder = 4 });
            recipe2.Steps.Add(new Step { Description = "Step Five", SortOrder = 5 });

            // Recipe 2 - Ingredients
            recipe2.Ingredients.Add(new Ingredient { Unit = 100, Measurement = (Measurement)base.Context.Measurements.GetRandomEntity(), Product = (Product)base.Context.Products.GetRandomEntity(), SortOrder = 1 });
            recipe2.Ingredients.Add(new Ingredient { Unit = 1, Measurement = (Measurement)base.Context.Measurements.GetRandomEntity(), Product = (Product)base.Context.Products.GetRandomEntity(), SortOrder = 2 });

            // Recipe 2 - Tags
            recipe2.Tags.Add(new Tag { Name = "Tag One" });
            recipe2.Tags.Add(new Tag { Name = "Tag Two" });
            recipe2.Tags.Add(new Tag { Name = "Tag Three" });
            recipe2.Tags.Add(new Tag { Name = "Tag Four" });
            recipe2.Tags.Add(new Tag { Name = "Tag Five" });

            base.Data.Add(recipe2);

            // Recipe 3
            var recipe3 = new Recipe { Name = "Test Three", Description = "Test Description Three", Category = (Category)base.Context.Categories.GetRandomEntity() };

            // Recipe 3 - Steps
            recipe3.Steps.Add(new Step { Description = "Step One", SortOrder = 1 });

            // Recipe 3 - Ingredients
            recipe3.Ingredients.Add(new Ingredient { Unit = 100, Measurement = (Measurement)base.Context.Measurements.GetRandomEntity(), Product = (Product)base.Context.Products.GetRandomEntity(), SortOrder = 1 });

            // Recipe 3 - Tags
            recipe3.Tags.Add(new Tag { Name = "Tag One" });
            recipe3.Tags.Add(new Tag { Name = "Tag Two" });
            recipe3.Tags.Add(new Tag { Name = "Tag Three" });

            base.Data.Add(recipe3);

            // Recipe 4
            var recipe4 = new Recipe { Name = "Test Four", Description = "Test Description Four", Category = (Category)base.Context.Categories.GetRandomEntity() };
            base.Data.Add(recipe4);

            // Recipe 5
            var recipe5 = new Recipe { Name = "Test Five", Description = "Test Description Five", Category = (Category)base.Context.Categories.GetRandomEntity() };

            // Recipe 5 - Steps
            recipe5.Steps.Add(new Step { Description = "Step One", SortOrder = 1 });
            recipe5.Steps.Add(new Step { Description = "Step Two", SortOrder = 2 });

            base.Data.Add(recipe5);
        }
    }
}
