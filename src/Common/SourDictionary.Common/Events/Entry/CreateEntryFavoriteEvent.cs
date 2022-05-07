namespace SourDictionary.Common.Events.Entry
{
    public class CreateEntryFavoriteEvent
    {
        public Guid EntryId { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
