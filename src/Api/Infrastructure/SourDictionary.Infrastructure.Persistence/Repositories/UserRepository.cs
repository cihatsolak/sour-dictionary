namespace SourDictionary.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SourDictionaryContext context) : base(context)
        {
        }
    }
}
