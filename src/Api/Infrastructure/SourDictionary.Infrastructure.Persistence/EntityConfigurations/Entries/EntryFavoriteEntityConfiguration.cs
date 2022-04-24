namespace SourDictionary.Infrastructure.Persistence.EntityConfigurations.Entries
{
    public class EntryFavoriteEntityConfiguration : BaseEntityConfiguration<EntryFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryFavorite> builder)
        {
            base.Configure(builder);

            builder.HasOne(p => p.Entry).WithMany(p => p.EntryFavorites).HasForeignKey(p => p.EntryId);
            builder.HasOne(p => p.CreatedUser).WithMany(p => p.EntryFavorites).HasForeignKey(p => p.CreatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}