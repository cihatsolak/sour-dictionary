using SourDictionary.Common.Infrastructure.Extensions;

namespace SourDictionary.Api.Application.Features.Queries.GetMainPageEntries
{
    public class GetMainPageEntriesQueryHandler : IRequestHandler<GetMainPageEntriesQuery, PagedViewModel<GetEntryDetailViewModel>>
    {
        private readonly IEntryRepository _entryRepository;

        public GetMainPageEntriesQueryHandler(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public async Task<PagedViewModel<GetEntryDetailViewModel>> Handle(GetMainPageEntriesQuery request, CancellationToken cancellationToken)
        {
            var query = _entryRepository.AsQueryable();

            query = query.Include(p => p.EntryFavorites)
                         .Include(p => p.CreatedBy)
                         .Include(p => p.EntryVotes);

            var list = query.Select(p => new GetEntryDetailViewModel()
            {
                Id = p.Id,
                Subject = p.Subject,
                Content = p.Content,
                IsFavorited = request.UserId.HasValue && p.EntryFavorites.Any(x => x.CreatedById == request.UserId),
                FavoritedCount = p.EntryFavorites.Count,
                CreatedDate = p.CreateDate,
                CreatedByUserName = p.CreatedBy.UserName,
                VoteType =
                request.UserId.HasValue && p.EntryVotes.Any(x => x.CreatedById == request.UserId) ? p.EntryVotes.First(j => j.CreatedById.Equals(request.UserId)).VoteType : VoteType.None
            });

            return await list.GetPagedAsync(request.Page, request.PageSize);
        }
    }
}
