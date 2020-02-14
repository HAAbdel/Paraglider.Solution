﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class PilotConfiguration : IEntityTypeConfiguration<Pilot>
    {
        public void Configure(EntityTypeBuilder<Pilot> builder)
        {
            builder.HasOne(s => s.Role).WithOne(d => d.Pilot).OnDelete(DeleteBehavior.Restrict);
        }
    }
}