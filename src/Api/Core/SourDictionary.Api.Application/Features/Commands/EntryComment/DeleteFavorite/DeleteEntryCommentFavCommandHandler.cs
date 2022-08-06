namespace SourDictionary.Api.Application.Features.Commands.EntryComment.DeleteFavorite
{
    public class DeleteEntryCommentFavCommandHandler : IRequestHandler<DeleteEntryCommentFavoriteCommand, bool>
    {
        public async Task<bool> Handle(DeleteEntryCommentFavoriteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(
                exchangeName: DictionaryConstants.FavoriteExchangeName,
                exchangeType: DictionaryConstants.DefaultExchangeType,
                queueName: DictionaryConstants.DeleteEntryCommentFavQueueName,
                model: new DeleteEntryCommentFavoriteEvent()
                {
                    EntryCommentId = request.EntryCommentId,
                    CreatedBy = request.UserId
                });

            return await Task.FromResult(true);
        }
    }
}
