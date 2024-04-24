using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Type)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Date)
                .IsRequired();

            builder.Property(d => d.Status)
                .IsRequired();
        }
    }
}
