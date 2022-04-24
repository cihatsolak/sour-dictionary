namespace SourDictionary.Infrastructure.Persistence.EntityConfigurations.Entries
{
    public class EntryCommentVoteEntityConfiguration : BaseEntityConfiguration<EntryCommentVote>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentVote> builder)
        {
            base.Configure(builder);

            builder.HasOne(p => p.EntryComment).WithMany(p => p.EntryCommentVotes).HasForeignKey(p => p.EntryCommentId);
        }
    }
}