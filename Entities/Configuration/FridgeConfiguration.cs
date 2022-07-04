using FridgeProductsWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class FridgeConfiguration : IEntityTypeConfiguration<Fridge>
    {
        public void Configure(EntityTypeBuilder<Fridge> builder)
        {
            builder.HasData(
                new Fridge
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    FridgeModelId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Atlant",
                    OwnerName = "Kirill"
                },
                new Fridge
                {
                    Id = new Guid("90abbca8-664d-4b20-b5de-024705497d4a"),
                    FridgeModelId = new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Cool",
                    OwnerName = "Michael"
                },
                new Fridge
                {
                    Id = new Guid("91abbca8-664d-4b20-b5de-024705497d4a"),
                    FridgeModelId = new Guid("5d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Frigidaire",
                    OwnerName = "Arthur"
                });
        }
    }
}
