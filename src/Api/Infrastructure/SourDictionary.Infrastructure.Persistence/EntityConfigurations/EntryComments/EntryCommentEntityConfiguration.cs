namespace SourDictionary.Infrastructure.Persistence.EntityConfigurations.Entries
{
    public class EntryCommentEntityConfiguration : BaseEntityConfiguration<EntryComment>
    {
        public override void Configure(EntityTypeBuilder<EntryComment> builder)
        {
            base.Configure(builder);

            builder.HasOne(p => p.CreatedBy).WithMany(p => p.EntryComments).HasForeignKey(p => p.CreatedById);
            builder.HasOne(p => p.Entry).WithMany(p => p.EntryComments).HasForeignKey(p => p.EntryId);
        }
    }
}