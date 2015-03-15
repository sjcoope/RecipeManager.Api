using SJCNet.RecipeManager.Data.Configuration;
using SJCNet.RecipeManager.Test.Samples;
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
        // TODO: What about disposing of this object after use?  is this controlled in DI framework (InstancePerRequest or something)?

        #region Constructors

        public RecipeManagerDbContext()
            : base(ConfigurationManager.ConnectionStrings["ReceipeDb"].ConnectionString)
        {
            // Set-up config.
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;

            // TODO - Remove when implementation settles down.
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

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Ingredient> Ingredients { get; set; }

        public virtual DbSet<Measurement> Measurements { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Recipe> Recipes { get; set; }

        public virtual DbSet<Step> Steps { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<User> Users { get; set; }

        #endregion
    }
}
