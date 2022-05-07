namespace SourDictionary.Common.Events.EntryComment
{
    public class CreateEntryVoteEvent
    {
        public Guid EntryId { get; set; }
        public VoteType VoteType { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
