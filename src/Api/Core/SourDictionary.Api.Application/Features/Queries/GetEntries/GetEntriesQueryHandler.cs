namespace SourDictionary.Api.Application.Features.Queries.GetEntries
{
    public class GetEntriesQueryHandler : IRequestHandler<GetEntriesQuery, List<GetEntriesViewModel>>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IMapper _mapper;

        public GetEntriesQueryHandler(
            IEntryRepository entryRepository,
            IMapper mapper)
        {
            _entryRepository = entryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetEntriesViewModel>> Handle(GetEntriesQuery request, CancellationToken cancellationToken)
        {
            var query = _entryRepository.AsQueryable();

            if (request.TodaysEntries)
            {
                query = query.Where(p => p.CreateDate >= DateTime.Now.Date && p.CreateDate <= DateTime.Now.AddDays(1).Date);
            }

            query = query.Include(p => p.EntryComments)
                    .OrderBy(p => Guid.NewGuid())
                    .Take(request.Count);

            return await query.ProjectTo<GetEntriesViewModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }
    }
}
