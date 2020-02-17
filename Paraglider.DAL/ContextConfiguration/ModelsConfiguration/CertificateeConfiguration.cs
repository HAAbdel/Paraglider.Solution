﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class CertificateeConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> entity)
        {
            entity.HasMany(sc => sc.PilotCertificates)
                .WithOne(s => s.Certificate)
                .HasForeignKey(k => k.CertificateId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasMany(sc => sc.Traineeships)
                .WithOne(s => s.Certificate)
                .HasForeignKey(k => k.CertificateId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
