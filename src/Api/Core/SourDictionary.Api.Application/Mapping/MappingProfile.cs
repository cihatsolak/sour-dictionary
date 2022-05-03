namespace SourDictionary.Api.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginUserViewModel>()
                .ReverseMap();

            CreateMap<User, CreateUserCommand>()
                .ReverseMap();

            CreateMap<User, UpdateUserCommand>()
               .ReverseMap();
        }
    }
}
