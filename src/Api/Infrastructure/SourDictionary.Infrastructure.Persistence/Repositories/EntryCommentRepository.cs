namespace SourDictionary.Infrastructure.Persistence.Repositories
{
    public class EntryCommentRepository : GenericRepository<EntryComment>, IEntryCommentRepository
    {
        public EntryCommentRepository(SourDictionaryContext context) : base(context)
        {
        }
    }
}
