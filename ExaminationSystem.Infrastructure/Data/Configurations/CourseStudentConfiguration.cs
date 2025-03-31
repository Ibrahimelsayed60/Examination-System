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
    public class CourseStudentConfiguration : IEntityTypeConfiguration<CourseStudent>
    {
        public void Configure(EntityTypeBuilder<CourseStudent> builder)
        {
            builder.HasOne(cs => cs.Course).WithMany(c => c.CourseStudents).HasForeignKey(c => c.CourseId);

            builder.HasOne(cs => cs.Student).WithMany(s => s.CourseStudents).HasForeignKey(c => c.StudentId);
        }
    }
}
