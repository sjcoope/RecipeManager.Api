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
    public class RecipeConfiguration : EntityTypeConfiguration<Recipe>
    {
        public RecipeConfiguration()
        {
            HasKey(i => i.Id);
            
            Property(i => i.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Recipe has NONE OR ONE category, Category has MANY Recipes
            HasOptional(i => i.Category)
                .WithMany()
                .Map(i => i.MapKey("CategoryId"));

            // Recipe has NONE OR MANY Steps, a Step has ONE Recipe
            HasMany(i => i.Steps)
                .WithRequired()
                .Map(i => i.MapKey("RecipeId"));

            // Recipe has NONE OR MANY Ingredients, Ingredient has ONE Recipe
            HasMany(i => i.Ingredients)
                .WithRequired()
                .Map(i => i.MapKey("RecipeId"));

            // Recipe has NONE OR MANY Tags, Tag has ONE Recipe
            HasMany(i => i.Tags)
                .WithRequired()
                .Map(i => i.MapKey("RecipeId"));
        }
    }
}
