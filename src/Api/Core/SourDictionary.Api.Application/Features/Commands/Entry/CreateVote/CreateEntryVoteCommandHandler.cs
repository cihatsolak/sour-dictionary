namespace SourDictionary.Api.Application.Features.Commands.Entry.CreateVote
{
    public class CreateEntryVoteCommandHandler : IRequestHandler<CreateEntryVoteCommand, bool>
    {
        public async Task<bool> Handle(CreateEntryVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: DictionaryConstants.VoteExchangeName,
                exchangeType: DictionaryConstants.DefaultExchangeType,
                queueName: DictionaryConstants.CreateEntryVoteQueueName,
                model: new CreateEntryVoteEvent()
                {
                    EntryId = request.EntryId,
                    CreatedBy = request.CreatedBy,
                    VoteType = request.VoteType
                });

            return await Task.FromResult(true);
        }
    }
}
