namespace SourDictionary.Infrastructure.Persistence.EntityConfigurations.Entries
{
    public class EntryVoteEntityConfiguration : BaseEntityConfiguration<EntryVote>
    {
        public override void Configure(EntityTypeBuilder<EntryVote> builder)
        {
            base.Configure(builder);

            builder.HasOne(p => p.Entry).WithMany(p => p.EntryVotes).HasForeignKey(p => p.EntryId);
        }
    }
}