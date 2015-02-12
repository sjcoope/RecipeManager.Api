using SJCNet.RecipeManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Data.Configuration
{
    public class IngredientConfiguration : EntityTypeConfiguration<Ingredient>
    {
        public IngredientConfiguration()
        {
            HasKey(i => i.Id);
            
            Property(i => i.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Ingredient has ONE Measurement, Measurement has ONE OR MANY Ingredients
            HasRequired(i => i.Measurement)
                .WithMany()
                .Map(i => i.MapKey("MeasurementId"));

            // Ingredient has ONE Product, Product has ONE OR MANY Ingredients
            HasRequired(i => i.Product)
                .WithMany()
                .Map(i => i.MapKey("ProductId"));
        }
    }
}
