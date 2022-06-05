namespace SourDictionary.WebApp.Infrastructure.Services.Fav
{
    public interface IFavService
    {
        Task CreateEntryCommentFavAsync(Guid entryCommentId);
        Task CreateEntryFavAsync(Guid entryId);
        Task DeleteEntryCommentFavAsync(Guid entryCommentId);
        Task DeleteEntryFavAsync(Guid entryId);
    }
}