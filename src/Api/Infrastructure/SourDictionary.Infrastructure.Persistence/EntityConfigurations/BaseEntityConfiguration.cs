namespace SourDictionary.Infrastructure.Persistence.EntityConfigurations
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable(typeof(TEntity).Name.ToLowerInvariant(), SourDictionaryContext.DEFAULT_SCHEMA);

            //ValueGeneratedOnAdd() : SaveChange çağrılmadan id set edilsin.
            builder.Property(p => p.Id).ValueGeneratedOnAdd(); 
            builder.Property(p => p.CreateDate).ValueGeneratedOnAdd();
        }
    }
}
