namespace SourDictionary.WebApp.Infrastructure.Services.Entry
{
    public interface IEntryService
    {
        Task<Guid> CreateEntryAsync(CreateEntryCommand command);
        Task<Guid> CreateEntryCommentAsync(CreateEntryCommentCommand command);
        Task<List<GetEntriesViewModel>> GetEntiresAsync();
        Task<PagedViewModel<GetEntryCommentsViewModel>> GetEntryCommentsAsync(Guid entryId, int page, int pageSize);
        Task<GetEntryDetailViewModel> GetEntryDetailAsync(Guid entryId);
        Task<PagedViewModel<GetEntryDetailViewModel>> GetMainPageEntriesAsync(int page, int pageSize);
        Task<PagedViewModel<GetEntryDetailViewModel>> GetProfilePageEntriesAsync(int page, int pageSize, string userName = null);
        Task<List<SearchEntryViewModel>> SearchBySubjectAsync(string searchText);
    }
}