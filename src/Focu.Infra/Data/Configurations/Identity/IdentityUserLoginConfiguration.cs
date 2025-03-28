﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Focu.Infra.Data.Configurations.Identity;

public class IdentityUserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> builder) 
    {
        builder.ToTable("IdentityUserLogin");
        builder.HasKey(l => new { l.LoginProvider, l.ProviderKey });
        builder.Property(l => l.LoginProvider).HasMaxLength(128);
        builder.Property(l => l.ProviderKey).HasMaxLength(128);
        builder.Property(u => u.ProviderDisplayName).HasMaxLength(255);
    }
}