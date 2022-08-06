namespace SourDictionary.Projections.FavoriteService.Services
{
    public class FavoriteService
    {
        private readonly string _connectionString;

        public FavoriteService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task CreateEntryFavoriteAsync(CreateEntryFavoriteEvent createEntryFavoriteEvent)
        {
            using var connection = new SqlConnection(_connectionString);

            await connection
                .ExecuteAsync("INSERT INTO EntryFavorite (Id, EntryId, CreatedById, CreateDate) VALUES(@Id, @EntryId, @CreatedById, GETDATE())",
                new
                {
                    Id = Guid.NewGuid(),
                    createEntryFavoriteEvent.EntryId,
                    CreatedById = createEntryFavoriteEvent.CreatedBy
                });
        }

        public async Task CreateEntryCommentFavoriteAsync(CreateEntryCommentFavoriteEvent createEntryCommentFavoriteEvent)
        {
            using var connection = new SqlConnection(_connectionString);

            await connection.ExecuteAsync("INSERT INTO EntryCommentFavorite (Id, EntryCommentId, CreatedById, CreateDate) VALUES(@Id, @EntryCommentId, @CreatedById, GETDATE())",
                new
                {
                    Id = Guid.NewGuid(),
                    createEntryCommentFavoriteEvent.EntryCommentId,
                    CreatedById = createEntryCommentFavoriteEvent.CreatedBy
                });
        }

        public async Task DeleteEntryFavoriteAsync(DeleteEntryFavoriteEvent deleteEntryFavoriteEvent)
        {
            using var connection = new SqlConnection(_connectionString);

            await connection.ExecuteAsync("DELETE FROM EntryFavorite WHERE EntryId = @EntryId AND CreatedById = @CreatedById",
                new
                {
                    Id = Guid.NewGuid(),
                    deleteEntryFavoriteEvent.EntryId,
                    CreatedById = deleteEntryFavoriteEvent.CreatedBy
                });
        }

        public async Task DeleteEntryCommentFavoriteAsync(DeleteEntryCommentFavoriteEvent deleteEntryCommentFavoriteEvent)
        {
            using var connection = new SqlConnection(_connectionString);

            await connection.ExecuteAsync("DELETE FROM EntryCommentFavorite WHERE EntryCommentId = @EntryCommentId AND CreatedById = @CreatedById",
                new
                {
                    Id = Guid.NewGuid(),
                    deleteEntryCommentFavoriteEvent.EntryCommentId,
                    CreatedById = deleteEntryCommentFavoriteEvent.CreatedBy
                });
        }
    }
}
