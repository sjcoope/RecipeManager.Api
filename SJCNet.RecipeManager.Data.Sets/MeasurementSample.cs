using SJCNet.RecipeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Test.Samples
{
    public class MeasurementSample : Sample<Measurement>
    {
        public MeasurementSample(SampleContext context) : base(context)
        {}

        protected override void InitializeData()
        {
            var measurementGrams = new Measurement { Name = "Grams" };
            base.Data.Add(measurementGrams);

            var measurementCups = new Measurement { Name = "Cups" };
            base.Data.Add(measurementCups);

            var measurementUnit = new Measurement { Name = "Unit" };
            base.Data.Add(measurementUnit);
        }
    }
}
