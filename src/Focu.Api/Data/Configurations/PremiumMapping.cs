using Focu.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Focu.Api.Data.Configurations;

public class PremiumMapping : IEntityTypeConfiguration<Premium>
{
    public void Configure(EntityTypeBuilder<Premium> builder)
    {
        builder.ToTable("Premium");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.StartedAt)
            .IsRequired(true)
            .HasColumnType("DATETIME2");

        builder.Property(x => x.EndedAt)
            .IsRequired(true)
            .HasColumnType("DATETIME2");

        builder.Property(x => x.UserId)
            .IsRequired(true)
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);

        builder.HasOne(x => x.Order).WithMany();
    }
}