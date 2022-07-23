namespace SourDictionary.Projections.FavoriteService
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
            string connectionString = _configuration.GetConnectionString("SourDictionaryDbConnectionString");

            Services.FavoriteService favoriteService = new(connectionString);

            QueueFactory.CreateBasicConsumer()
            .EnsureExchange(DictionaryConstants.FavoriteExchangeName)
            .EnsureQueue(DictionaryConstants.CreateEntryFavoriteQueueName, DictionaryConstants.FavoriteExchangeName)
            .Receive<CreateEntryFavoriteEvent>(createEntryFavoriteEvent =>
            {
                favoriteService.CreateEntryFavoriteAsync(createEntryFavoriteEvent).GetAwaiter().GetResult();
                _logger.LogInformation("Received EntryId: {id}", createEntryFavoriteEvent.EntryId);
            })
            .StartConsuming(DictionaryConstants.CreateEntryFavoriteQueueName);
        }
    }
}