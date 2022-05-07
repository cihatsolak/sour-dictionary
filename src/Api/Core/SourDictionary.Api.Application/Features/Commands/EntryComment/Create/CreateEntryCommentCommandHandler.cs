namespace SourDictionary.Api.Application.Features.Commands.EntryComment.Create
{
    public class CreateEntryCommentCommandHandler : IRequestHandler<CreateEntryCommentCommand, Guid>
    {
        private readonly IEntryCommentRepository _entryCommentRepository;
        private readonly IMapper _mapper;

        public CreateEntryCommentCommandHandler(IEntryCommentRepository entryCommentRepository, IMapper mapper)
        {
            _entryCommentRepository = entryCommentRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEntryCommentCommand request, CancellationToken cancellationToken)
        {
            var entryComment = _mapper.Map<Domain.Models.EntryComment>(request);
            await _entryCommentRepository.AddAsync(entryComment);

            return entryComment.Id;
        }
    }
}
