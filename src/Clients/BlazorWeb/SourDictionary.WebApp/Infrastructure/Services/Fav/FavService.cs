namespace SourDictionary.WebApp.Infrastructure.Services.Fav
{
    public class FavService : IFavService
    {
        private readonly HttpClient _client;

        public FavService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateEntryFavAsync(Guid entryId)
        {
            await _client.PostAsync($"/api/favorite/Entry/{entryId}", null);
        }

        public async Task CreateEntryCommentFavAsync(Guid entryCommentId)
        {
            await _client.PostAsync($"/api/favorite/EntryComment/{entryCommentId}", null);
        }

        public async Task DeleteEntryFavAsync(Guid entryId)
        {
            await _client.PostAsync($"/api/favorite/DeleteEntryFav/{entryId}", null);
        }

        public async Task DeleteEntryCommentFavAsync(Guid entryCommentId)
        {
            await _client.PostAsync($"/api/favorite/DeleteEntryCommentFav/{entryCommentId}", null);
        }
    }
}
