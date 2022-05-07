namespace SourDictionary.Common.Events.EntryComment
{
    public class DeleteEntryCommentFavoriteEvent
    {
        public Guid EntryCommentId { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
