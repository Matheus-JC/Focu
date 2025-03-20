using Focu.Core.CategoryDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Focu.Infra.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Title)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        builder.Property(c => c.Description)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);
        
        builder.Property(c => c.UserId)
            .IsRequired()
            .HasColumnType("UNIQUEIDENTIFIER")
            .HasMaxLength(160);
    }
}