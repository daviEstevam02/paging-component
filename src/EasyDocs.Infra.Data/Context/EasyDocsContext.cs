using Microsoft.EntityFrameworkCore;

namespace EasyDocs.Infra.Data.Context;

public class EasyDocsContext : DbContext
{
    public EasyDocsContext(DbContextOptions options) 
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}