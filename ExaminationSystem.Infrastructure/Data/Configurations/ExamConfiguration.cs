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
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);

            builder.Property(e => e.Description).IsRequired().HasMaxLength(300);

            builder.HasOne(e => e.Instructor).WithMany(i => i.Exams).HasForeignKey(e => e.InstructorId);

            builder.HasOne(e => e.Course).WithMany(c => c.Exams).HasForeignKey(c => c.CourseId);
        }
    }
}
