namespace SourDictionary.Common.Events.Entry
{
    public class CreateEntryFavoriteEvent
    {
        public Guid EntryCommentId { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
