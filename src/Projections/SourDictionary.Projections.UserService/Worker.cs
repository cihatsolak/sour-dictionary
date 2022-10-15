namespace SourDictionary.Projections.UserService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly Services.UserService _userService;
        private readonly EmailService _emailService;

        public Worker(
            ILogger<Worker> logger,
            Services.UserService userService,
            EmailService emailService)
        {
            _logger = logger;
            _userService = userService;
            _emailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            QueueFactory.CreateBasicConsumer()
                .EnsureExchange(DictionaryConstants.UserExchangeName)
                .EnsureQueue(DictionaryConstants.UserEmailChangedQueueName, DictionaryConstants.UserExchangeName)
                .Receive<UserEmailChangedEvent>(user =>
                {
                    Guid confirmationId = _userService.CreateEmailConfirmationAsync(user).GetAwaiter().GetResult();
                    string link = _emailService.GenerateConfirmationLink(confirmationId);

                    _emailService.SendEmailAsync(user.NewEmailAddress, link).GetAwaiter().GetResult();
                })
                .StartConsuming(DictionaryConstants.UserEmailChangedQueueName);
        }
    }
}