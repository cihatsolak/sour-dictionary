namespace SourDictionary.Infrastructure.Persistence.EntityConfigurations.Entries
{
    public class EntryEntityConfiguration : BaseEntityConfiguration<Entry>
    {
        public override void Configure(EntityTypeBuilder<Entry> builder)
        {
            base.Configure(builder);

            builder.HasOne(p => p.CreatedBy).WithMany(p => p.Entries).HasForeignKey(p => p.CreatedById);
        }
    }
}