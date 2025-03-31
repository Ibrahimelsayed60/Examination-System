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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.Property(c => c.Code).IsRequired().HasMaxLength(50);

            builder.Property(c=> c.Description).IsRequired().HasMaxLength(500);

            builder.Property(c => c.CreditHours).IsRequired();

            builder.HasOne( c => c.Department).WithMany(d => d.Courses).HasForeignKey(c => c.DepartmentId);
        }
    }
}
