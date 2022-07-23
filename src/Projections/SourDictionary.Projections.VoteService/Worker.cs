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
                    _logger.LogInformation("Create Entry Received EntryId: {0}, VoteType: {1}", createEntryVoteEvent.EntryId, createEntryVoteEvent.VoteType);
                })
                .StartConsuming(DictionaryConstants.CreateEntryVoteQueueName);
        }
    }
}