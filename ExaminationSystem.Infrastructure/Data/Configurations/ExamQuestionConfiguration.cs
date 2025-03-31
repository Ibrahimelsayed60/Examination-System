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
    public class ExamQuestionConfiguration : IEntityTypeConfiguration<ExamQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamQuestion> builder)
        {
            builder.HasOne(eq => eq.Question).WithMany(q => q.ExamQuestions).HasForeignKey(eq => eq.QuestionId);

            builder.HasOne(eq => eq.Exam).WithMany(q => q.ExamQuestions).HasForeignKey(eq => eq.ExamId);
        }
    }
}
