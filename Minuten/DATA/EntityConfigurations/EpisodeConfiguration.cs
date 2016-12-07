using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity.ModelConfiguration;
using Minuten.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Minuten.EntityConfigurations
{
    public class EpisodeConfiguration : EntityTypeConfiguration<Episode>
    {
        public EpisodeConfiguration()
        {
            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(e => e.Title)
                .HasMaxLength(255);

            Property(e => e.Date)
                .IsRequired();

            Property(e => e.OriginalDate)
                .IsOptional();

            Property(e => e.MyComment)
                .HasMaxLength(2000);


            HasMany(e => e.PanelMembers)
                .WithMany(p => p.Episodes)
                .Map(m =>
                {
                    m.ToTable("EpisodePanelMembers");
                    m.MapLeftKey("EpisodeId");
                    m.MapRightKey("PanelMemberId");
                });

        }
    }
}