namespace SourDictionary.Api.Application.Features.Commands.User.Login
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

            if (!user.EmailConfirmed)
                throw new DatabaseValidationException("Email address is not confirmed yet!");

            var result = _mapper.Map<LoginUserViewModel>(user);

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName)
            };

            result.Token = GenerateToken(claims);

            return result;
        }

        private string GenerateToken(Claim[] claims)
        {
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["AuthConfig:Secret"]));
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(10);

            JwtSecurityToken token = new(claims: claims,
                                             expires: expiry,
                                             signingCredentials: creds,
                                             notBefore: DateTime.Now);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
