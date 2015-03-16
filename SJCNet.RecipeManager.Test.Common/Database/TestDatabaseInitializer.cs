using SJCNet.RecipeManager.Common.Utility;
using SJCNet.RecipeManager.Data;
using SJCNet.RecipeManager.Test.Samples;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Test.Common.Database
{
    public class TestDatabaseInitializer : DropCreateDatabaseIfModelChanges<RecipeManagerDbContext>
    {

        public override void InitializeDatabase(RecipeManagerDbContext context)
        {
            // Stop anyone using the Db while initialization is running.
            context.Database.ExecuteSqlCommand(
                TransactionalBehavior.DoNotEnsureTransaction, 
                string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            // Remove any data and reset Ids
            context.Database.ExecuteSqlCommand(
                TransactionalBehavior.DoNotEnsureTransaction,
                File.ReadAllText(@"Artifacts\Database\ResetDatabase.sql"));

            base.InitializeDatabase(context);
            
            // Force reseeding - Reseeding done here as Seed method only called if DB model changes.
            var sampleData = new SampleContext();
            context.Categories.AddRange(sampleData.Categories.Entities);
            context.Measurements.AddRange(sampleData.Measurements.Entities);
            context.Products.AddRange(sampleData.Products.Entities);
            context.Recipes.AddRange(sampleData.Recipes.Entities);
            context.SaveChanges();

            base.Seed(context);

            // Enable use of the database again.
            context.Database.ExecuteSqlCommand(
                TransactionalBehavior.DoNotEnsureTransaction,
                String.Format("ALTER DATABASE {0} SET MULTI_USER", context.Database.Connection.Database));
        }
    }
}
