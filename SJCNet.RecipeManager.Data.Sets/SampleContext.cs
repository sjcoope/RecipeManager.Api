using SJCNet.RecipeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Test.Samples
{
    public class SampleContext
    {
        public SampleContext()
        {
            this.Categories = new CategorySample(this);
            this.Measurements = new MeasurementSample(this);
            this.Products = new ProductSample(this);
            this.Recipes = new RecipeSample(this);
        }

        public CategorySample Categories { get; private set; }

        public Sample<Measurement> Measurements { get; private set; }

        public Sample<Product> Products { get; private set; }

        public Sample<Recipe> Recipes { get; private set; }
    }
}
