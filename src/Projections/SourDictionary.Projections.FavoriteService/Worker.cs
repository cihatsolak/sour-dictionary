using SourDictionary.Common;
using SourDictionary.Common.Infrastructure;

namespace SourDictionary.Projections.FavoriteService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            QueueFactory.CreateBasicConsumer()
            .EnsureExchange(DictionaryConstants.FavoriteExchangeName)
            .EnsureQueue(DictionaryConstants.CreateEntryFavoriteQueueName, DictionaryConstants.FavoriteExchangeName)
            .
        }
    }
}