namespace SourDictionary.Projections.UserService.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(
            IConfiguration configuration, 
            ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public string GenerateConfirmationLink(Guid confirmationId) => string.Concat(_configuration["ConfirmationLinkBase"], confirmationId);

        public Task SendEmailAsync(string toEmailAddress, string content)
        {
            _logger.LogInformation("Email sent to {@toEmailAddress} with content of {@content}", toEmailAddress, content);
            return Task.CompletedTask;
        }
    }
}
