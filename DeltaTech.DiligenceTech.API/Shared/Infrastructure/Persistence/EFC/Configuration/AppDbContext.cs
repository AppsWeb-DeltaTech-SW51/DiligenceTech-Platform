using DeltaTech.DiligenceTech.API.Communication.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Communication.Domain.Model.Entities;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.DueDiligenceFileManagement.Domain.Model.Entities;
using DeltaTech.DiligenceTech.API.DueDiligenceProjectManagement.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Profiles.Domain.Model.Aggregates;
using DeltaTech.DiligenceTech.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DeltaTech.DiligenceTech.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Due Diligence Project Management Context

        builder.Entity<Project>().HasKey(p => p.Id);
        builder.Entity<Project>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Project>().Property(p => p.Code).IsRequired().HasMaxLength(6);
        builder.Entity<Project>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Project>().Property(p => p.Confirmed).IsRequired();
        
        // Due Diligence File Management Context

        builder.Entity<Folder>().HasKey(f => f.Id);
        builder.Entity<Folder>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Folder>().Property(f => f.Name).IsRequired().HasMaxLength(800);
        builder.Entity<Folder>().Property(f => f.BuyStatus).IsRequired();
        builder.Entity<Folder>().Property(f => f.SellStatus).IsRequired();
        builder.Entity<Folder>().Property(f => f.Obligatory).IsRequired();
        builder.Entity<Folder>().Property(f => f.Priority).IsRequired();
        builder.Entity<Folder>().HasMany(f1 => f1.Children)
            .WithOne(f2 => f2.Parent)
            .HasForeignKey(f2 => f2.ParentId)
            .HasPrincipalKey(f1 => f1.Id);
        
        builder.Entity<Folder>().HasMany(f => f.Documents)
            .WithOne(d => d.Folder)
            .HasForeignKey(d => d.FolderId)
            .HasPrincipalKey(f => f.Id);

        builder.Entity<Document>().HasKey(d => d.Id);
        builder.Entity<Document>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Document>().OwnsOne(d => d.FileInfo,
            f =>
            {
                f.WithOwner().HasForeignKey("Id");
                f.Property(d => d.FileName).HasColumnName("FileName");
                f.Property(d => d.FileUrl).HasColumnName("FileUrl");
            });
        
        // Profiles Context
        builder.Entity<Agent>().HasKey(a => a.Id);
        builder.Entity<Agent>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Agent>().Property(a => a.Code).IsRequired();
        builder.Entity<Agent>().Property(a => a.Email).IsRequired();
        builder.Entity<Agent>().Property(a => a.Username).IsRequired();
        builder.Entity<Agent>().Property(a => a.Password).IsRequired();
        builder.Entity<Agent>().Property(a => a.Image);
        
        // Communication Context
        builder.Entity<QA>().HasKey(q => q.Id);
        builder.Entity<QA>().Property(q => q.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<QA>().Property(q => q.Content).IsRequired();
        builder.Entity<QA>().HasMany(q1 => q1.Answers)
            .WithOne(q2 => q2.Question)
            .HasForeignKey(q2 => q2.QuestionId)
            .HasPrincipalKey(q1 => q1.Id);

        builder.Entity<Notification>().HasKey(n => n.Id);
        builder.Entity<Notification>().Property(n => n.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Notification>().Property(n => n.Type);
        builder.Entity<Notification>().Property(n => n.Content);
        
        // Applying Snake Case Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}