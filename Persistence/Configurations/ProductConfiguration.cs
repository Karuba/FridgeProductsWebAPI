using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Banana",
                    DefaultQuantity = 12
                },
                new Product
                {
                    Id = new Guid("d9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Strawberry",
                    DefaultQuantity = 20
                },
                new Product
                {
                    Id = new Guid("e9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Milk",
                    DefaultQuantity = null
                }
            );
        }
    }
}
