using Entities.Modeles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData
            (
                new Company
                {
                    id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    name = "Concepment",
                    adresse = "rabat",
                    country = "Maroc"

                },
                new Company
                {
                    id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    name = "SQLI",
                    adresse = "Rabat",
                    country = "Maroc"
                }

            );
        }
    }
}
