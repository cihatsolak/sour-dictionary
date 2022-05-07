namespace SourDictionary.Common.Events.Entry
{
    public class DeleteEntryFavoriteEvent
    {
        public Guid EntryId { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
