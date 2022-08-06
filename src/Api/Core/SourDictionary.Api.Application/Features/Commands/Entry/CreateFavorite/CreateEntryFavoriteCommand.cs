namespace SourDictionary.Api.Application.Features.Commands.Entry.CreateFavorite
{
    public class CreateEntryFavoriteCommand : IRequest<bool>
    {
        public Guid? EntryId { get; set; }
        public Guid? UserId { get; set; }

        public CreateEntryFavoriteCommand(Guid? entryId, Guid? userId)
        {
            EntryId = entryId;
            UserId = userId;
        }
    }
}
