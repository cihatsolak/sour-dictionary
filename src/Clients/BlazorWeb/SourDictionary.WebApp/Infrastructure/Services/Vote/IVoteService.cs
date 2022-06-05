namespace SourDictionary.WebApp.Infrastructure.Services.Vote
{
    public interface IVoteService
    {
        Task CreateEntryCommentDownVoteAsync(Guid entryCommentId);
        Task CreateEntryCommentUpVoteAsync(Guid entryCommentId);
        Task CreateEntryDownVoteAsync(Guid entryCommentId);
        Task CreateEntryUpVoteAsync(Guid entryId);
        Task DeleteEntryCommentVoteAsync(Guid entryCommentId);
        Task DeleteEntryVoteAsync(Guid entryId);
    }
}