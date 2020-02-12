using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class ParaglinderConfig : IEntityTypeConfiguration<Paraglinder>
    {
        public void Configure(EntityTypeBuilder<Paraglinder> builder)
        {

        }
    }
}
