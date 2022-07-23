namespace SourDictionary.Projections.VoteService.Services
{
    public class VoteService
    {
        private readonly string _connectionString;

        public VoteService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task CreateEntryVoteAsync(CreateEntryVoteEvent createEntryVoteEvent)
        {
            await DeleteEntryVoteAsync(createEntryVoteEvent.EntryId, createEntryVoteEvent.CreatedBy);

            using var connection = new SqlConnection(_connectionString);

            await connection.ExecuteAsync("INSERT INTO ENTRYVOTE (Id, CreateDate, EntryId, VoteType, CreatedById) VALUES (@Id, GETDATE(), @EntryId, @VoteType, @CreatedById)",
                new
                {
                    Id = Guid.NewGuid(),
                    createEntryVoteEvent.EntryId,
                    VoteType = (int)createEntryVoteEvent.VoteType,
                    CreatedById = createEntryVoteEvent.CreatedBy
                });
        }

        public async Task DeleteEntryVoteAsync(Guid entryId, Guid userId)
        {
            using var connection = new SqlConnection(_connectionString);

            await connection.ExecuteAsync("DELETE FROM EntryVote WHERE EntryId = @EntryId AND CREATEDBYID = @UserId",
                new
                {
                    EntryId = entryId,
                    UserId = userId
                });
        }
    }
}
