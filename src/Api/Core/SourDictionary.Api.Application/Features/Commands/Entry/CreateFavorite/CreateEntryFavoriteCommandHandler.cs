namespace SourDictionary.Api.Application.Features.Commands.Entry.CreateFavorite
{
    public class CreateEntryFavoriteCommandHandler : IRequestHandler<CreateEntryFavoriteCommand, bool>
    {
        public async Task<bool> Handle(CreateEntryFavoriteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(
                exchangeName: DictionaryConstants.FavoriteExchangeName,
                exchangeType: DictionaryConstants.DefaultExchangeType,
                queueName: DictionaryConstants.CreateEntryFavoriteQueueName,
                model: new CreateEntryFavoriteEvent()
                {
                    EntryId = request.EntryId.Value,
                    CreatedBy = request.UserId.Value
                }
            );

            return await Task.FromResult(true);
        }
    }
}
