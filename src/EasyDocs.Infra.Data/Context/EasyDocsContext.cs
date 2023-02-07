using EasyDocs.Domain.Core.Messaging;
using EasyDocs.Domain.Entities;
using EasyDocs.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EasyDocs.Infra.Data.Context;

public class EasyDocsContext : DbContext
{
    public EasyDocsContext(DbContextOptions<EasyDocsContext> options) 
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<ValidationResult>();
        modelBuilder.Ignore<Event>();

        modelBuilder.ConfigureMappings();
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Licensee> Licensees { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<UserType> UserTypes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<UserDocument> UserDocuments { get; set; }
}