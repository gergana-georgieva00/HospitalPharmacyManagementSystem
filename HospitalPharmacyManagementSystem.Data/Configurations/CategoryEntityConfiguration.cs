﻿using HospitalPharmacyManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPharmacyManagementSystem.Data.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private Category[] GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category;
            category = new Category()
            {
                Id = 1,
                Name = "Over-the-counter"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Prescription"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Complementary medicine"
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}
