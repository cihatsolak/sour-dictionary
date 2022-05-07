namespace SourDictionary.Api.Application.Features.Commands.Entry.Create
{
    public class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommand, Guid>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IMapper _mapper;

        public CreateEntryCommandHandler(IEntryRepository entryRepository, IMapper mapper)
        {
            _entryRepository = entryRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
        {
            var entry = _mapper.Map<Domain.Models.Entry>(request);
            await _entryRepository.AddAsync(entry);

            return entry.Id;
        }
    }
}
