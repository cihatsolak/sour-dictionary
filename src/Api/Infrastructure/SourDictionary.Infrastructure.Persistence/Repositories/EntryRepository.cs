namespace SourDictionary.Infrastructure.Persistence.Repositories
{
    public class EntryRepository : GenericRepository<Entry>, IEntryRepository
    {
        public EntryRepository(SourDictionaryContext context) : base(context)
        {
        }
    }
}
