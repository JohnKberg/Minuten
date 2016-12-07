using Microsoft.AspNet.Identity.EntityFramework;
using Minuten.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;



namespace Minuten
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Episode> Episodes { get; set; }
        public DbSet<PanelMember> PanelMembers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EntityConfigurations.EpisodeConfiguration());
            modelBuilder.Configurations.Add(new EntityConfigurations.PanelMemberConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}