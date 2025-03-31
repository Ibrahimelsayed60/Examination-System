using ExaminationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Infrastructure.Data.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property(i => i.FName).IsRequired().HasMaxLength(50);

            builder.Property(i => i.LName).IsRequired().HasMaxLength(50);

            builder.Property(i => i.Email).IsRequired().HasMaxLength(100);

            builder.HasOne(i => i.Department).WithMany(d => d.Instructors).HasForeignKey(i => i.DepartmentId);
        }
    }
}
