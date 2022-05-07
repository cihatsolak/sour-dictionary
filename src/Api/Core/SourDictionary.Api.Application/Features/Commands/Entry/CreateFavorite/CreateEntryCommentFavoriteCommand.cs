namespace SourDictionary.Api.Application.Features.Commands.Entry.CreateFavorite
{
    public class CreateEntryCommentFavoriteCommand : IRequest<bool>
    {
        public Guid EntryCommentId { get; set; }
        public Guid UserId { get; set; }

        public CreateEntryCommentFavoriteCommand(Guid entryCommandId, Guid userId)
        {
            EntryCommentId = entryCommandId;
            UserId = userId;
        }
    }
}
