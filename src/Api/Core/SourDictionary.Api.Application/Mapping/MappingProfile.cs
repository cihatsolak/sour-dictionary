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

            CreateMap<CreateEntryCommand, Entry>()
                .ReverseMap();

            CreateMap<CreateEntryCommentCommand, EntryComment>()
                .ReverseMap();

            CreateMap<Entry, GetEntriesViewModel>()
                .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => src.EntryComments.Count));

            CreateMap<UserDetailViewModel, User>()
            .ReverseMap();
        }
    }
}
