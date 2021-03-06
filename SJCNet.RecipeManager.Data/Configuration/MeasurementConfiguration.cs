﻿using SJCNet.RecipeManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Data.Configuration
{
    public class MeasurementConfiguration : EntityTypeConfiguration<Measurement>
    {
        public MeasurementConfiguration()
        {
            HasKey(i => i.Id);
            
            Property(i => i.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
