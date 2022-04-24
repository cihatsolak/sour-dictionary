namespace SourDictionary.Infrastructure.Persistence.Context
{
    public class SourDictionaryContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "dbo";

        public SourDictionaryContext()
        {

        }

        public SourDictionaryContext(DbContextOptions<SourDictionaryContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID=admin;Password=Password123;Server=localhost;Port=5432;Database=sourdictionary;Integrated Security=true;Pooling=true", opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Çalıştırılan library üzerinde IEntityTypeConfiguration'dan türemiş olan class'ları otomatik ekle.
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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSave()
        {
            var addedEntities = ChangeTracker.Entries()
                .Where(entity => entity.State.Equals(EntityState.Added))
                .Select(p => (BaseEntity)p.Entity);

            PrepareAddedEntities(addedEntities);
        }

        private static void PrepareAddedEntities(IEnumerable<BaseEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.CreateDate.Equals(DateTime.MinValue))
                    entity.CreateDate = DateTime.Now;
            }
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryVote> EntryVotes { get; set; }
        public DbSet<EntryFavorite> EntryFavorites { get; set; }

        public DbSet<EntryComment> EntryComments { get; set; }
        public DbSet<EntryCommentVote> EntryCommentVotes { get; set; }
        public DbSet<EntryCommentFavorite> EntryCommentFavorites { get; set; }

        public DbSet<EmailConfirmation> EmailConfirmations { get; set; }
    }
}
