using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Configurations
{
    public class FridgeModelConfiguration : IEntityTypeConfiguration<FridgeModel>
    {
        public void Configure(EntityTypeBuilder<FridgeModel> builder)
        {
            builder.HasData(
                new FridgeModel
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Model1",
                    Year = 1990
                },
                new FridgeModel
                {
                    Id = new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Model2",
                    Year = 1994
                },
                new FridgeModel
                {
                    Id = new Guid("5d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Model3",
                    Year = null
                });
        }
    }
}
