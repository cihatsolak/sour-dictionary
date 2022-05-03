namespace SourDictionary.Api.Application.Features.Commands.User.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existsUser = await _userRepository.GetSingleAsync(p => p.EmailAddress.Equals(request.EmailAddress));
            if (existsUser is not null)
                throw new DatabaseValidationException("user already exits!");

            var user = _mapper.Map<Domain.Models.User>(request);
            bool succeeded = await _userRepository.AddAsync(user) > 0;

            if (succeeded)
            {
                UserWelcomeEmailEvent userWelcomeEmailEvent = new()
                {
                    EmailAddress = user.EmailAddress
                };

                QueueFactory.SendMessageToExchange<UserWelcomeEmailEvent>(
                                                   exchangeName: DictionaryConstants.UserExchangeName,
                                                   exchangeType: DictionaryConstants.DefaultExchangeType,
                                                   queueName: DictionaryConstants.UserWelcomeEmailQueueName,
                                                   model: userWelcomeEmailEvent);
            }

            return user.Id;
        }
    }
}
