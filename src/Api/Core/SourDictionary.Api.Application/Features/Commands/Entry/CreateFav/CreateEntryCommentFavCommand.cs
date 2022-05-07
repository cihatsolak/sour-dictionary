namespace SourDictionary.Api.Application.Features.Commands.Entry.CreateFav
{
    public class CreateEntryCommentFavCommand : IRequest<bool>
    {
        public Guid EntryCommentId { get; set; }
        public Guid UserId { get; set; }

        public CreateEntryCommentFavCommand(Guid entryCommandId, Guid userId)
        {
            EntryCommentId = entryCommandId;
            UserId = userId;
        }
    }
}
