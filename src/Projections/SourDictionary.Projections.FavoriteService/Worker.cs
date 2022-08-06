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

            QueueFactory.CreateBasicConsumer()
            .EnsureExchange(DictionaryConstants.FavoriteExchangeName)
            .EnsureQueue(DictionaryConstants.DeleteEntryFavoriteQueueName, DictionaryConstants.FavoriteExchangeName)
            .Receive<DeleteEntryFavoriteEvent>(deleteEntryFavoriteEvent =>
            {
                favoriteService.DeleteEntryFavoriteAsync(deleteEntryFavoriteEvent).GetAwaiter().GetResult();
                _logger.LogInformation("Deleted Received EntryId: {id}", deleteEntryFavoriteEvent.EntryId);
            })
            .StartConsuming(DictionaryConstants.DeleteEntryFavoriteQueueName);

            QueueFactory.CreateBasicConsumer()
            .EnsureExchange(DictionaryConstants.FavoriteExchangeName)
            .EnsureQueue(DictionaryConstants.CreateEntryCommentFavoriteQueueName, DictionaryConstants.FavoriteExchangeName)
            .Receive<CreateEntryCommentFavoriteEvent>(createEntryCommentFavoriteEvent =>
            {
                favoriteService.CreateEntryCommentFavoriteAsync(createEntryCommentFavoriteEvent).GetAwaiter().GetResult();
                _logger.LogInformation("Create EntryComment Received EntryId: {id}", createEntryCommentFavoriteEvent.EntryCommentId);
            })
            .StartConsuming(DictionaryConstants.CreateEntryCommentFavoriteQueueName);

            QueueFactory.CreateBasicConsumer()
           .EnsureExchange(DictionaryConstants.FavoriteExchangeName)
           .EnsureQueue(DictionaryConstants.DeleteEntryCommentFavQueueName, DictionaryConstants.FavoriteExchangeName)
           .Receive<DeleteEntryCommentFavoriteEvent>(deleteEntryCommentFavoriteEvent =>
           {
               favoriteService.DeleteEntryCommentFavoriteAsync(deleteEntryCommentFavoriteEvent).GetAwaiter().GetResult();
               _logger.LogInformation("Deleted Received EntryId: {id}", deleteEntryCommentFavoriteEvent.EntryCommentId);
           })
           .StartConsuming(DictionaryConstants.DeleteEntryCommentFavQueueName);
        }
    }
}