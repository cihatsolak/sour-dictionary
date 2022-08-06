namespace SourDictionary.Api.Application.Features.Commands.EntryComment.DeleteFavorite
{
    public class DeleteEntryCommentFavoriteCommand : IRequest<bool>
    {
        public Guid EntryCommentId { get; set; }
        public Guid UserId { get; set; }

        public DeleteEntryCommentFavoriteCommand(Guid entryCommentId, Guid userId)
        {
            EntryCommentId = entryCommentId;
            UserId = userId;
        }
    }
}
