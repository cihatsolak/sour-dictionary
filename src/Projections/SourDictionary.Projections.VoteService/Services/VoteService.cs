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

        public async Task CreateEntryCommentVoteAsync(CreateEntryCommentVoteEvent createEntryCommentVoteEvent)
        {
            await DeleteEntryCommentVoteAsync(createEntryCommentVoteEvent.EntryCommentId, createEntryCommentVoteEvent.CreatedBy);

            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("INSERT INTO ENTRYCOMMENTVOTE (Id, CreateDate, EntryCommentId, VoteType, CREATEDBYID) VALUES (@Id, GETDATE(), @EntryCommentId, @VoteType, @CreatedById)",
                new
                {
                    Id = Guid.NewGuid(),
                    createEntryCommentVoteEvent.EntryCommentId,
                    VoteType = Convert.ToInt16(createEntryCommentVoteEvent.VoteType),
                    CreatedById = createEntryCommentVoteEvent.CreatedBy
                });
        }

        public async Task DeleteEntryCommentVoteAsync(Guid entryCommentId, Guid userId)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("DELETE FROM EntryCommentVote WHERE EntryCommentId = @EntryCommentId AND CREATEDBYID = @UserId",
                new
                {
                    EntryCommentId = entryCommentId,
                    UserId = userId
                });
        }
    }
}
