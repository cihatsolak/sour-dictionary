namespace SourDictionary.Api.Application.Features.Commands.User.ChangePassword
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public ChangeUserPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            if (!request.UserId.HasValue)
                throw new ArgumentNullException(nameof(request.UserId));

            var user = await _userRepository.GetByIdAsync(request.UserId.Value);
            if (user is null)
                throw new DatabaseValidationException("User not found!");

            string encrptPassword = PasswordEncryptor.Encrpt(request.OldPassword);
            if (!user.Password.Equals(encrptPassword))
                throw new DatabaseValidationException("Old password wrong!");

            user.Password = PasswordEncryptor.Encrpt(request.NewPassword);
            await _userRepository.UpdateAsync(user);

            return true;
        }
    }
}
