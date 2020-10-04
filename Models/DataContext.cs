using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Business> Businesses { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Guideline> Guidelines { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<InspectionGuideline> InspectionGuidelines { get; set; }
        public DbSet<InspectionType> InspectionTypes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Business>()
                .ToTable("Business");

            builder.Entity<County>()
                .ToTable("County");

            builder.Entity<EnforcementAgency>()
                .ToTable("EnforcementAgency");

            builder.Entity<Guideline>()
                .ToTable("Guidline");

            builder.Entity<Inspection>()
                .ToTable("Inspection");

            builder.Entity<InspectionGuideline>()
                .ToTable("InspectionGuideline");

            builder.Entity<InspectionType>()
                .ToTable("InspectionType");

            builder.Entity<Sector>()
                .ToTable("Sector"); 

            builder.Entity<Business>()
                .HasOne(b => b.County)
                .WithMany(c => c.Businesses)
                .HasForeignKey(b => b.CountyId);

            builder.Entity<Business>()
                .HasOne(b => b.Sector)
                .WithMany(s => s.Businesses)
                .HasForeignKey(b => b.SectorId);

            builder.Entity<Inspection>()
                .HasOne(i => i.Business)
                .WithMany(b => b.Inspections)
                .HasForeignKey(i => i.CertificateNumber)
                .HasPrincipalKey(b => b.BRCCode);

            builder.Entity<Inspection>()
                .HasOne(i => i.EnforcementAgency)
                .WithMany(e => e.Inspections)
                .HasForeignKey(i => i.AgencyId);

            builder.Entity<Inspection>()
                .HasOne(i => i.InspectionType)
                .WithMany(it => it.Inspections)
                .HasForeignKey(i => i.InspectionTypeId);

            builder.Entity<InspectionGuideline>()
                .HasOne(ig => ig.Inspection)
                .WithMany(i => i.InspectionGuidelines)
                .HasForeignKey(ig => ig.InspectionId);

            builder.Entity<InspectionGuideline>()
                .HasOne(ig => ig.Guideline)
                .WithMany(g => g.InspectionGuidelines)
                .HasForeignKey(ig => ig.GuidlineId);


        }

    }
}
