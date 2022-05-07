namespace SourDictionary.Api.Application.Features.Commands.EntryComment.CreateFav
{
    public class CreateEntryCommentFavoriteCommandHandler : IRequestHandler<CreateEntryCommentFavoriteCommand, bool>
    {
        public async Task<bool> Handle(CreateEntryCommentFavoriteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(
                exchangeName: DictionaryConstants.FavoriteExchangeName,
                exchangeType: DictionaryConstants.DefaultExchangeType,
                queueName: DictionaryConstants.CreateEntryCommentFavoriteQueueName,
                model: new CreateEntryCommentFavoriteEvent()
                {
                    EntryCommentId = request.EntryCommentId,
                    CreatedBy = request.UserId
                });

            return await Task.FromResult(true);
        }
    }
}
