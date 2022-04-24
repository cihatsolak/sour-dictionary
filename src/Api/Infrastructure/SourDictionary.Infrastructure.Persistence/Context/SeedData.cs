namespace SourDictionary.Infrastructure.Persistence.Context
{
    internal class SeedData
    {
        private static List<User> GetUsers()
        {
            var fakeUsers = new Faker<User>("tr")
                .RuleFor(p => p.Id, p => Guid.NewGuid())
                .RuleFor(p => p.CreateDate, p => p.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                .RuleFor(p => p.FirstName, p => p.Person.FirstName)
                .RuleFor(p => p.LastName, p => p.Person.LastName)
                .RuleFor(p => p.EmailAddress, p => p.Internet.Email())
                .RuleFor(p => p.UserName, p => p.Internet.UserName())
                .RuleFor(p => p.Password, p => p.Internet.Password())
                .RuleFor(p => p.EmailConfirmed, p => p.PickRandom(true, false))
                .Generate(500);

            return fakeUsers;
        }
    }
}
