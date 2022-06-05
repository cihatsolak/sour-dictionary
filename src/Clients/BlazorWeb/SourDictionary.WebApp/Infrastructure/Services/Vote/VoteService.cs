namespace SourDictionary.WebApp.Infrastructure.Services.Vote
{
    public class VoteService : IVoteService
    {
        private readonly HttpClient client;

        public VoteService(HttpClient client)
        {
            this.client = client;
        }

        public async Task DeleteEntryVoteAsync(Guid entryId)
        {
            var httpResponseMessage = await client.PostAsync($"/api/Vote/DeleteEntryVote/{entryId}", null);
            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new Exception("DeleteEntryVote error");
        }

        public async Task DeleteEntryCommentVoteAsync(Guid entryCommentId)
        {
            var httpResponseMessage = await client.PostAsync($"/api/Vote/DeleteEntryCommentVote/{entryCommentId}", null);

            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new Exception("DeleteEntryCommentVote error");
        }

        public async Task CreateEntryUpVoteAsync(Guid entryId)
        {
            await CreateEntryVoteAsync(entryId, VoteType.UpVote);
        }

        public async Task CreateEntryDownVoteAsync(Guid entryCommentId)
        {
            await CreateEntryVoteAsync(entryCommentId, VoteType.DownVote);
        }

        public async Task CreateEntryCommentUpVoteAsync(Guid entryCommentId)
        {
            await CreateEntryCommentVoteAsync(entryCommentId, VoteType.UpVote);
        }

        public async Task CreateEntryCommentDownVoteAsync(Guid entryCommentId)
        {
            await CreateEntryCommentVoteAsync(entryCommentId, VoteType.DownVote);
        }


        private async Task<HttpResponseMessage> CreateEntryVoteAsync(Guid entryId, VoteType voteType = VoteType.UpVote)
        {
            var result = await client.PostAsync($"/api/vote/entry/{entryId}?voteType={voteType}", null);
            // TODO Check success code
            return result;
        }

        private async Task<HttpResponseMessage> CreateEntryCommentVoteAsync(Guid entryCommentId, VoteType voteType = VoteType.UpVote)
        {
            var result = await client.PostAsync($"/api/vote/entrycomment/{entryCommentId}?voteType={voteType}", null);
            // TODO Check success code
            return result;
        }
    }
}
