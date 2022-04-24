namespace SourDictionary.Infrastructure.Persistence.EntityConfigurations.Entries
{
    public class EntryCommentFavoriteEntityConfiguration : BaseEntityConfiguration<EntryCommentFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentFavorite> builder)
        {
            base.Configure(builder);

            builder.HasOne(p => p.EntryComment).WithMany(p => p.EntryCommentFavorites).HasForeignKey(p => p.EntryCommentId);
            builder.HasOne(p => p.CreatedUser).WithMany(p => p.EntryCommentFavorites).HasForeignKey(p => p.CreatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}