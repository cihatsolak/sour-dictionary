namespace SourDictionary.Common.Events.EntryComment
{
    public class CreateEntryFavoriteEvent
    {
        public Guid EntryCommentId { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
