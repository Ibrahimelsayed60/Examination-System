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
    public class ExamStudentConfiguration : IEntityTypeConfiguration<ExamStudent>
    {
        public void Configure(EntityTypeBuilder<ExamStudent> builder)
        {
            builder.HasOne(es => es.Student).WithMany(s => s.ExamStudents).HasForeignKey(s => s.StudentId);

            builder.HasOne(es => es.Exam).WithMany(e => e.ExamStudents).HasForeignKey(es => es.ExamId);
        }
    }
}
