using Microsoft.EntityFrameworkCore;
using OzSozluk.Api.Domain.Models;
using System.Reflection;

namespace OzSozluk.Infrastructure.Persistence.Context;

public class OzSozlukContext : DbContext
{
    public const string DEFAULT_SCHEMA = "dbo";

    public OzSozlukContext()
    {
    }
    public OzSozlukContext(DbContextOptions options) : base(options)
    {
    }

    #region DbSets
    public DbSet<User> Users { get; set; }
    public DbSet<Entry> Entries { get; set; }

    public DbSet<EntryVote> EntryVotes { get; set; }
    public DbSet<EntryFavorite> EntryFavorites { get; set; }

    public DbSet<EntryComment> EntryComments { get; set; }
    public DbSet<EntryCommentVote> EntryCommentVotes { get; set; }
    public DbSet<EntryCommentFavorite> EntryCommentFavorites { get; set; }

    public DbSet<EmailConfirmation> EmailConfirmations { get; set; }

    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //parametresiz constructor calistirilinca set etmek icin bu methodu kullandik
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Database=ozsozluk; Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        }
    }

    #region AddInitialDateForInserts
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override int SaveChanges()
    {
        OnBeforeSave();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSave();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void OnBeforeSave()
    {
        var addedEntries = ChangeTracker.Entries()
                                .Where(i => i.State == EntityState.Added)
                                .Select(i => (BaseEntity)i.Entity);

        PrepareAddedEntities(addedEntries);
    }

    private void PrepareAddedEntities(IEnumerable<BaseEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.CreateDate == DateTime.MinValue)
            {
                entity.CreateDate = DateTime.Now;
            }
        }
    }
    #endregion
}
