using SJCNet.RecipeManager.Test.Samples;
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
            // Add the sample data
            var sampleData = new SampleContext();
            context.Categories.AddRange(sampleData.Categories.Entities);
            context.Measurements.AddRange(sampleData.Measurements.Entities);
            context.Products.AddRange(sampleData.Products.Entities);
            context.Recipes.AddRange(sampleData.Recipes.Entities);

            base.Seed(context);
        }
    }
}
