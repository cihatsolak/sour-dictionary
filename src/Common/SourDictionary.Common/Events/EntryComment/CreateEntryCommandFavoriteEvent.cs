namespace SourDictionary.Common.Events.EntryComment
{
    public class CreateEntryCommandFavoriteEvent
    {
        public Guid EntryCommentId { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
