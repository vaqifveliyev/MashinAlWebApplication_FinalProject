﻿using MashinAl.Infastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MashinAl.Data.Persistences.Configurations
{
    public class ModelEntityConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.Property(m => m.Id).UseIdentityColumn(1, 1);
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(m => m.MarkaId).IsRequired().HasColumnName("MarkaId").HasMaxLength(200);

            builder.HasOne<Marka>()
                .WithMany()
                .HasForeignKey(m => m.MarkaId)
                .HasPrincipalKey(m => m.Id);

            builder.HasKey(m => m.Id);
            builder.ToTable("Models");
        }
    }
}
