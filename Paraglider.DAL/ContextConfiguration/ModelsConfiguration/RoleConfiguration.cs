﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasOne(sc => sc.Pilot).WithOne(s => s.Role).OnDelete(DeleteBehavior.Restrict);
        }
    }
}