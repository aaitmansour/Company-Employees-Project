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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData
            (
                new Employee
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Name = "Hicham",
                    Age = 23,
                    position = "Software Enginere",
                    CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")

                },

                new Employee
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    Name = "Ahmed",
                    Age = 24,
                    position = "Software Developer",
                    CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")

                }
            );
        }
    }
}
