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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.FName).IsRequired().HasMaxLength(50);

            builder.Property(s => s.LName).IsRequired().HasMaxLength(50);

            builder.Property(s => s.Email).IsRequired().HasMaxLength(100);

            builder.HasOne(s => s.Major).WithMany(d => d.Students).HasForeignKey(s => s.MajorId);
        }
    }
}
