using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Configurations
{
    public class FridgeProductConfiguration : IEntityTypeConfiguration<FridgeProduct>
    {
        public void Configure(EntityTypeBuilder<FridgeProduct> builder)
        {
            builder.HasData(
                new FridgeProduct
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    FridgeId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    ProductId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Quantity = 12
                },
                new FridgeProduct
                {
                    Id = new Guid("96dba8c0-d178-41e7-938c-ed49778fb52a"),
                    FridgeId = new Guid("90abbca8-664d-4b20-b5de-024705497d4a"),
                    ProductId = new Guid("d9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Quantity = 0
                },
                new FridgeProduct
                {
                    Id = new Guid("97dba8c0-d178-41e7-938c-ed49778fb52a"),
                    FridgeId = new Guid("90abbca8-664d-4b20-b5de-024705497d4a"),
                    ProductId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Quantity = 1
                });
        }
    }
}
