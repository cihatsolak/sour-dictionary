namespace SourDictionary.Projections.UserService.Services
{
    public class UserService
    {
        private readonly string _connectionString;

        public UserService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Guid> CreateEmailConfirmationAsync(UserEmailChangedEvent userEmailChangedEvent)
        {
            Guid guid = Guid.NewGuid();
            using var connection = new SqlConnection(_connectionString);

            await connection.ExecuteAsync("INSERT INTO EMAILCONFIRMATION (Id, CreateDate, OldEmailAddress, NewEmailAddress) VALUES (@Id, GETDATE(), @OldEmailAddress, @NewEmailAddress)",
                    new
                    {
                        Id = guid,
                        userEmailChangedEvent.OldEmailAddress,
                        userEmailChangedEvent.NewEmailAddress
                    });

            return guid;
        }
    }
}
