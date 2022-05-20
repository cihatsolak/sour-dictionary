﻿namespace SourDictionary.Api.Application.Features.Queries.GetEntries
{
    public class GetEntiesQuery : IRequest<List<GetEntriesViewModel>>
    {
        public bool TodaysEntries { get; set; }
        public int Count { get; set; } = 100;
    }
}
