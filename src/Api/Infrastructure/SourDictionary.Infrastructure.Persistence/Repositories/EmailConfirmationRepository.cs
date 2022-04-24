namespace SourDictionary.Infrastructure.Persistence.Repositories
{
    public class EmailConfirmationRepository : GenericRepository<EmailConfirmation>, IEmailConfirmationRepository
    {
        public EmailConfirmationRepository(SourDictionaryContext context) : base(context)
        {
        }
    }
}
