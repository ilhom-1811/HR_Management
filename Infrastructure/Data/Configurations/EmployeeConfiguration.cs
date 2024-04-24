using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Address)
                .HasMaxLength(200);

            builder.Property(e => e.ContactInfo)
                .HasMaxLength(100);

            builder.Property(e => e.HireDate)
                .IsRequired();

            builder.HasOne(e => e.Position)
                .WithMany()
                .HasForeignKey(e => e.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Documents)
                .WithOne(d => d.Employee)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Status)
                .IsRequired();
        }
    }
}