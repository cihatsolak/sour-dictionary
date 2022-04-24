namespace SourDictionary.Infrastructure.Persistence.Context
{
    internal class SeedData
    {
        private static List<User> GetFakeUsers()
        {
            var fakeUsers = new Faker<User>("tr")
                .RuleFor(p => p.Id, p => Guid.NewGuid())
                .RuleFor(p => p.CreateDate, p => p.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                .RuleFor(p => p.FirstName, p => p.Person.FirstName)
                .RuleFor(p => p.LastName, p => p.Person.LastName)
                .RuleFor(p => p.EmailAddress, p => p.Internet.Email())
                .RuleFor(p => p.UserName, p => p.Internet.UserName())
                .RuleFor(p => p.Password, p => PasswordEncryptor.Encrpt(p.Internet.Password()))
                .RuleFor(p => p.EmailConfirmed, p => p.PickRandom(true, false))
                .Generate(500);

            return fakeUsers;
        }

        public async Task SeedAsync(IConfiguration configuration)
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(configuration.GetConnectionString("SourDictionaryDbConnectionString"));

            SourDictionaryContext sourDictionaryContext = new(dbContextOptionsBuilder.Options);

            if (await sourDictionaryContext.Users.AnyAsync())
            {
                await Task.CompletedTask;
                return;
            }

            var fakeUsers = GetFakeUsers();
            var fakeUserIds = fakeUsers.Select(p => p.Id);
            await sourDictionaryContext.Users.AddRangeAsync(fakeUsers);

            int counter = 0;
            var fakeEntryIds = Enumerable.Range(0, 150).Select(p => Guid.NewGuid()).ToList();

            var entries = new Faker<Entry>("tr")
                .RuleFor(p => p.Id, p => fakeEntryIds[counter++])
                .RuleFor(p => p.CreateDate, p => p.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                .RuleFor(p => p.Subject, p => p.Lorem.Sentence(5, 5))
                .RuleFor(p => p.Content, p => p.Lorem.Paragraph(2))
                .RuleFor(p => p.CreatedById, p => p.PickRandom(fakeUserIds))
                .Generate(150);

            await sourDictionaryContext.Entries.AddRangeAsync(entries);

            var entryComments = new Faker<EntryComment>("tr")
                .RuleFor(p => p.Id, p => Guid.NewGuid())
                .RuleFor(p => p.CreateDate, p => p.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                .RuleFor(p => p.Content, p => p.Lorem.Paragraph(2))
                .RuleFor(p => p.CreatedById, p => p.PickRandom(fakeUserIds))
                .RuleFor(p => p.EntryId, p => p.PickRandom(fakeEntryIds))
                .Generate(1000);

            await sourDictionaryContext.EntryComments.AddRangeAsync(entryComments);

            await sourDictionaryContext.SaveChangesAsync();
        }
    }
}
