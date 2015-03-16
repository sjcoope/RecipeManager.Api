using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Data.Configuration
{
    public class RecipeManagerDbContextConfiguration : DbConfiguration
    {
        public RecipeManagerDbContextConfiguration()
        {
            // TODO - Remove when implementation settles down.
            // Recreate the database and initialize the data.
            this.SetDatabaseInitializer<RecipeManagerDbContext>(new RecipeManagerDbInitializer());

            // Required for build to copy EntityFramework.SqlServer dll.
            this.SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
}
