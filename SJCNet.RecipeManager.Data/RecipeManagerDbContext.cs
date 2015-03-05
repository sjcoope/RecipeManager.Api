using SJCNet.RecipeManager.Data.Configuration;
using SJCNet.RecipeManager.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Data
{
    public class RecipeManagerDbContext : DbContext
    {
        #region Constructors

        public RecipeManagerDbContext()
            : base(ConfigurationManager.ConnectionStrings["ReceipeDb"].ConnectionString)
        {
            // Set-up config.
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;

            // Recreate the database and initialize the data.
            Database.SetInitializer<RecipeManagerDbContext>(new RecipeManagerDbInitializer());
        }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configure entity configuration
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new IngredientConfiguration());
            modelBuilder.Configurations.Add(new MeasurementConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new RecipeConfiguration());
            modelBuilder.Configurations.Add(new StepConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region Properties

        public DbSet<Category> Categories{ get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Measurement> Measurements { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Step> Steps{ get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }

        #endregion
    }
}
