namespace SourDictionary.Projections.VoteService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;

        public Worker(
            ILogger<Worker> logger, 
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string connectionString = _configuration.GetConnectionString("SourDictionaryDbConnectionString"); ;

            var voteService = new Services.VoteService(connectionString);

            QueueFactory.CreateBasicConsumer()
                .EnsureExchange(DictionaryConstants.VoteExchangeName)
                .EnsureQueue(DictionaryConstants.CreateEntryVoteQueueName, DictionaryConstants.VoteExchangeName)
                .Receive<CreateEntryVoteEvent>(createEntryVoteEvent =>
                {
                    voteService.CreateEntryVoteAsync(createEntryVoteEvent).GetAwaiter().GetResult();
                    _logger.LogInformation("Create Entry Received EntryId: {@entryId}, VoteType: {@voteType}", createEntryVoteEvent.EntryId, createEntryVoteEvent.VoteType);
                })
                .StartConsuming(DictionaryConstants.CreateEntryVoteQueueName);

            QueueFactory.CreateBasicConsumer()
            .EnsureExchange(DictionaryConstants.VoteExchangeName)
            .EnsureQueue(DictionaryConstants.DeleteEntryVoteQueueName, DictionaryConstants.VoteExchangeName)
            .Receive<DeleteEntryVoteEvent>(deleteEntryVoteEvent =>
            {
                voteService.DeleteEntryVoteAsync(deleteEntryVoteEvent.EntryId, deleteEntryVoteEvent.CreatedBy).GetAwaiter().GetResult();
                _logger.LogInformation("Delete Entry Received EntryId: {@entryId}", deleteEntryVoteEvent.EntryId);
            })
            .StartConsuming(DictionaryConstants.DeleteEntryVoteQueueName);


            QueueFactory.CreateBasicConsumer()
                    .EnsureExchange(DictionaryConstants.VoteExchangeName)
                    .EnsureQueue(DictionaryConstants.CreateEntryCommentVoteQueueName, DictionaryConstants.VoteExchangeName)
                    .Receive<CreateEntryCommentVoteEvent>(createEntryCommentVoteEvent =>
                    {
                        voteService.CreateEntryCommentVoteAsync(createEntryCommentVoteEvent).GetAwaiter().GetResult();
                        _logger.LogInformation("Create Entry Comment Received EntryCommentId: {@entryCommentId}, VoteType: {@voteType}", createEntryCommentVoteEvent.EntryCommentId, createEntryCommentVoteEvent.VoteType);
                    })
                    .StartConsuming(DictionaryConstants.CreateEntryCommentVoteQueueName);

            QueueFactory.CreateBasicConsumer()
                    .EnsureExchange(DictionaryConstants.VoteExchangeName)
                    .EnsureQueue(DictionaryConstants.DeleteEntryCommentVoteQueueName, DictionaryConstants.VoteExchangeName)
                    .Receive<DeleteEntryCommentVoteEvent>(deleteEntryCommentVoteEvent =>
                    {
                        voteService.DeleteEntryCommentVoteAsync(deleteEntryCommentVoteEvent.EntryCommentId, deleteEntryCommentVoteEvent.CreatedBy).GetAwaiter().GetResult();
                        _logger.LogInformation("Delete Entry Comment Received EntryCommentId: {@entryCommentId}", deleteEntryCommentVoteEvent.EntryCommentId);
                    })
                    .StartConsuming(DictionaryConstants.DeleteEntryCommentVoteQueueName);
        }
    }
}