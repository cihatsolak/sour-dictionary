namespace SourDictionary.Api.Application.Features.Commands.User
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LoginUserCommandHandler(
            IUserRepository userRepository,
            IMapper mapper,
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetSingleAsync(p => p.EmailAddress.Equals(request.EmailAddress));
            if (user is null)
                throw new DatabaseValidationException("User not found.");

            var password = PasswordEncryptor.Encrpt(request.Password);
            if (!user.Password.Equals(password))
                throw new DatabaseValidationException("Password is wrong!");

            if(!user.EmailConfirmed)
                throw new DatabaseValidationException("Email address is not confirmed yet!");

            var result = _mapper.Map<LoginUserViewModel>(user);

            result.Token = "";
        }
    }
}
