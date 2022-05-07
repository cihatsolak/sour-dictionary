namespace SourDictionary.Api.Application.Features.Commands.Entry.DeleteFavorite
{
    public class DeleteEntryFavoriteCommandHandler : IRequestHandler<DeleteEntryFavoriteCommand, bool>
    {
        public async Task<bool> Handle(DeleteEntryFavoriteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(
                exchangeName: DictionaryConstants.FavoriteExchangeName,
                exchangeType: DictionaryConstants.DefaultExchangeType,
                queueName: DictionaryConstants.DeleteEntryFavoriteQueueName,
                model: new DeleteEntryFavoriteEvent()
                {
                    EntryId = request.EntryId,
                    CreatedBy = request.UserId
                });

            return await Task.FromResult(true);
        }
    }
}
