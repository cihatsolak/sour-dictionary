namespace SourDictionary.Api.Application.Features.Commands.User.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user is null)
                throw new DatabaseValidationException("User not found!");

            string currentEmailAdress = user.EmailAddress;
            _mapper.Map(request, user);

            bool succeeded = await _userRepository.UpdateAsync(user) > 0;
            bool isEmailChanged = string.CompareOrdinal(currentEmailAdress, request.EmailAddress) > 0;

            if (succeeded && isEmailChanged)
            {
                UserEmailChangedEvent userEmailChangedEvent = new()
                {
                    OldEmailAddress = currentEmailAdress,
                    NewEmailAddress = request.EmailAddress
                };

                QueueFactory.SendMessageToExchange<UserEmailChangedEvent>(
                                                  exchangeName: DictionaryConstants.UserExchangeName,
                                                  exchangeType: DictionaryConstants.DefaultExchangeType,
                                                  queueName: DictionaryConstants.UserEmailChangedQueueName,
                                                  model: userEmailChangedEvent);

                user.EmailConfirmed = false;
                await _userRepository.UpdateAsync(user);
            }

            return user.Id;
        }
    }
}
