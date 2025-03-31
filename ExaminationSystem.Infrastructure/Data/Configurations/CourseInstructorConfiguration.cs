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
    public class CourseInstructorConfiguration : IEntityTypeConfiguration<CourseInstructor>
    {
        public void Configure(EntityTypeBuilder<CourseInstructor> builder)
        {
            builder.HasOne(ci => ci.Course).WithMany(c => c.CourseInstructors).HasForeignKey(c => c.CourseId);

            builder.HasOne(ci => ci.Instructor).WithMany(c => c.CourseInstructors).HasForeignKey(c => c.InstructorId);
        }
    }
}
