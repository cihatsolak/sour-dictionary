namespace SourDictionary.Api.Application.Features.Commands.User.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailConfirmationRepository _emailConfirmationRepository;

        public ConfirmEmailCommandHandler(IUserRepository userRepository, IEmailConfirmationRepository emailConfirmationRepository)
        {
            _userRepository = userRepository;
            _emailConfirmationRepository = emailConfirmationRepository;
        }

        public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var emailConfirmation = await _emailConfirmationRepository.GetByIdAsync(request.ConfirmationId);
            if (emailConfirmation is null)
                throw new DatabaseValidationException("Confirmation not found!");

            var user = await _userRepository.GetSingleAsync(i => i.EmailAddress == emailConfirmation.NewEmailAddress);
            if (user is null)
                throw new DatabaseValidationException("User not found with this email!");

            if (user.EmailConfirmed)
                throw new DatabaseValidationException("Email address is already confirmed!");

            user.EmailConfirmed = true;
            await _userRepository.UpdateAsync(user);

            return true;
        }
    }
}
