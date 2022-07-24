namespace SourDictionary.WebApp.Infrastructure.Services.Entry
{
    public class EntryService : IEntryService
    {
        private readonly HttpClient _client;

        public EntryService(HttpClient client)
        {
            _client = client;
        }


        public async Task<List<GetEntriesViewModel>> GetEntiresAsync()
        {
            var result = await _client.GetFromJsonAsync<List<GetEntriesViewModel>>("/api/entry?todaysEnties=false&count=30");
            return result;
        }

        public async Task<GetEntryDetailViewModel> GetEntryDetailAsync(Guid entryId)
        {
           return await _client.GetFromJsonAsync<GetEntryDetailViewModel>($"/api/entry/{entryId}");
        }

        public async Task<PagedViewModel<GetEntryDetailViewModel>> GetMainPageEntriesAsync(int page, int pageSize)
        {
            return await _client.GetFromJsonAsync<PagedViewModel<GetEntryDetailViewModel>>($"/api/entry/mainpageentries?page={page}&pageSize={pageSize}");
        }

        public async Task<PagedViewModel<GetEntryDetailViewModel>> GetProfilePageEntriesAsync(int page, int pageSize, string userName = null)
        {
            var result = await _client.GetFromJsonAsync<PagedViewModel<GetEntryDetailViewModel>>($"/api/entry/UserEntries?userName={userName}&page={page}&pageSize={pageSize}");
            return result;
        }

        public async Task<PagedViewModel<GetEntryCommentsViewModel>> GetEntryCommentsAsync(Guid entryId, int page, int pageSize)
        {
            var result = await _client.GetFromJsonAsync<PagedViewModel<GetEntryCommentsViewModel>>($"/api/entry/comments/{entryId}?page={page}&pageSize={pageSize}");
            return result;
        }


        public async Task<Guid> CreateEntryAsync(CreateEntryCommand command)
        {
            var httpResponseMessage = await _client.PostAsJsonAsync("/api/Entry/CreateEntry", command);
            if (!httpResponseMessage.IsSuccessStatusCode)
                return Guid.Empty;

            var guidStr = await httpResponseMessage.Content.ReadAsStringAsync();
            return new Guid(guidStr.Trim('"'));
        }

        public async Task<Guid> CreateEntryCommentAsync(CreateEntryCommentCommand command)
        {
            var httpResponseMessage = await _client.PostAsJsonAsync("/api/Entry/CreateEntryComment", command);
            if (!httpResponseMessage.IsSuccessStatusCode)
                return Guid.Empty;

            var guidStr = await httpResponseMessage.Content.ReadAsStringAsync();
            return new Guid(guidStr.Trim('"'));
        }

        public async Task<List<SearchEntryViewModel>> SearchBySubjectAsync(string searchText)
        {
            var result = await _client.GetFromJsonAsync<List<SearchEntryViewModel>>($"/api/entry/Search?searchText={searchText}");
            return result;
        }
    }
}
