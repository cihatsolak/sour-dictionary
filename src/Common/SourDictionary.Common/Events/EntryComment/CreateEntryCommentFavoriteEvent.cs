namespace SourDictionary.Common.Events.EntryComment
{
    public class CreateEntryCommentFavoriteEvent
    {
        public Guid EntryCommentId { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
