using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity.ModelConfiguration;
using Minuten.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Minuten.EntityConfigurations
{
    public class PanelMemberConfiguration : EntityTypeConfiguration<PanelMember>
    {
        public PanelMemberConfiguration()
        {
            Property(e => e.Name)
                .HasMaxLength(255);

        }
    }
}