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
                .ExecuteAsync("INSERT INTO EntryFavorite (Id, EntryId, CreatedById, CreateDate) VALUES(@Id, @EntryId, @CreatedById, NOW())",
                new
                {
                    Id = Guid.NewGuid(),
                    createEntryFavoriteEvent.EntryId,
                    CreatedById = createEntryFavoriteEvent.CreatedBy
                });
        }
    }
}
